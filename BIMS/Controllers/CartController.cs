using BIMS.Services;
using Microsoft.AspNetCore.Mvc;
using BIMS.Models;
using Microsoft.AspNetCore.Http;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BIMS.Repositories;

namespace BIMS.Controllers
{
   public class CartController : Controller
{
    private readonly ICartService _cartService;
        private readonly BIMSContext _context;
        private readonly IOrderService _orderService;
        private readonly INotificationService _notificationService;
    

        public CartController(ICartService cartService, BIMSContext context, IOrderService orderService, INotificationService notificationService)
        {
            _cartService = cartService;
            _context = context;
            _orderService = orderService;
            _notificationService = notificationService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
                if (userId == 0) return RedirectToAction("Login", "Users");

                var cartItems = await _cartService.GetUserCartAsync(userId);
                return View(cartItems);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Cart Index: {ex.Message}");
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(int itemId, int quantity)

    {
            try
            {
                int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
                Console.WriteLine($"DEBUG: UserId in AddToCart: {userId}");
                if (userId == 0)
                {
                    return Json(new { success = false, message = "You must be logged in to add items to the cart." });
                }
                var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == itemId);
                if (item == null) return NotFound(); 
            decimal itemPrice = item.Price;
            Cart cart = new Cart
            { UserId = userId, 
              ItemId = itemId, 
              Quantity = quantity, 
              TotalPrice = item.Price * quantity };
                    await _cartService.AddToCartAsync(cart);
            var cartCount = await _cartService.GetCartCountAsync(userId);
            HttpContext.Session.SetInt32("CartCount", cartCount);
            return Json(new { success = true, message = "Item added to cart successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Database error: " + ex.InnerException?.Message ?? ex.Message });
            }
        }

        // Checkout Page (Shows Order Summary & User Info Form)
        public async Task<IActionResult> Checkout()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                TempData["Error"] = "You must be logged in to proceed to checkout.";
                return RedirectToAction("Login", "Users");
            }

            var cartItems = await _cartService.GetUserCartAsync(userId.Value);
            if (cartItems.Count == 0)
            {
                TempData["Error"] = "Your cart is empty.";
                return RedirectToAction("ViewCart", "Cart");
            }

            ViewBag.TotalAmount = cartItems.Sum(i => i.TotalPrice * i.Quantity);
            return View(cartItems); // Show user a checkout form
        }
        // 💳 Proceed to Checkout
        public async Task<IActionResult> ProceedToCheckout()
        {
            var userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            var cartItems = await _context.Carts
                                          .Include(ci => ci.Item)
                                          .Where(ci => ci.UserId == userId)
                                          .ToListAsync();

            if (!cartItems.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            var totalAmount = cartItems.Sum(i => i.Item.Price * i.Quantity);
            ViewBag.TotalAmount = totalAmount;  // ✅ Send total amount to view

            return View(cartItems);
        }





        public async Task<IActionResult> RemoveFromCart(int cartId)
        {
            await _cartService.RemoveFromCartAsync(cartId);
            return RedirectToAction("Index", "Cart");
        }
     




        [HttpPost]

        public async Task<IActionResult> CheckoutConfirm(string address, string contactNumber)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                TempData["Error"] = "You must be logged in to checkout.";
                return RedirectToAction("Login", "Users");
            }

            var cartItems = await _cartService.GetUserCartAsync(userId.Value);
            if (cartItems.Count == 0)
            {
                TempData["Error"] = "Your cart is empty.";
                return RedirectToAction("ViewCart", "Cart");
            }

            var orderItems = cartItems.Select(cart => new OrderItem
            {
                ItemId = cart.ItemId,
                Quantity = cart.Quantity,
                Price = cart.TotalPrice
            }).ToList();

            var order = await _orderService.CreateOrderAsync(userId.Value, orderItems, address, contactNumber);

            // Notify admin & shop owners
            await _notificationService.NotifyAdmin(order.Id);
            await _notificationService.NotifyShopOwners(order.Id);

            // Clear the cart
            await _cartService.ClearCartAsync(userId.Value);

            TempData["Success"] = "Thank you for shopping with us!";
            return RedirectToAction("OrderConfirmation");
        }

        // Order Confirmation Page
        public async Task<IActionResult> OrderConfirmation()

        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Users");
            }
            // Retrieve the last order details for the user, or handle accordingly
            var lastOrder = await _orderService.GetOrderDetailsAsync(userId.Value);

            if (lastOrder == null)
            {
                // Handle case where there is no order (maybe redirect or show a message)
                TempData["Error"] = "No order found.";
                return RedirectToAction("Index", "Home");
            }

            return View(lastOrder);
        }

        public async Task<IActionResult> ClearCart()
    {
        int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
        if (userId == 0) return RedirectToAction("Login", "users");

        await _cartService.ClearCartAsync(userId);
        return RedirectToAction("Index");
    }
}
}
