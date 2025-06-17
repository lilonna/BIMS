using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BIMS.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace BIMS.Controllers
{
    public class ItemsController : Controller
    {
        private readonly BIMSContext _context;
        private readonly Cloudinary _cloudinary;

        public ItemsController(BIMSContext context, Cloudinary cloudinary)
        {
            _context = context;
            _cloudinary = cloudinary;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            var bIMSContext = _context.Items.Include(i => i.ItemCategory);
               
            return View(await bIMSContext.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await _context.Items
                .Include(i => i.ItemCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create(int? shopId)
        {

            if (!shopId.HasValue)
            {
                TempData["ErrorMessage"] = "Shop ID is required to add a product.";
                return RedirectToAction("Index", "Shops");
            }
            ViewData["ItemCategoryId"] = new SelectList(_context.ItemCategories, "Id", "Name");
            ViewData["ShopId"] = shopId;

            return View();
        }

        // POST: Items/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ItemCategoryId,ShopId,Price,IsAvailable,IsActive,IsDeleted")] Item item , IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null && Image.Length > 0)
                {
                    await using var stream = Image.OpenReadStream();
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(Image.FileName, stream),
                        Folder = "item-images"
                    };

                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                    item.ImagePath = uploadResult.SecureUrl.ToString();
                }


                _context.Add(item);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Product created successfully!";
                return RedirectToAction("ShopDashboard", "Shops", new { shopId = item.ShopId });
            }
            ViewData["ItemCategoryId"] = new SelectList(_context.ItemCategories, "Id", "Name", item.ItemCategoryId);
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id,int? shopId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["ItemCategoryId"] = new SelectList(_context.ItemCategories, "Id", "Name", item.ItemCategoryId);
            ViewData["ShopId"] = shopId;
            return View(item);
        }

        // POST: Items/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ItemCategoryId,ShopId,Price,IsAvailable,IsActive,IsDeleted")] Item item, IFormFile Image)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    var existingItem = await _context.Items.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
                    if (existingItem == null)
                    {
                        return NotFound();
                    }

                    if (Image != null && Image.Length > 0)
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                        Directory.CreateDirectory(uploadsFolder);
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
                        var filePath = Path.Combine(uploadsFolder, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await Image.CopyToAsync(stream);
                        }

                        if (!string.IsNullOrEmpty(existingItem.ImagePath))
                        {
                            var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", existingItem.ImagePath.TrimStart('/'));
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }

                        item.ImagePath = $"/images/{fileName}";
                    }
                    else
                    {
                        item.ImagePath = existingItem.ImagePath;
                    }


                  
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ShopDashboard", "Shops", new { shopId = item.ShopId });
            }

            ViewData["ItemCategoryId"] = new SelectList(_context.ItemCategories, "Id", "Name", item.ItemCategoryId);
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.ItemCategory)
               

                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }
        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("ShopDashboard", "Shops", new { shopId = item.ShopId });
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
