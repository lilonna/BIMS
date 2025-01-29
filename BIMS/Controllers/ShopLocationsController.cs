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
    public class ShopLocationsController : Controller
    {
        private readonly BIMSContext _context;

        public ShopLocationsController(BIMSContext context)
        {
            _context = context;
        }

        // GET: ShopLocations
        public async Task<IActionResult> Index()
        {
            var bIMSContext = _context.ShopLocations.Include(s => s.Room).Include(s => s.Shop);
            return View(await bIMSContext.ToListAsync());
        }

        // GET: ShopLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopLocation = await _context.ShopLocations
                .Include(s => s.Room)
                .Include(s => s.Shop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopLocation == null)
            {
                return NotFound();
            }

            return View(shopLocation);
        }

        // GET: ShopLocations/Create
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name");
            ViewData["ShopId"] = new SelectList(_context.Shops, "Id", "Name");
            return View();
        }

        // POST: ShopLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,RoomId,IsActive,IsDeleted,ShopId,CreatedDate")] ShopLocation shopLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", shopLocation.RoomId);
            ViewData["ShopId"] = new SelectList(_context.Shops, "Id", "Name", shopLocation.ShopId);
            return View(shopLocation);
        }

        // GET: ShopLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopLocation = await _context.ShopLocations.FindAsync(id);
            if (shopLocation == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", shopLocation.RoomId);
            ViewData["ShopId"] = new SelectList(_context.Shops, "Id", "Name", shopLocation.ShopId);
            return View(shopLocation);
        }

        // POST: ShopLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,RoomId,IsActive,IsDeleted,ShopId,CreatedDate")] ShopLocation shopLocation)
        {
            if (id != shopLocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopLocationExists(shopLocation.Id))
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
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", shopLocation.RoomId);
            ViewData["ShopId"] = new SelectList(_context.Shops, "Id", "Name", shopLocation.ShopId);
            return View(shopLocation);
        }

        // GET: ShopLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopLocation = await _context.ShopLocations
                .Include(s => s.Room)
                .Include(s => s.Shop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopLocation == null)
            {
                return NotFound();
            }

            return View(shopLocation);
        }

        // POST: ShopLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopLocation = await _context.ShopLocations.FindAsync(id);
            if (shopLocation != null)
            {
                _context.ShopLocations.Remove(shopLocation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopLocationExists(int id)
        {
            return _context.ShopLocations.Any(e => e.Id == id);
        }
    }
}
