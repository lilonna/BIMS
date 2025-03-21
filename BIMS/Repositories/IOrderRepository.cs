using BIMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<List<Order>> GetOrdersByUserIdAsync(int userId);
        Task<Order> GetOrderByIdAsync(string orderId);
    }
}
