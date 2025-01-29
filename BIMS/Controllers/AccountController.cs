using Microsoft.AspNetCore.Mvc;

namespace BIMS.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string username,string password)
        {


            HttpContext.Session.SetString("username", username);
            HttpContext.Session.SetString("password", password);
            return RedirectToAction("Index" ,"Home");
        }


        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();

            // Set TempData to display a toast message
            TempData["LogoutSuccess"] = "You have successfully logged out!";

            return RedirectToAction("Index", "Home");
        }
    }
}
