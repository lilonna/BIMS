using System.Collections.Generic;
using System.Threading.Tasks;
using BIMS.Models;

namespace BIMS.Services
{
    public interface ICartService
    {
        Task AddToCartAsync(Cart cart);
        Task<List<Cart>> GetUserCartAsync(int userId);
        Task RemoveFromCartAsync(int cartId);
        Task ClearCartAsync(int userId);
        Task<int> GetCartCountAsync(int userId);
    }
}
