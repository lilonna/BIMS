using BIMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Services
{
    public class NotificationService : INotificationService
    {
        private readonly BIMSContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public NotificationService(BIMSContext context, UserManager<User> userManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;

        }

        public async Task NotifyAdmin(Order order)
        {
            // Get admin's UserId from appsettings.json
            var adminEmail = _configuration["AdminCredentials:Email"];
            var adminUser = await _userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                throw new Exception("Admin user not found.");
            }


            var adminNotification = new Notification
            {
                UserId = adminUser.Id, // Admin's User ID
                Message = $"New order placed! Order ID: {order.Id}",
                IsRead = false, // Notification is unread by default
                IsDeleted = false, // Active notification
                NotificationDate = DateTime.UtcNow,
                NotificationTypeId = 1, // Adjust based on your NotificationType table
                NotificationStatusId = 1 // Adjust based on your NotificationStatus table
            };

            await _context.Notifications.AddAsync(adminNotification);
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
                    var shopOwnerNotification = new Notification
                    {
                        UserId = shop.UserId, // Shop Owner's User ID
                        Message = $"New order received for your item. Order ID: {order.Id}",
                        IsRead = false, // Notification is unread by default
                        IsDeleted = false, // Active notification
                        NotificationDate = DateTime.UtcNow,
                        NotificationTypeId = 2, // Adjust based on your NotificationType table
                        NotificationStatusId = 1 // Adjust based on your NotificationStatus table
                    };

                    await _context.Notifications.AddAsync(shopOwnerNotification);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
