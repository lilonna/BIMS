using BIMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly BIMSContext _context;

        public AdminController(UserManager<User> userManager, BIMSContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        //public async Task<IActionResult> Index()
        //{
        //    // Get the logged-in admin user's ID
        //    var adminUser = await _userManager.GetUserAsync(User);
        //    if (adminUser == null)
        //    {
        //        TempData["ErrorMessage"] = "Admin user not found!";
        //        return RedirectToAction("Login", "Users"); // Redirect if not logged in

        //    }
        //    int adminUserId = adminUser.Id;

        //    // Fetch notifications for the admin user
        //    var notifications = await _context.Notifications
        //        .Where(n => n.UserId == adminUserId && !n.IsDeleted)
        //        .OrderByDescending(n => n.NotificationDate)
        //        .ToListAsync();

        //    return View(notifications);

        //}
        public async Task<IActionResult> Index()
        {
            // Retrieve user ID from session
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                TempData["ErrorMessage"] = "Session expired, please log in again!";
                return RedirectToAction("Login", "Users");
            }

            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                TempData["ErrorMessage"] = "User not found!";
                return RedirectToAction("Login", "Users");
            }

            // Check if user is an admin
            var roles = await _userManager.GetRolesAsync(user);
            if (!roles.Contains("Admin"))
            {
                TempData["ErrorMessage"] = "Access denied!";
                return RedirectToAction("Login", "Users");
            }

            // Fetch notifications for the admin user
            var notifications = await _context.Notifications
                .Where(n => n.UserId == user.Id && !n.IsDeleted)
                .OrderByDescending(n => n.NotificationDate)
                .ToListAsync();

            return View(notifications);
        }



        public async Task<IActionResult> MarkAsRead(int notificationId)
        {
            var notification = await _context.Notifications.FindAsync(notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeliveryPersonnel()
        {
            // Get users who are assigned to the "DeliveryPerson" role
            var deliveryPersonnel = (await _userManager.GetUsersInRoleAsync("DeliveryPerson")).ToList();
            if (deliveryPersonnel.Count == 0)
            {
                TempData["ErrorMessage"] = "No users found in the DeliveryPerson role!";
            }

            return View(deliveryPersonnel);
        }
        public async Task<IActionResult> ShopOwners()
        {
            // Get all users who own at least one shop
            var shopOwners = await _context.Users
                .Where(u => _context.Shops.Any(s => s.UserId == u.Id)) // Check if user owns a shop
                .ToListAsync();

            if (!shopOwners.Any())
            {
                TempData["ErrorMessage"] = "No shop owners found!";
            }

            return View(shopOwners);
        }



    }
}
