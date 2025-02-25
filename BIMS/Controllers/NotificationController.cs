using BIMS.Models;
using BIMS.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BIMS.Controllers
{
    [Route("Notification")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly BIMSContext _context;
        private readonly UserManager<User> _userManager;

        public NotificationController(UserManager<User> userManager, BIMSContext context, INotificationService notificationService)
        {
            _notificationService = notificationService;
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetUserNotifications()
        {
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

            var notifications = await _context.Notifications
                .Where(n => n.UserId == userId && !n.IsRead)
                .OrderByDescending(n => n.NotificationDate)
                .ToListAsync();

            return View(notifications);  // ✅ Ensure this returns a LIST, not a single object!
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


        //[HttpPost]
        //public async Task<IActionResult> MarkNotificationAsRead(int id)
        //{
        //    await _notificationService.MarkAsRead(id);
        //    return Ok();
        //}
    }
}
