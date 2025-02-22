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
    public class OwnersController : Controller
    {
        private readonly BIMSContext _context;

        public OwnersController(BIMSContext context)
        {
            _context = context;
        }

        // GET: Owners
        public async Task<IActionResult> Index()
        {
            var bIMSContext = _context.Owners/*.Include(o => o.Document)*/.Include(o => o.OwnershipType);
            return View(await bIMSContext.ToListAsync());
        }

        // GET: Owners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _context.Owners
                //.Include(o => o.Document)
                .Include(o => o.OwnershipType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // GET: Owners/Create
        [HttpGet]
        public IActionResult Create()
        {
            // Check if the user is logged in
            var loggedInUserId = HttpContext.Session.GetInt32("UserId");

            if (!loggedInUserId.HasValue) // Check if session contains user ID
            {
                TempData["ErrorMessage"] = "You are not logged in. Please log in to create a shop.";
                return RedirectToAction("Login", "Users"); // Redirect to login page
            }

            //int loggedUserId = loggedInUserId.Value; // Extract value safely

            //// Ensure that the provided `userId` matches the logged-in user's ID
            //if (userId.HasValue && userId != loggedUserId)
            //{
            //    TempData["ErrorMessage"] = "You are not authorized to create a shop for another user.";
            //    return RedirectToAction("Create", "Buildings");
            //}

            ViewData["DocumentId"] = new SelectList(_context.Documentes, "Id", "Id");
            ViewData["OwnershipTypeId"] = new SelectList(_context.OwnershipTypes, "Id", "Id");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,OwnershipTypeId,Tin,License,Verified,RegisteredDate,IsActive,IsDeleted")] Owner model, IFormFile LicenseImage)
        {
            var loggedInUserId = HttpContext.Session.GetInt32("UserId");
            if (!loggedInUserId.HasValue)
            {
                TempData["ErrorMessage"] = "Please log in first.";
                return RedirectToAction("Login", "Users");
            }
            var user = await _context.Users.FindAsync(loggedInUserId.Value);
            if (user == null) return NotFound();
            if (ModelState.IsValid)
            {
                if (LicenseImage != null)
                {
                    // Validate file type (allow only images)
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };
                    string fileExtension = Path.GetExtension(LicenseImage.FileName).ToLower();

                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        ModelState.AddModelError("", "Only image files (JPG, JPEG, PNG, WEBP) are allowed.");
                        ViewData["OwnershipTypeId"] = new SelectList(_context.OwnershipTypes, "Id", "Id", model.OwnershipTypeId);
                        return View(model);
                    }

                    // Generate a unique filename and store it in wwwroot/uploads/license_images
                    string fileName = Guid.NewGuid().ToString() + fileExtension;
                    string uploadPath = Path.Combine("wwwroot/images", fileName);

                    using (var stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        await LicenseImage.CopyToAsync(stream);
                    }

                    model.License = fileName; // Store only the image file name in DB
                }
                model.UserId = user.Id;
                model.FullName = $"{user.FirstName} {user.MiddleName} {user.LastName}";
                model.Verified = false; // Waiting for admin approval
                model.RegisteredDate = DateOnly.FromDateTime(DateTime.Now);
                model.IsActive = false;
                model.IsDeleted = false;

                _context.Owners.Add(model);
                await _context.SaveChangesAsync();

                HttpContext.Session.SetInt32("OwnerId", model.Id);

                //// Notify Admin via Notification Service
                //await _notificationService.SendNotification(1, "New owner registration request: " + model.FullName);

                TempData["SuccessMessage"] = "Your request has been submitted. Please wait for admin approval.";
                return RedirectToAction("Create", "Buildings");
            }

            ViewData["OwnershipTypeId"] = new SelectList(_context.OwnershipTypes, "Id", "Id", model.OwnershipTypeId);
            return View(model);
        }

        public IActionResult PendingApproval()
        {
            return View(); // Show "Waiting for admin approval" message
        }
        // GET: Owners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            //ViewData["DocumentId"] = new SelectList(_context.Documentes, "Id", "Id", owner.DocumentId);
            ViewData["OwnershipTypeId"] = new SelectList(_context.OwnershipTypes, "Id", "Id", owner.OwnershipTypeId);
            return View(owner);
        }

        // POST: Owners/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,OwnershipTypeId,Tin,DocumentId,Verified,RegisteredDate,IsActive,IsDeleted")] Owner owner)
        {
            if (id != owner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(owner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnerExists(owner.Id))
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
            //ViewData["DocumentId"] = new SelectList(_context.Documentes, "Id", "Id", owner.DocumentId);
            ViewData["OwnershipTypeId"] = new SelectList(_context.OwnershipTypes, "Id", "Id", owner.OwnershipTypeId);
            return View(owner);
        }

        // GET: Owners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _context.Owners
                //.Include(o => o.Document)
                .Include(o => o.OwnershipType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner != null)
            {
                _context.Owners.Remove(owner);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OwnerExists(int id)
        {
            return _context.Owners.Any(e => e.Id == id);
        }
    }
}
