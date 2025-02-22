using BIMS.Models;
using BIMS.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly BIMSContext _context;
        private readonly INotificationService _notificationService;

        public AdminController(UserManager<User> userManager, BIMSContext context, INotificationService notificationService)
        {
            _userManager = userManager;
            _context = context;
            _notificationService = notificationService;
        }
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
            var pendingOwners = await _context.Owners
      .Where(o => !o.Verified) // Fetch only pending approvals
      .ToListAsync();

            return View(new Tuple<List<Notification>, List<Owner>>(notifications, pendingOwners));
        }

        public async Task<IActionResult> ApproveOwners()
        {
            var pendingOwners = await _context.Owners
                .Where(o => !o.Verified)
                .Include(o => o.User)
                .ToListAsync();
            return View(pendingOwners);
        }
        [HttpPost]
        public async Task<IActionResult> Approve(int id)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner == null) return NotFound();

            owner.Verified = true;
            owner.IsActive = true;

            var user = await _context.Users.FindAsync(owner.UserId);
            if (user != null)
            {
                user.OwnerId = owner.Id; // ✅ Upgrade User to Owner
            }

            // Save Approval Notification
            var notification = new Notification
            {
                UserId = owner.UserId,
                Message = "Congratulations! Your request has been approved.",
                IsRead = false,
                NotificationDate = DateTime.UtcNow
            };

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();

            return RedirectToAction("ApproveOwners");
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
    var shopOwners = await _context.Users
        .Where(u => _context.Shops.Any(s => s.UserId == u.Id))
        .Select(u => new ValueTuple<User, Shop>(
            u,
            _context.Shops.Where(s => s.UserId == u.Id).FirstOrDefault()
        ))
        .ToListAsync();

    return View(shopOwners);
}


    }
}
