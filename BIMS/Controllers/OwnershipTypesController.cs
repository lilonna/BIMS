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
    public class OwnershipTypesController : Controller
    {
        private readonly BIMSContext _context;

        public OwnershipTypesController(BIMSContext context)
        {
            _context = context;
        }

        // GET: OwnershipTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.OwnershipTypes.ToListAsync());
        }

        // GET: OwnershipTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownershipType = await _context.OwnershipTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ownershipType == null)
            {
                return NotFound();
            }

            return View(ownershipType);
        }

        // GET: OwnershipTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OwnershipTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,IsActive,IsDeleted")] OwnershipType ownershipType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ownershipType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ownershipType);
        }

        // GET: OwnershipTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownershipType = await _context.OwnershipTypes.FindAsync(id);
            if (ownershipType == null)
            {
                return NotFound();
            }
            return View(ownershipType);
        }

        // POST: OwnershipTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,IsActive,IsDeleted")] OwnershipType ownershipType)
        {
            if (id != ownershipType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ownershipType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnershipTypeExists(ownershipType.Id))
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
            return View(ownershipType);
        }

        // GET: OwnershipTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownershipType = await _context.OwnershipTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ownershipType == null)
            {
                return NotFound();
            }

            return View(ownershipType);
        }

        // POST: OwnershipTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ownershipType = await _context.OwnershipTypes.FindAsync(id);
            if (ownershipType != null)
            {
                _context.OwnershipTypes.Remove(ownershipType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OwnershipTypeExists(int id)
        {
            return _context.OwnershipTypes.Any(e => e.Id == id);
        }
    }
}
