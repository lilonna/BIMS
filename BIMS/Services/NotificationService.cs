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

        public async Task NotifyAdminAndShopOwner(Order order)
        {



            var adminChat = new Chat
            {
                SenderId = 0, // Assuming 0 is Admin ID (use correct Admin ID here)
                ReceiverId = 1, // Assuming 1 is the Admin's User ID
                Message = $"New order placed! Order ID: {order.Id}",
                IsActive = true,
                IsDeleted = false,
                Date = DateOnly.FromDateTime(DateTime.UtcNow),
                ChatStatusId = 1 // Assuming 1 is the default Chat Status ID (adjust as necessary)
            };

            // Fetch the Shop ID from the first Order Item
            var item = order.OrderItems.First().Item;
            var shopId = item.ShopId;

            // Retrieve the Shop to get the Shop Owner's UserId
            var shop = await _context.Shops
                                      .Where(s => s.Id == shopId)
                                      .FirstOrDefaultAsync();

            // If the shop is found and the UserId exists, create the shop owner chat
            if (shop != null )

            {
                var shopOwnerChat = new Chat
                {
                    SenderId = 0, // Assuming 0 is Admin ID (use correct Admin ID here)
                    ReceiverId = shop.UserId,
                    Message = $"New order received for your item. Order ID: {order.Id}",
                    IsActive = true,
                    IsDeleted = false,
                    Date = DateOnly.FromDateTime(DateTime.UtcNow),
                    ChatStatusId = 1 // Assuming 1 is the default Chat Status ID (adjust as necessary)
                };

                await _context.Chats.AddRangeAsync(adminChat, shopOwnerChat);
                await _context.SaveChangesAsync();
            }
        }

    }
}
