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
    public class BuildingTypesController : Controller
    {
        private readonly BIMSContext _context;

        public BuildingTypesController(BIMSContext context)
        {
            _context = context;
        }

        // GET: BuildingTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.BuildingTypes.ToListAsync());
        }

        // GET: BuildingTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingType = await _context.BuildingTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingType == null)
            {
                return NotFound();
            }

            return View(buildingType);
        }

        // GET: BuildingTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BuildingTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsActive,IsDeleted")] BuildingType buildingType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buildingType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buildingType);
        }

        // GET: BuildingTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingType = await _context.BuildingTypes.FindAsync(id);
            if (buildingType == null)
            {
                return NotFound();
            }
            return View(buildingType);
        }

        // POST: BuildingTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IsActive,IsDeleted")] BuildingType buildingType)
        {
            if (id != buildingType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buildingType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingTypeExists(buildingType.Id))
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
            return View(buildingType);
        }

        // GET: BuildingTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingType = await _context.BuildingTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingType == null)
            {
                return NotFound();
            }

            return View(buildingType);
        }

        // POST: BuildingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buildingType = await _context.BuildingTypes.FindAsync(id);
            if (buildingType != null)
            {
                _context.BuildingTypes.Remove(buildingType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingTypeExists(int id)
        {
            return _context.BuildingTypes.Any(e => e.Id == id);
        }
    }
}
