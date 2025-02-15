
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

using BIMS.Models;

namespace BIMS.Repositories
{
    public class CartRepository
    {
        private readonly BIMSContext _context;

        public CartRepository(BIMSContext context)
        {
            _context = context;
        }

        public async Task AddToCartAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cart>> GetUserCartAsync(int userId)
        {
            return await _context.Carts
                .Include(c => c.Item)
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }

        public async Task RemoveFromCartAsync(int cartId)
        {
            var cartItem = await _context.Carts.FindAsync(cartId);
            if (cartItem != null)
            {
                _context.Carts.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ClearCartAsync(int userId)
        {
            var cartItems = _context.Carts.Where(c => c.UserId == userId);
            _context.Carts.RemoveRange(cartItems);
            await _context.SaveChangesAsync();
        }
        public async Task<int> GetCartCountAsync(int userId)  // Implement this method
        {
            return await _context.Carts.Where(c => c.UserId == userId).CountAsync();
        }
    }
}
