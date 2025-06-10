using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BIMS.Models;
using BIMS.Services;
using CloudinaryDotNet;

namespace BIMS.Controllers
{
    public class ShopsController : Controller
    {
        private readonly BIMSContext _context;
        private readonly INotificationService _notificationService;
        private readonly Cloudinary _cloudinary;

        public ShopsController(BIMSContext context, INotificationService notificationService, Cloudinary cloudinary)
        {
            _context = context;
            _notificationService = notificationService;
            _cloudinary = cloudinary;
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


        private async Task<string> UploadImage(IFormFile image)
        {
            if (image == null || image.Length == 0)
                return null;

            try
            {
                using (var stream = image.OpenReadStream())
                {
                    var uploadParams = new CloudinaryDotNet.Actions.ImageUploadParams
                    {
                        File = new FileDescription(image.FileName, stream),
                        Folder = "shop_images",
                        UseFilename = true,
                        UniqueFilename = true,
                        Overwrite = false
                    };

                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                    if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return uploadResult.SecureUrl.ToString();
                    }
                    else
                    {
                        // Log and surface the error
                        var errorMessage = $"Cloudinary upload failed: {uploadResult.Error?.Message}";
                        Console.WriteLine(errorMessage);
                        throw new Exception(errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                // Re-throw for UI display
                throw new Exception($"Image upload error: {ex.Message}");
            }
        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UserId,BusinessAreaId,Description,IsActive,IsDeleted")] Shop shop, IFormFile image)
        {
            try
            {
                if (image != null)
                {
                    var imageUrl = await UploadImage(image);
                    shop.ImageUrl = imageUrl;

                    // Manually remove the validation error for ImageUrl (since it now has value)
                    ModelState.Remove(nameof(shop.ImageUrl));
                }
                else
                {
                    ModelState.AddModelError("ImageUrl", "Image is required.");
                }

                if (ModelState.IsValid)
                {
                    _context.Add(shop);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred while uploading the image: {ex.Message}");
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

            var shop = await _context.Shops
                .Include(s => s.BusinessArea)
                .Include(s => s.Items).ThenInclude(s => s.ItemCategory)
                .FirstOrDefaultAsync(s => s.Id == shopId && s.UserId == userId);

            if (shop == null)
            {
                TempData["ErrorMessage"] = "Unauthorized access or shop not found.";
                return RedirectToAction("Index");
            }

            // Fetch notifications
            var notifications = await _context.Notifications
                .Where(n => n.UserId == userId && !n.IsDeleted)
                .OrderByDescending(n => n.NotificationDate)
                .ToListAsync();

            ViewBag.Notifications = notifications;  //  Assigning notifications to ViewBag

            ViewBag.ItemCount = shop.Items.Count;
            ViewBag.ShopName = shop.Name;
            ViewBag.BusinessArea = shop.BusinessArea.Name;

            return View(shop);
        }




        // GET: Shops/Edit/5
        public async Task<IActionResult> Edit(int? id,int?userId){

         
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,UserId,BusinessAreaId,Description,IsActive,IsDeleted")] Shop shop, IFormFile image)
        {
            if (id != shop.Id)
            {
                return NotFound();
            }

            var existingShop = await _context.Shops.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
            if (existingShop == null)
            {
                return NotFound();
            }

            try
            {
                // If new image is uploaded, replace the old one
                if (image != null && image.Length > 0)
                {
                    var newImageUrl = await UploadImage(image);
                    shop.ImageUrl = newImageUrl;
                }
                else
                {
                    // Retain the existing image URL
                    shop.ImageUrl = existingShop.ImageUrl;
                }

                if (ModelState.IsValid)
                {
                    _context.Update(shop);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
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
