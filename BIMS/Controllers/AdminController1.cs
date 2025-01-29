using Microsoft.AspNetCore.Mvc;

namespace BIMS.Controllers
{
    public class AdminController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
