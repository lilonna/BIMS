using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BIMS.Models;
using System.Security.Claims;
using Microsoft.CodeAnalysis.Elfie.Model.Structures;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BIMS.Controllers
{
    public class BuildingsController : Controller
    {
        private readonly BIMSContext _context;

        public BuildingsController(BIMSContext context)
        {
            _context = context;
        }

        // GET: Buildings
        public async Task<IActionResult> Index()
        {
            var bIMSContext = _context.Buildings
                .Include(b => b.BuildingType)
                .Include(b => b.City)
                .Include(b => b.Location)
                .Include(b => b.Owner)
                .Include(b => b.OwnershipType)
                .Include(b => b.User).
                Include(b => b.UseType);
             
            return View(await bIMSContext.ToListAsync());
        }

       


        // GET: Buildings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var building = await _context.Buildings
                .Include(b => b.BuildingType)
                .Include(b => b.City)
                .Include(b => b.Location)
                .Include(b => b.Owner)
                .Include(b => b.OwnershipType)
                .Include(b => b.User)
                .Include(b => b.UseType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (building == null)
            {
                return NotFound();
            }

            return View(building);
        }

        // GET: Buildings/Create
        public IActionResult Create()

        {
                  // Check if the user is logged in by verifying the session or authentication
            var loggedInUserId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(loggedInUserId))
            {
                TempData["ErrorMessage"] = "You are not logged in. Please log in to create a building.";
                return RedirectToAction("Login", "Users"); // Redirect to login
            }
            ViewData["BuildingTypeId"] = new SelectList(_context.BuildingTypes, "Id", "Name");
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name");
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "FullName");
            ViewData["OwnershipTypeId"] = new SelectList(_context.OwnershipTypes, "Id", "Name");
            ViewData["UserId"] = loggedInUserId;
            ViewData["UseTypeId"] = new SelectList(_context.UseTypes, "Id", "Name");
            return View();
        }

        // POST: Buildings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UseTypeId,UserId,CityId,LocationId,Name,Description,ConstractionYear,NumberOfFloor,BuildingTypeId,OwnershipTypeId,OwnerId,IsActive,IsDeleted")] Building building)
        {
          
            if (ModelState.IsValid)
            {
                _context.Add(building);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            ViewData["BuildingTypeId"] = new SelectList(_context.BuildingTypes, "Id", "Name", building.BuildingTypeId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", building.CityId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name", building.LocationId);
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Name", building.OwnerId);
            ViewData["OwnershipTypeId"] = new SelectList(_context.OwnershipTypes, "Id", "Name", building.OwnershipTypeId);
            ViewData["UseTypeId"] = new SelectList(_context.UseTypes, "Id", "Name", building.UseTypeId);
            return View(building);
        }


        public async Task<IActionResult> BuildingDashboard(int id)
        {
            var loggedInUserId = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(loggedInUserId) || !int.TryParse(loggedInUserId, out int userId))
            {
                TempData["ErrorMessage"] = "You are not logged in. Please log in to access this page.";
                return RedirectToAction("Login", "Users"); // Redirect to login page
            }

            var building = await _context.Buildings.FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);

            if (building == null)
            {
                TempData["ErrorMessage"] = "Unauthorized access or building not found.";
                return RedirectToAction("Index", "Home"); // Prevent unauthorized access
            }

            return View(building);
        }

        //has building
        [HttpGet]
        public async Task<IActionResult> HasBuilding()
        {
            var loggedInUserId = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(loggedInUserId) || !int.TryParse(loggedInUserId, out int userId))
            {
                return Json(new { hasBuilding = false });
            }

            var hasBuilding = await _context.Buildings.AnyAsync(s => s.UserId == userId && !s.IsDeleted);
            return Json(new { hasBuilding });
        }
        
        
        // GET: Buildings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            // Check if the user is logged in by verifying the session or authentication
            var loggedInUserId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(loggedInUserId))
            {
                TempData["ErrorMessage"] = "You are not logged in. Please log in to create a building.";
                return RedirectToAction("Login", "Users"); // Redirect to login
            }

            if (id == null)
            {
                return NotFound();
            }

            var building = await _context.Buildings.FindAsync(id);
            if (building == null)
            {
                return NotFound();
            }
            ViewData["BuildingTypeId"] = new SelectList(_context.BuildingTypes, "Id", "Name", building.BuildingTypeId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", building.CityId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name", building.LocationId);
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Name", building.OwnerId);
            ViewData["OwnershipTypeId"] = new SelectList(_context.OwnershipTypes, "Id", "Name", building.OwnershipTypeId);
            ViewData["UserId"] = loggedInUserId;
            ViewData["UseTypeId"] = new SelectList(_context.UseTypes, "Id", "Name", building.UseTypeId);
            return View(building);
        }
       

        // POST: Buildings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UseTypeId,UserId,CityId,LocationId,Name,Description,ConstractionYear,NumberOfFloor,BuildingTypeId,OwnershipTypeId,OwnerId,IsActive,IsDeleted")] Building building)
        {
            if (id != building.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(building);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingExists(building.Id))
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
            ViewData["BuildingTypeId"] = new SelectList(_context.BuildingTypes, "Id", "Name", building.BuildingTypeId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", building.CityId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name", building.LocationId);
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Name", building.OwnerId);
            ViewData["OwnershipTypeId"] = new SelectList(_context.OwnershipTypes, "Id", "Name", building.OwnershipTypeId);
            ViewData["UseTypeId"] = new SelectList(_context.UseTypes, "Id", "Name", building.UseTypeId);
            return View(building);
        }

        // GET: Buildings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var building = await _context.Buildings
                .Include(b => b.BuildingType)
                .Include(b => b.City)
                .Include(b => b.Location)
                .Include(b => b.Owner)
                .Include(b => b.OwnershipType)
                .Include(b => b.User)
                .Include(b => b.UseType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (building == null)
            {
                return NotFound();
            }

            return View(building);
        }

        // POST: Buildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var building = await _context.Buildings.FindAsync(id);
            if (building != null)
            {
                _context.Buildings.Remove(building);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingExists(int id)
        {
            return _context.Buildings.Any(e => e.Id == id);
        }
    }
}
