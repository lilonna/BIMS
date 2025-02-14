using System.Collections.Generic;
using System.Threading.Tasks;
using BIMS.Models;

namespace BIMS.Services
{
    public interface ICartService
    {
        Task AddToCartAsync(int userId, int itemId, int quantity, decimal price);
        Task<List<Cart>> GetUserCartAsync(int userId);
        Task RemoveFromCartAsync(int cartId);
        Task ClearCartAsync(int userId);
    }
}
