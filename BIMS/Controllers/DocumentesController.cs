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
    public class DocumentesController : Controller
    {
        private readonly BIMSContext _context;

        public DocumentesController(BIMSContext context)
        {
            _context = context;
        }

        // GET: Documentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Documentes.ToListAsync());
        }

        // GET: Documentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documente = await _context.Documentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documente == null)
            {
                return NotFound();
            }

            return View(documente);
        }

        // GET: Documentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Documentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsActive,IsDeleted")] Documente documente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(documente);
        }

        // GET: Documentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documente = await _context.Documentes.FindAsync(id);
            if (documente == null)
            {
                return NotFound();
            }
            return View(documente);
        }

        // POST: Documentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IsActive,IsDeleted")] Documente documente)
        {
            if (id != documente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumenteExists(documente.Id))
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
            return View(documente);
        }

        // GET: Documentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documente = await _context.Documentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documente == null)
            {
                return NotFound();
            }

            return View(documente);
        }

        // POST: Documentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var documente = await _context.Documentes.FindAsync(id);
            if (documente != null)
            {
                _context.Documentes.Remove(documente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumenteExists(int id)
        {
            return _context.Documentes.Any(e => e.Id == id);
        }
    }
}
