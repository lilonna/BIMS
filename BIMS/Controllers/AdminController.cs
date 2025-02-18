using BIMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Index()
        {
            // Get the logged-in admin user's ID
            var adminUser = await _userManager.GetUserAsync(User);
            if (adminUser == null)
            {
                TempData["ErrorMessage"] = "Admin user not found!";
                return RedirectToAction("Login", "Account"); // Redirect if not logged in
            }
            return View();
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


    }
}
