using BIMS.Services;
using Microsoft.AspNetCore.Mvc;
using BIMS.Models;
using Microsoft.AspNetCore.Http;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BIMS.Repositories;
using System.Net;

namespace BIMS.Controllers
{
   public class CartController : Controller
{
    private readonly ICartService _cartService;
        private readonly BIMSContext _context;
        private readonly IOrderService _orderService;
        private readonly INotificationService _notificationService;
        private readonly ChapaService _chapaService;



        public CartController(ICartService cartService, BIMSContext context, IOrderService orderService, INotificationService notificationService , ChapaService chapaService)
        {
            _cartService = cartService;
            _orderService = orderService;
            _notificationService = notificationService;
            _chapaService = chapaService;
            _context = context;
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





        //public async Task<IActionResult> Checkout(string? address)
        //{
        //    int? userId = HttpContext.Session.GetInt32("UserId");
        //    if (userId == null)
        //    {
        //        TempData["Error"] = "You must be logged in to proceed to checkout.";
        //        return RedirectToAction("Login", "Users");
        //    }

        //    var cartItems = await _cartService.GetUserCartAsync(userId.Value);
        //    if (cartItems.Count == 0)
        //    {
        //        TempData["Error"] = "Your cart is empty.";
        //        return RedirectToAction("ViewCart", "Cart");
        //    }

        //    // Get contact number from session
        //    string? contactNumber = HttpContext.Session.GetString("UserContact");

        //    if (string.IsNullOrEmpty(address) || string.IsNullOrEmpty(contactNumber))
        //    {
        //        ViewBag.TotalAmount = cartItems.Sum(i => i.TotalPrice * i.Quantity);
        //        ViewBag.ContactNumber = contactNumber; // Pass the phone number to the view
        //        return View(cartItems); // Show user the checkout form
        //    }

        //    var orderItems = cartItems.Select(cart => new OrderItem
        //    {
        //        ItemId = cart.ItemId,
        //        Quantity = cart.Quantity,
        //        Price = cart.TotalPrice
        //    }).ToList();

        //    var order = await _orderService.CreateOrderAsync(userId.Value, orderItems, address, contactNumber);

        //    // Notify admin & shop owners
        //    await _notificationService.NotifyAdmin(order.Id);
        //    await _notificationService.NotifyShopOwners(order.Id);

        //    // Clear the cart
        //    await _cartService.ClearCartAsync(userId.Value);

        //    TempData["Success"] = "Thank you for shopping with us!";
        //    return RedirectToAction("OrderConfirmation");
        //}


        //second last

        public async Task<IActionResult> Checkout(string? address)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            string? userEmail = HttpContext.Session.GetString("UserEmail");
            string? userFirstName = HttpContext.Session.GetString("UserFirstName");
            string? userLastName = HttpContext.Session.GetString("UserLastName");
            string? contactNumber = HttpContext.Session.GetString("UserContact");

            if (userId == null || string.IsNullOrEmpty(userEmail))
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

            if (string.IsNullOrEmpty(address) || string.IsNullOrEmpty(contactNumber))
            {
                ViewBag.TotalAmount = cartItems.Sum(i => i.TotalPrice * i.Quantity);
                ViewBag.ContactNumber = contactNumber;
                return View(cartItems);
            }

            decimal totalAmount = cartItems.Sum(i => i.TotalPrice * i.Quantity);

            // Create the order before initiating payment
            var orderItems = cartItems.Select(cart => new OrderItem
            {
                ItemId = cart.ItemId,
                Quantity = cart.Quantity,
                Price = cart.TotalPrice
            }).ToList();

            var order = await _orderService.CreateOrderAsync(userId.Value, orderItems, address, contactNumber);
            if (order == null)
            {
                TempData["Error"] = "Failed to create order.";
                return RedirectToAction("ViewCart", "Cart");
            }

            // Generate payment URLs
            string returnUrl = Url.Action("PaymentSuccess", "Cart", new { orderId = order.Id }, Request.Scheme);
            string callbackUrl = Url.Action("PaymentWebhook", "Cart", null, Request.Scheme);

            Console.WriteLine($"🔗 Redirecting to Chapa...");

            var checkoutUrl = await _chapaService.InitiatePaymentAsync(
                totalAmount, userEmail, userFirstName, userLastName, contactNumber, order.Id.ToString(), returnUrl, callbackUrl
            );

            if (checkoutUrl != null)
            {
                return Redirect(checkoutUrl);
            }

            TempData["Error"] = "Payment initiation failed.";
            return RedirectToAction("ViewCart", "Cart");
        }





  

        public async Task<IActionResult> PaymentSuccess(string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                TempData["Error"] = "Invalid order ID.";
                return RedirectToAction("ViewCart", "Cart");
            }

            var order = await _orderService.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                TempData["Error"] = "Order not found.";
                return RedirectToAction("ViewCart", "Cart");
            }

            // Update order with payment status and date
            order.PaymentStatus = "Paid";
            order.OrderDate = DateTime.Now;

            // Save the updated order
            await _orderService.UpdateOrderAsync(order);

            // Notify admin and shop owners
            await _notificationService.NotifyAdmin(order.Id);  // Notify admin
            await _notificationService.NotifyShopOwners(order.Id);  // Notify shop owners

            // Optionally, clear the cart if needed (if not already done elsewhere)
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId != null)
            {
                await _cartService.ClearCartAsync(userId.Value);
            }

            // Display the payment success message
            ViewBag.OrderId = order.Id;
            ViewBag.TotalAmount = order.TotalAmount;
            ViewBag.PaymentStatus = order.PaymentStatus;
            ViewBag.PaymentDate = DateTime.Now;
            ViewBag.Message = "Payment successful! Your order will be processed soon.";

            return View("Receipt");  // Ensure you have a Receipt.cshtml view
        }


       




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



        public IActionResult ViewCart()
        {
            return View();
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
       
        [HttpPost]
        public async Task<IActionResult> PaymentWebhook([FromBody] ChapaWebhookResponse webhookData)
        {
            if (webhookData == null || string.IsNullOrEmpty(webhookData.TxRef))
            {
                return BadRequest("Invalid webhook data.");
            }

            var order = await _orderService.GetOrderByIdAsync(webhookData.TxRef);
            if (order == null)
            {
                return NotFound("Order not found.");
            }

            if (webhookData.Status == "success")  // Ensure status matches Chapa's success response
            {
                order.PaymentStatus = "Paid";  // ✅ Update payment status
                
                await _orderService.UpdateOrderAsync(order);
            }

            return Ok();
        }

        public async Task<IActionResult> OrderConfirmation()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Users");
            }

            var lastOrder = await _orderService.GetOrderDetailsAsync(userId.Value);
            if (lastOrder == null)
            {
                TempData["Error"] = "No order found.";
                return RedirectToAction("Index", "Home");
            }

            if (lastOrder.PaymentStatus != "Paid")
            {
                TempData["Error"] = "Payment not confirmed yet.";
                return RedirectToAction("ViewCart", "Cart");
            }

            ViewBag.SuccessMessage = "🎉 Thank you for shopping with us! Your order will arrive soon.";
            return View(lastOrder);
        }


        // Order Confirmation Page
        //public async Task<IActionResult> OrderConfirmation()

        //{
        //    int? userId = HttpContext.Session.GetInt32("UserId");
        //    if (userId == null)
        //    {
        //        return RedirectToAction("Login", "Users");
        //    }
        //    // Retrieve the last order details for the user, or handle accordingly
        //    var lastOrder = await _orderService.GetOrderDetailsAsync(userId.Value);

        //    if (lastOrder == null)
        //    {
        //        // Handle case where there is no order (maybe redirect or show a message)
        //        TempData["Error"] = "No order found.";
        //        return RedirectToAction("Index", "Home");
        //    }

        //    return View(lastOrder);
        //}

        public async Task<IActionResult> ClearCart()
    {
        int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
        if (userId == 0) return RedirectToAction("Login", "users");

        await _cartService.ClearCartAsync(userId);
        return RedirectToAction("Index");
    }
}
}
