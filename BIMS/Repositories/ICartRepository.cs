using System.Collections.Generic;
using System.Threading.Tasks;
using BIMS.Models;

namespace BIMS.Repositories
{
    public interface ICartRepository
    {
        Task AddToCartAsync(Cart cart);
        Task<List<Cart>> GetUserCartAsync(int userId);
        Task RemoveFromCartAsync(int cartId);
        Task ClearCartAsync(int userId);
        Task<int> GetCartCountAsync(int userId);
    }
}
