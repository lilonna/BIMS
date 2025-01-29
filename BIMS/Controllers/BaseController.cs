using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using BIMS.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Controllers
{
    public class BaseController : Controller
    {
        protected readonly BIMSContext _context;

        public BaseController(BIMSContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Check if user is logged in
            var userIdString = HttpContext.Session.GetString("UserId");
            if (int.TryParse(userIdString, out int userId))
            {
                // Fetch shops owned by the logged-in user
                var userShops = _context.Shops
                    .Where(shop => shop.UserId == userId) 
                    .ToList();
                // Fetch buildings associated with the logged-in user
                var userBuildings = _context.Buildings
                    .Where(building => building.UserId == userId) // Adjust UserId field if necessary
                    .ToList();

                // Populate ViewData only if the user has shops
                if (userShops.Any())
                {
                    ViewData["Shops"] = userShops;
                    ViewData["HasShops"] = true; // Flag to indicate the user has shops
                }
                else
                {
                    ViewData["Shops"] = null;
                    ViewData["HasShops"] = false;
                }
                // Populate ViewData for buildings
                if (userBuildings.Any())
                {
                    ViewData["Buildings"] = userBuildings;
                    ViewData["HasBuildings"] = true;
                }
                else
                {
                    ViewData["Buildings"] = null;
                    ViewData["HasBuildings"] = false;
                }
            }
            else
            {
                // User is not logged in; reset ViewData
                ViewData["Shops"] = null;
                ViewData["HasShops"] = false;
                ViewData["Buildings"] = null;
                ViewData["HasBuildings"] = false;
            }

            base.OnActionExecuting(context);
        }

    }
}


