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

        public async Task AddToCartAsync(Cart cart)
        {
            await _cartRepository.AddToCartAsync(cart);
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
        public async Task<int> GetCartCountAsync(int userId)  // Implement this method
        {
            return await _cartRepository.GetCartCountAsync(userId);  // Assuming repository has this method
        }
    }
}
