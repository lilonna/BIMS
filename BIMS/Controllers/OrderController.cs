using BIMS.Models;
using BIMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BIMS.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        public async Task<IActionResult> PlaceOrder(List<OrderItem> items, string address, string contactNumber)
        {
            int? userId = HttpContext.Session.GetInt32("UserId"); 

            if (userId == null)
            {
                TempData["Error"] = "You must be logged in to place an order.";
                return RedirectToAction("Login", "Account"); 
            }

            var order = await _orderService.CreateOrderAsync(userId.Value, items, address, contactNumber);
            return RedirectToAction("OrderDetails", new { orderId = order.Id });
        }
        public async Task<IActionResult> MyOrders()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                TempData["Error"] = "You must be logged in to view your orders.";
                return RedirectToAction("Login", "Account"); 
            }
            var orders = await _orderService.GetUserOrdersAsync(userId.Value);
            return View(orders);
        }
        public async Task<IActionResult> OrderDetails(int orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}
