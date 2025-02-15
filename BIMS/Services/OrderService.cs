using BIMS.Models;
using BIMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIMS.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly BIMSContext _context;
        public OrderService(IOrderRepository orderRepository, BIMSContext context)
        {
            _orderRepository = orderRepository;
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(int userId, List<OrderItem> items)
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

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync(); // Save to generate OrderId

            // Add order items
            foreach (var item in items)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ItemId = item.ItemId,
                    Quantity = item.Quantity,
                    Price = item.Price
                };

                await _context.OrderItems.AddAsync(orderItem);
            }

            await _context.SaveChangesAsync(); // Save the order items to database

            return order;
        }

        public async Task<List<Order>> GetUserOrdersAsync(int userId)
        {
            return await _orderRepository.GetOrdersByUserIdAsync(userId);
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _orderRepository.GetOrderByIdAsync(orderId);
        }


        public async Task<Order> GetOrderDetailsAsync(int userId)
        {
            // Get the latest order for the user
            return await _context.Orders
                                 .Where(o => o.UserId == userId)
                                 .OrderByDescending(o => o.OrderDate)
                                 .FirstOrDefaultAsync(); // You can order by OrderDate or other relevant fields
        }

    }
}
