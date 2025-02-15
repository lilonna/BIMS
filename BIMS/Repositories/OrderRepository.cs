using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BIMS.Models;
using BIMS.Repositories;
using Microsoft.EntityFrameworkCore;


namespace BIMS.Repositories
{

    public class OrderRepository : IOrderRepository
    {
        private readonly BIMSContext _context;

        public OrderRepository(BIMSContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _context.Orders.Where(o => o.UserId == userId).ToListAsync();
        }
        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }
    }
}
