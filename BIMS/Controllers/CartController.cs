using BIMS.Services;
using Microsoft.AspNetCore.Mvc;
using BIMS.Models;
using Microsoft.AspNetCore.Http;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Controllers
{
   public class CartController : Controller
{
    private readonly ICartService _cartService;
        private readonly BIMSContext _context;
        private readonly IOrderService _orderService;

        public CartController(ICartService cartService, BIMSContext context, IOrderService orderService)
        {
            _cartService = cartService;
            _context = context;
            _orderService = orderService;
        }

        // Show Cart View
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
                // Log the error
                Console.WriteLine($"Error in Cart Index: {ex.Message}");
                return RedirectToAction("Error", "Home"); // Redirect to an error page
            }
        }

        // Add Item to Cart
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

                // Fetch the item from the database to get the price
                var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == itemId);

            if (item == null) return NotFound(); // Handle case where the item doesn't exist

            decimal itemPrice = item.Price; // Assuming your Item model has a Price field

         



            Cart cart = new Cart
            { UserId = userId, 
              ItemId = itemId, 
              Quantity = quantity, 
              TotalPrice = item.Price * quantity };

        await _cartService.AddToCartAsync(cart);
            // Update cart count in session
            var cartCount = await _cartService.GetCartCountAsync(userId);
            HttpContext.Session.SetInt32("CartCount", cartCount);
            return Json(new { success = true, message = "Item added to cart successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error: " + ex.Message });
            }
        }

        // Remove Item from Cart
        public async Task<IActionResult> RemoveFromCart(int cartId)
    {
        await _cartService.RemoveFromCartAsync(cartId);
        return RedirectToAction("Index", "Cart");
    }
        // Checkout Action
        public async Task<IActionResult> Checkout()
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            if (userId == 0) return RedirectToAction("Login", "Users");

            // Get the user's cart
            var cartItems = await _cartService.GetUserCartAsync(userId);

            if (cartItems == null || cartItems.Count == 0)
            {
                // If the cart is empty, redirect the user
                return RedirectToAction("Index");
            }

            // You can add any additional checkout processing here, such as payment, etc.

            // Process the order - assuming you have an OrderService to handle this logic
            // Process the order - now it uses CreateOrderAsync
            var order = await _orderService.CreateOrderAsync(userId, cartItems.Select(ci => new OrderItem
            {
                ItemId = ci.ItemId,
                Quantity = ci.Quantity,
                Price = ci.TotalPrice
            }).ToList());

            // Update stock for the items in the cart
            foreach (var item in cartItems)
            {
                var product = await _context.Items.FirstOrDefaultAsync(i => i.Id == item.ItemId);
                if (product != null)
                {
                    product.Stock -= item.Quantity; // Reduce stock based on cart quantity
                    _context.Items.Update(product);
                }
            }

            await _context.SaveChangesAsync(); // Save the updated stock

            // Clear the cart after checkout
            await _cartService.ClearCartAsync(userId);

            // Redirect to a confirmation page or order details page
            return RedirectToAction("OrderConfirmation");
        }

        // Order Confirmation (you can customize this to show order details)
        public IActionResult OrderConfirmation()
        {
            return View();
        }

        // Clear Cart
        public async Task<IActionResult> ClearCart()
    {
        int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
        if (userId == 0) return RedirectToAction("Login", "users");

        await _cartService.ClearCartAsync(userId);
        return RedirectToAction("Index");
    }
}
}
