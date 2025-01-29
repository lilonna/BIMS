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
    public class BusinessAreasController : Controller
    {
        private readonly BIMSContext _context;

        public BusinessAreasController(BIMSContext context)
        {
            _context = context;
        }

        // GET: BusinessAreas
        public async Task<IActionResult> Index()
        {
            return View(await _context.BusinessAreas.ToListAsync());
        }

        // GET: BusinessAreas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessArea = await _context.BusinessAreas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (businessArea == null)
            {
                return NotFound();
            }

            return View(businessArea);
        }

        // GET: BusinessAreas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BusinessAreas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsActive,IsDeleted")] BusinessArea businessArea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(businessArea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(businessArea);
        }

        // GET: BusinessAreas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessArea = await _context.BusinessAreas.FindAsync(id);
            if (businessArea == null)
            {
                return NotFound();
            }
            return View(businessArea);
        }

        // POST: BusinessAreas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IsActive,IsDeleted")] BusinessArea businessArea)
        {
            if (id != businessArea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessArea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessAreaExists(businessArea.Id))
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
            return View(businessArea);
        }

        // GET: BusinessAreas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessArea = await _context.BusinessAreas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (businessArea == null)
            {
                return NotFound();
            }

            return View(businessArea);
        }

        // POST: BusinessAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var businessArea = await _context.BusinessAreas.FindAsync(id);
            if (businessArea != null)
            {
                _context.BusinessAreas.Remove(businessArea);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessAreaExists(int id)
        {
            return _context.BusinessAreas.Any(e => e.Id == id);
        }
    }
}
