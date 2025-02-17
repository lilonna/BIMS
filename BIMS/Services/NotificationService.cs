using BIMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Services
{
    public class NotificationService : INotificationService
    {
        private readonly BIMSContext _context;

        public NotificationService(BIMSContext context)
        {
            _context = context;
        }

        public async Task NotifyAdmin(Order order)
        {
            var adminChat = new Chat
            {
                SenderId = 0, // Assuming 0 is Admin ID (update as needed)
                ReceiverId = 1, // Assuming 1 is Admin's User ID
                Message = $"New order placed! Order ID: {order.Id}",
                IsActive = true,
                IsDeleted = false,
                Date = DateOnly.FromDateTime(DateTime.UtcNow),
                ChatStatusId = 1 // Adjust as needed
            };

            await _context.Chats.AddAsync(adminChat);
            await _context.SaveChangesAsync();
        }

        public async Task NotifyShopOwner(Order order)
        {
            var item = order.OrderItems.FirstOrDefault();
            if (item != null)
            {
                var shop = await _context.Shops.FirstOrDefaultAsync(s => s.Id == item.Item.ShopId);

                if (shop != null)
                {
                    var shopOwnerChat = new Chat
                    {
                        SenderId = 0, // Assuming 0 is Admin ID (update as needed)
                        ReceiverId = shop.UserId,
                        Message = $"New order received for your item. Order ID: {order.Id}",
                        IsActive = true,
                        IsDeleted = false,
                        Date = DateOnly.FromDateTime(DateTime.UtcNow),
                        ChatStatusId = 1 // Adjust as needed
                    };

                    await _context.Chats.AddAsync(shopOwnerChat);
                    await _context.SaveChangesAsync();
                }
            }
        }


    }
}
