using BIMS.Models;
using BIMS.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BIMS.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task AddToCartAsync(int userId, int itemId, int quantity, decimal price)
        {
            var cartItem = new Cart
            {
                UserId = userId,
                ItemId = itemId,
                Quantity = quantity,
                TotalPrice = price
            };
            await _cartRepository.AddToCartAsync(cartItem);
        }

        public async Task<List<Cart>> GetUserCartAsync(int userId)
        {
            return await _cartRepository.GetUserCartAsync(userId);
        }

        public async Task RemoveFromCartAsync(int cartId)
        {
            await _cartRepository.RemoveFromCartAsync(cartId);
        }

        public async Task ClearCartAsync(int userId)
        {
            await _cartRepository.ClearCartAsync(userId);
        }
    }
}
