using BIMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BIMS.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;

        public AdminController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
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
