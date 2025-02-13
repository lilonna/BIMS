using BIMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BIMS.Services { 

    public interface IOrderService
    {
        Task<Order> PlaceOrderAsync(int userId, List<OrderItem> items);
        Task<List<Order>> GetUserOrdersAsync(int userId);
    }

}