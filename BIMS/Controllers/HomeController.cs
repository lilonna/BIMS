using BIMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Cryptography;

namespace BIMS.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BIMSContext _contextt;
        public HomeController(BIMSContext context, ILogger<HomeController> logger) : base(context)
        {
            _logger = logger;
            _contextt = context;
        }

        public IActionResult Index()
        {
            var shops = _contextt.Shops.OrderBy(s => s.Id).Take(8).ToList(); // Fetch first 5 shops
        

            ViewBag.Shops = shops;
          
            var items = _contextt.Items.Include(i => i.ItemCategory).OrderBy(i => i.Id).Take(8).ToList();
            ViewBag.Items = items ?? new List<Item>(); // Ensure it's never null


            // Best Sellers: Example - Select top 5 most purchased items
            ViewBag.BestSellers = _context.Items.Include(i => i.ItemCategory)
                .OrderByDescending(i => i.SalesCount) // Assuming you have SalesCount
                .Take(5)
                .ToList();

            // On Sale Items: Example - Select items with a discount
            ViewBag.OnSale = _context.Items.Include(i => i.ItemCategory)
                .Where(i => i.DiscountPrice < i.Price) // Assuming you have a DiscountPrice field
                .ToList();

            return View();
        }


        [HttpPost]
        public IActionResult SendMessage(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                // You could log, email, or save the message here
                TempData["SuccessMessage"] = "Your message has been sent successfully!";
                return RedirectToAction("Contact");
            }

            TempData["ErrorMessage"] = "Please fill out the form correctly.";
            return View("Contact", model);
        }

        public IActionResult conatctus()
        {
            return View();
        }
        public IActionResult Asking()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
