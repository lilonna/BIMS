using BIMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BIMS.Services { 

    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(int userId, List<OrderItem> items, string address, string contactNumber);
        Task<List<Order>> GetUserOrdersAsync(int userId);
        Task<Order> GetOrderByIdAsync(string orderId);
        Task<Order> GetOrderByTransactionRef(string transactionRef);
        Task<bool> UpdateOrderAsync(Order order);
        Task<Order> GetOrderDetailsAsync(int userId);
    }

}