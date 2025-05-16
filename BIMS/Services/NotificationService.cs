using BIMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
        public async Task NotifyAdminOfOwnerRequest(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return;

            var adminEmail = _configuration["AdminCredentials:Email"];
            var adminUser = await _userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null) return;

            var notification = new Notification
            {
                UserId = adminUser.Id,
                Message = $"User {user.FirstName} {user.LastName} has requested to become an owner. Please review.",
                IsRead = false,
                IsDeleted = false,
                NotificationDate = DateTime.UtcNow,
                NotificationTypeId = 1,
                NotificationStatusId = 2
            };
            Console.WriteLine($"NotificationStatusId before save: {notification.NotificationStatusId}");

            await _context.Notifications.AddAsync(notification);
            var saved = await _context.SaveChangesAsync();
            Console.WriteLine($"SaveChangesAsync result: {saved}");
        }

        public async Task NotifyUserOfApproval(int userId)
        {
            if (userId <= 0)
            {
                Console.WriteLine("Invalid user ID.");
                return;
            }
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            var notification = new Notification
            {
                UserId = userId,
                Message = "Congratulations! Your request has been approved. You can create a shop now .",
                IsRead = false,
                IsDeleted = false,
                NotificationDate = DateTime.UtcNow,
                NotificationTypeId = 2,
                NotificationStatusId = 3
            };

            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        public async Task NotifyAdmin(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item) // Ensure Item details are loaded
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                Console.WriteLine($"Order with ID {orderId} not found.");
                return;
            }

            // Get admin's email from appsettings.json
            var adminEmail = _configuration["AdminCredentials:Email"];
            var adminPassword = _configuration["AdminCredentials:Password"];
            if (string.IsNullOrEmpty(adminEmail) || string.IsNullOrEmpty(adminPassword))
            {
                Console.WriteLine("Admin email is missing in appsettings.json!");
                return;
            }
            // Check if the admin user exists in the database
            var adminUser = await _userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                Console.WriteLine("Admin not found. Creating a new admin.");

                // Create new admin user without hashing password (just for initial creation)
                adminUser = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Admin",
                    MiddleName="ayy",// You can set other values as needed
                    LastName = "Admin",
                    PhoneNumber = "0000000000", // Default phone number
                    IsActive = true,
                    GenderId=1,
                    IsDeleted = false,
                    CreatedDate = DateOnly.FromDateTime(DateTime.Now),
                    Password = adminPassword, // No hash here for initial creation
                     SecurityStamp = Guid.NewGuid().ToString()
                };

                // Create the new admin user
                // Directly save the user to the database (bypassing Identity's password hashing)
                _context.Users.Add(adminUser);
                await _context.SaveChangesAsync();

                await _userManager.AddToRoleAsync(adminUser, "Admin");

                Console.WriteLine("Admin user created successfully without password hashing!");
            }

        

            // Find the admin user by email and select only their integer ID
            var adminUserId = await _context.Users
                .Where(u => u.Email == adminEmail)
                .Select(u => u.Id)  // Select only the integer ID
                .FirstOrDefaultAsync();

            if (adminUserId == 0) // Since int defaults to 0 if no result is found
            {
                Console.WriteLine($"Admin user with email {adminEmail} not found in UserManager!");
                return;
            }

            Console.WriteLine($"Admin found: {adminUserId}, Email: {adminEmail}");
            var orderDetails = string.Join(", ", order.OrderItems.Select(oi => $"{oi.Item.Name} (x{oi.Quantity})"));

            var adminNotification = new Notification
            {
                UserId = adminUserId, // Use the filtered admin's User ID
                Message = $"New order placed! Order ID: {order.Id}. Items: {orderDetails}.Address: {order.ShippingAddress}",
                IsRead = false,
                IsDeleted = false,
                NotificationDate = DateTime.UtcNow,
                NotificationTypeId = 1, // Adjust based on NotificationType table
                NotificationStatusId = 1 // Adjust based on NotificationStatus table
            };

            await _context.Notifications.AddAsync(adminNotification);
            var saved = await _context.SaveChangesAsync();

            Console.WriteLine($"SaveChangesAsync result: {saved}");
        }


        public async Task NotifyShopOwners(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item) // Ensure Item details are loaded
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null || order.OrderItems == null || !order.OrderItems.Any())
            {
                Console.WriteLine($"Order with ID {orderId} not found or has no items.");
                return;
            }

            // Group items by shop
            var itemsByShop = order.OrderItems
                .Where(oi => oi.Item != null)
                .GroupBy(oi => oi.Item.ShopId)
                .ToList();

            foreach (var shopGroup in itemsByShop)
            {
                int shopId = shopGroup.Key;
                var shop = await _context.Shops.FirstOrDefaultAsync(s => s.Id == shopId);

                if (shop != null)
                {
                    var itemDetails = string.Join(", ", shopGroup.Select(oi => $"{oi.Item.Name} (Qty: {oi.Quantity})"));

                    var shopOwnerNotification = new Notification
                    {
                        UserId = shop.UserId, // Shop Owner's User ID
                        Message = $"New order received! Order ID: {order.Id}. Items: {itemDetails}. ",
                        IsRead = false,
                        IsDeleted = false,
                        NotificationDate = DateTime.UtcNow,
                        NotificationTypeId = 2, // Adjust based on NotificationType table
                        NotificationStatusId = 1 // Adjust based on NotificationStatus table
                    };

                    await _context.Notifications.AddAsync(shopOwnerNotification);
                }
            }

            await _context.SaveChangesAsync(); // Save all notifications at once
        }
        public async Task MarkAsRead(int notificationId)
        {
            var notification = await _context.Notifications.FindAsync(notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                _context.Update(notification);
                await _context.SaveChangesAsync();
            }
        }
    }
}
