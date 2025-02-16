using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BIMS.Models;

namespace BIMS.Controllers
{
    public class ShopsController : Controller
    {
        private readonly BIMSContext _context;

        public ShopsController(BIMSContext context)
        {
            _context = context;
        }
      
    // GET: Shops

    public async Task<IActionResult> Index(int? cityId, int? locationId, int? businessAreaId, string searchItem, int page = 1, int pageSize = 12)
        {
            var shopsQuery = _context.Shops
                .Include(s => s.BusinessArea)
                .Include(s => s.ShopLocations)
                .ThenInclude(sl => sl.Room)
                .Include(s => s.Items).ThenInclude(s => s.ItemCategory)
                .AsQueryable();

            // Filter by city
            if (cityId.HasValue)
            {
                shopsQuery = shopsQuery.Where(s => s.ShopLocations
                    .Any(sl => sl.Room.Floor.Building.CityId == cityId));
            }
            // Filter Locations only if CityId is selected
            var locations = _context.Locations
                                    .Where(l => !cityId.HasValue || l.CityId == cityId)
                                    .ToList();

            // Filter by location
            if (locationId.HasValue)
            {
                shopsQuery = shopsQuery.Where(s => s.ShopLocations.Any(sl => sl.Room.Floor.Building.LocationId == locationId));
            }

            // Filter by business area
            if (businessAreaId.HasValue)
            {
                shopsQuery = shopsQuery.Where(s => s.BusinessAreaId == businessAreaId);
            }

            // Search for an item 
            if (!string.IsNullOrEmpty(searchItem))
            {
                shopsQuery = shopsQuery.Where(s => s.Items.Any(i => i.Name.Contains(searchItem)));
            }
            // Count the total shops (for pagination)
            var totalShops = await shopsQuery.CountAsync();

            // Fetch the current page of shops
            var filteredShops = await shopsQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
           
         
            // Pass the filters back to the view for pre-selection
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", cityId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name", locationId);
            ViewData["BusinessAreaId"] = new SelectList(_context.BusinessAreas, "Id", "Name", businessAreaId);
            // Pass pagination data
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling(totalShops / (double)pageSize);

            return View(filteredShops);
        }



        [HttpGet]
        public async Task<IActionResult> GetLocationsByCity(int? cityId)
        {
            if (!cityId.HasValue)
            {
                return Json(new List<object>());
            }

            var locations = await _context.Locations
                .Where(l => l.CityId == cityId)
                .Select(l => new { l.Id, l.Name })
                .ToListAsync();

            return Json(locations);
        }
        // GET: Shops/Details/5

        public async Task<IActionResult> Details(int? id, int? shopCityId, int? locationId, int? businessAreaId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = await _context.Shops
                .Include(s => s.BusinessArea)
                .Include(s => s.ShopLocations)
                .ThenInclude(sl => sl.Room)
                .ThenInclude(r => r.Floor)
                .ThenInclude(f => f.Building)
                .Include(s => s.Items).ThenInclude(s => s.ItemCategory)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (shop == null)
            {
                return NotFound();
            }

            // Set cityId if not passed as parameter
            shopCityId ??= shop.ShopLocations?.FirstOrDefault()?.Room?.Floor?.Building?.CityId;

            if (shopCityId == null)
            {
                Console.WriteLine("Shop CityId is null");
            }

            // Fetch related shops based on same BusinessArea and City
            var relatedShopsQuery = _context.Shops
                .Include(s => s.BusinessArea)
                .Include(s => s.ShopLocations)
                .ThenInclude(sl => sl.Room)
                .ThenInclude(r => r.Floor)
                .ThenInclude(f => f.Building)
                .ThenInclude(b => b.City)
                .Where(s => s.Id != id &&  // Exclude current shop
                            s.BusinessArea.Id == shop.BusinessArea.Id &&  // Same Business Area
                            s.ShopLocations.Any(sl => sl.Room.Floor.Building.CityId == shopCityId));// Same City

            var relatedShops = await relatedShopsQuery.ToListAsync();

            Console.WriteLine($"Related shops count: {relatedShops.Count}");

            // Pass related shops to the view
            ViewBag.RelatedShops = relatedShops;
            // Pass the filters back to the view for pre-selection
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", shopCityId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name", locationId);
            ViewData["BusinessAreaId"] = new SelectList(_context.BusinessAreas, "Id", "Name", businessAreaId);


            return View(shop);
        }


        // GET: Shops/Create
        public IActionResult Create(int?userId)
        {
            // Check if the user is logged in by verifying the session
            var loggedInUserId = HttpContext.Session.GetInt32("UserId");
            if (loggedInUserId == null)
            {
                TempData["ErrorMessage"] = "You are not logged in. Please log in to create a shop.";
                return RedirectToAction("Login", "Users"); 
            }

            //if (userId != null && userId != loggedInUserId)
            //{
            //    TempData["ErrorMessage"] = "Invalid session user ID.";
            //    return RedirectToAction("Login", "Users");
            //}

            // Ensure that the provided `userId` matches the logged-in user's ID
            if (userId != null && userId != loggedInUserId)
            {
                TempData["ErrorMessage"] = "You are not authorized to create a shop.";
                return RedirectToAction("Index", "Shops");
            }
            // Pass the logged-in user's ID to the View
            ViewData["UserId"] = loggedInUserId;

            ViewData["BusinessAreaId"] = new SelectList(_context.BusinessAreas, "Id", "Name");

            return View();
        }


        // POST: Shops/Create
      [HttpPost("UploadImage")]
        private async Task<string> UploadImage(IFormFile image)
        {
            try
            {
                if (image != null && image.Length > 0)
                {
                    // Define the path where the image will be saved
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                    // Ensure the directory exists
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // Create a unique file name
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

                    // Combine the path and file name
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    // Save the file
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(fileStream);
                    }

                    // Return the relative URL to the saved image
                    return $"/images/{fileName}";
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Image upload failed: {ex.Message}");
            }
            return null;
            
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UserId,BusinessAreaId,Description,IsActive,IsDeleted")] Shop shop, IFormFile image)
        {
             if (!ModelState.IsValid)
    


            {
                if (image != null)
                {
                    // Upload the image and get its URL
                    var imageUrl = await UploadImage(image);

                    // Save the URL to the shop model
                    shop.ImageUrl = imageUrl;
                }

                _context.Add(shop);
                await _context.SaveChangesAsync();
                
            }
            ViewData["BusinessAreaId"] = new SelectList(_context.BusinessAreas, "Id", "Name", shop.BusinessAreaId);
            return View(shop);
        }

        //has shop
        [HttpGet]
        public async Task<IActionResult> HasShop()
        {
            var loggedInUserId = HttpContext.Session.GetInt32("UserId");

            if (!loggedInUserId.HasValue)
            {
                return Json(new { hasShop = false });
            }
            int userId = loggedInUserId.Value;
            var hasShop = await _context.Shops.AnyAsync(s => s.UserId == userId && !s.IsDeleted);
            return Json(new { hasShop });
        }

        //shopdashboard
        [HttpGet("Shops/ShopDashboard/{shopId}")]
        public async Task<IActionResult> ShopDashboard(int shopId)
        {
            var loggedInUserId = HttpContext.Session.GetInt32("UserId");

            if (!loggedInUserId.HasValue)
            {
                TempData["ErrorMessage"] = "You are not logged in. Please log in to access this page.";
                return RedirectToAction("Login", "Users"); 
            }
            int userId = loggedInUserId.Value;

            // Fetch the shop details and ensure it belongs to the logged-in user
            var shop = await _context.Shops
                .Include(s => s.BusinessArea)
                .Include(s => s.Items).ThenInclude(s => s.ItemCategory)
                .FirstOrDefaultAsync(s => s.Id == shopId && s.UserId == userId);

            if (shop == null)
            {
                TempData["ErrorMessage"] = "Unauthorized access or shop not found.";
                return RedirectToAction("Index"); 
            }

           
            var itemCount = shop.Items.Count; // Count items
            ViewBag.ItemCount = itemCount;

            // Add any additional data for display in the dashboard
            ViewBag.ShopName = shop.Name;
            ViewBag.BusinessArea = shop.BusinessArea.Name;

            return View(shop);
        }



        // GET: Shops/Edit/5
        public async Task<IActionResult> Edit(int? id,int?userId){

            // Check if the user is logged in by verifying the session or authentication
            var loggedInUserId = HttpContext.Session.GetInt32("UserId");
            if (id == null)
            {
                return NotFound();
            }

            var shop = await _context.Shops.FindAsync(id);
            if (shop == null)
            {
                return NotFound();
            }
            ViewData["BusinessAreaId"] = new SelectList(_context.BusinessAreas, "Id", "Name", shop.BusinessAreaId);
            ViewData["UserId"] = userId;
    
            return View(shop);
        }

        // POST: Shops/Edit/5
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,UserId,BusinessAreaId,Description,IsActive,IsDeleted")] Shop shop)
        {
            if (id != shop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopExists(shop.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BusinessAreaId"] = new SelectList(_context.BusinessAreas, "Id", "Name", shop.BusinessAreaId);
            
            return View(shop);
        }




        // GET: Shops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            // Check if the user is logged in by verifying the session or authentication
            var loggedInUserId = HttpContext.Session.GetInt32("UserId");
            if (id == null)
            {
                return NotFound();
            }

            var shop = await _context.Shops
                .Include(s => s.BusinessArea)
                .Include(s => s.Items)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shop == null)
            {
                return NotFound();
            }

            return View(shop);
        }

        // POST: Shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shop = await _context.Shops.FindAsync(id);
            if (shop != null)
            {
                _context.Shops.Remove(shop);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopExists(int id)
        {
            return _context.Shops.Any(e => e.Id == id);
        }
    }
}
