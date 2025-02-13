using BIMS.Models;
using BIMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIMS.Services { 

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order> PlaceOrderAsync(int userId, List<OrderItem> items)
    {
        var totalAmount = items.Sum(i => i.Price * i.Quantity);
        var order = new Order
        {
            UserId = userId,
            OrderDate = DateTime.UtcNow,
            TotalAmount = totalAmount,
            Status = "Pending",
            PaymentStatus = "Unpaid"
        };

        return await _orderRepository.CreateOrderAsync(order);
    }

    public async Task<List<Order>> GetUserOrdersAsync(int userId)
    {
        return await _orderRepository.GetOrdersByUserIdAsync(userId);
    }
}
}
