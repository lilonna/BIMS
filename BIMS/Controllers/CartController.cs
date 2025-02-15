using BIMS.Services;
using Microsoft.AspNetCore.Mvc;
using BIMS.Models;
using Microsoft.AspNetCore.Http;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace BIMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart(int itemId, int quantity, decimal price)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return Unauthorized(new { message = "User not logged in" });
            }

            await _cartService.AddToCartAsync(userId.Value, itemId, quantity, price);
            return Ok(new { message = "Item added to cart" });
        }

        [HttpGet("my-cart")]
        public async Task<IActionResult> GetCart()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return Unauthorized(new { message = "User not logged in" });
            }

            var cartItems = await _cartService.GetUserCartAsync(userId.Value);
            return Ok(cartItems);
        }

        [HttpDelete("remove/{cartId}")]
        public async Task<IActionResult> RemoveFromCart(int cartId)
        {
            await _cartService.RemoveFromCartAsync(cartId);
            return Ok(new { message = "Item removed from cart" });
        }

        [HttpDelete("clear")]
        public async Task<IActionResult> ClearCart()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return Unauthorized(new { message = "User not logged in" });
            }

            await _cartService.ClearCartAsync(userId.Value);
            return Ok(new { message = "Cart cleared" });
        }
    }
}
