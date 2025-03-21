using BIMS.Models;
using BIMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly BIMSContext _context;
        private readonly ChapaService _chapaService;

        public OrderController(IOrderService orderService, BIMSContext context, ChapaService chapaService)
        {
            _orderService = orderService;
            _chapaService = chapaService;
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> PlaceOrder(List<OrderItem> items, string address, string contactNumber)
        {
            int? userId = HttpContext.Session.GetInt32("UserId"); 

            if (userId == null)
            {
                TempData["Error"] = "You must be logged in to place an order.";
                return RedirectToAction("Login", "Users"); 
            }

            var order = await _orderService.CreateOrderAsync(userId.Value, items, address, contactNumber);
            return RedirectToAction("OrderDetails", new { orderId = order.Id });
        }


        [HttpPost]
        public async Task<IActionResult> ConfirmDelivery(string orderId, string shopOwnerBankAccount, string bankCode)
        {
            if (!int.TryParse(orderId, out int parsedOrderId))
            {
                return BadRequest("Invalid order ID format.");
            }

            var order = _context.Orders.FirstOrDefault(o => o.Id == parsedOrderId);
            if (order == null)
            {
                return NotFound("Order not found");
            }

            // ✅ Mark order as delivered
            order.Status = "Delivered";
            _context.SaveChanges();

            // ✅ Send payout to shop owner
            bool payoutSuccess = await _chapaService.SendPayout(shopOwnerBankAccount, bankCode, order.TotalAmount.ToString(), "Payment for delivered order");

            if (payoutSuccess)
            {
                return Ok("Payout successful");
            }
            else
            {
                return BadRequest("Payout failed");
            }
        }


        public async Task<IActionResult> MyOrders()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                TempData["Error"] = "You must be logged in to view your orders.";
                return RedirectToAction("Login", "Users"); 
            }
            var orders = await _orderService.GetUserOrdersAsync(userId.Value);
            return View(orders);
        }
        public async Task<IActionResult> OrderDetails(string orderId)
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
