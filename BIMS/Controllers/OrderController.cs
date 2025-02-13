using BIMS.Models;
using Microsoft.AspNetCore.Mvc;
using BIMS.Services;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BIMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("place")]
        public async Task<IActionResult> PlaceOrder([FromBody] List<OrderItem> items)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");  // Retrieve User ID from session

            if (userId == null)
            {
                return Unauthorized(new { message = "User not authenticated" });
            }

            var order = await _orderService.PlaceOrderAsync(userId.Value, items);
            return Ok(order);
        }

        [HttpGet("my-orders")]
        public async Task<IActionResult> GetUserOrders()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");  // Retrieve User ID from session

            if (userId == null)
            {
                return Unauthorized(new { message = "User not authenticated" });
            }

            var orders = await _orderService.GetUserOrdersAsync(userId.Value);
            return Ok(orders);
        }
    }
}

