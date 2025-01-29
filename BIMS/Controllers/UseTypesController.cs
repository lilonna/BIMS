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
    public class UseTypesController : Controller
    {
        private readonly BIMSContext _context;

        public UseTypesController(BIMSContext context)
        {
            _context = context;
        }

        // GET: UseTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.UseTypes.ToListAsync());
        }

        // GET: UseTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var useType = await _context.UseTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (useType == null)
            {
                return NotFound();
            }

            return View(useType);
        }

        // GET: UseTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UseTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,IsActive,IsDeleted")] UseType useType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(useType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(useType);
        }

        // GET: UseTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var useType = await _context.UseTypes.FindAsync(id);
            if (useType == null)
            {
                return NotFound();
            }
            return View(useType);
        }

        // POST: UseTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,IsActive,IsDeleted")] UseType useType)
        {
            if (id != useType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(useType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UseTypeExists(useType.Id))
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
            return View(useType);
        }

        // GET: UseTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var useType = await _context.UseTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (useType == null)
            {
                return NotFound();
            }

            return View(useType);
        }

        // POST: UseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var useType = await _context.UseTypes.FindAsync(id);
            if (useType != null)
            {
                _context.UseTypes.Remove(useType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UseTypeExists(int id)
        {
            return _context.UseTypes.Any(e => e.Id == id);
        }
    }
}
