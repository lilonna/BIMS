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
            var bIMSContext = _context.Owners.Include(o => o.Document).Include(o => o.OwnershipType);
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
                .Include(o => o.Document)
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
        public IActionResult Create(int? userId)
        {
            // Check if the user is logged in by verifying the session or authentication
            var loggedInUserId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(loggedInUserId))
            {
                TempData["ErrorMessage"] = "You are not logged in. Please log in to create a shop.";
                return RedirectToAction("Login", "Users"); // Redirect to login
            }
            // Convert loggedInUserId to integer
            if (!int.TryParse(loggedInUserId, out int loggedUserId))
            {
                TempData["ErrorMessage"] = "Invalid session user ID.";
                return RedirectToAction("Login", "Users");
            }
            // Ensure that the provided `userId` matches the logged-in user's ID
            if (userId != null && userId != loggedUserId)
            {
                TempData["ErrorMessage"] = "You are not authorized to create a shop for another user.";
                return RedirectToAction("Create", "Buildings");
            }

            ViewData["DocumentId"] = new SelectList(_context.Documentes, "Id", "Id");
            ViewData["OwnershipTypeId"] = new SelectList(_context.OwnershipTypes, "Id", "Id");
            return View();
        }
       
        // POST: Owners/Create
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,OwnershipTypeId,Tin,DocumentId,Verified,RegisteredDate,IsActive,IsDeleted")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(owner);
                await _context.SaveChangesAsync();
                HttpContext.Session.SetInt32("OwnerId", owner.Id);

                return RedirectToAction("Create", "Buildings");
            }
           
            ViewData["DocumentId"] = new SelectList(_context.Documentes, "Id", "Id", owner.DocumentId);
            ViewData["OwnershipTypeId"] = new SelectList(_context.OwnershipTypes, "Id", "Id", owner.OwnershipTypeId);
            return View(owner);
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
            ViewData["DocumentId"] = new SelectList(_context.Documentes, "Id", "Id", owner.DocumentId);
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
            ViewData["DocumentId"] = new SelectList(_context.Documentes, "Id", "Id", owner.DocumentId);
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
                .Include(o => o.Document)
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
