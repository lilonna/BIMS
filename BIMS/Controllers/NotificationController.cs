using BIMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace BIMS.Controllers
{
    public class NotificationController : Controller
    {
        private readonly NotificationService _notificationService;
        public NotificationController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetUserNotifications()
        {
            var notifications = await _notificationService.GetUserNotifications();
            return Json(notifications); // Return notifications as JSON
        }

        [HttpPost]
        public async Task<IActionResult> MarkNotificationAsRead(int id)
        {
            await _notificationService.MarkAsRead(id);
            return Ok();
        }
    }
}
