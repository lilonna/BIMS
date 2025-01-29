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
    public class RoomStatuesController : Controller
    {
        private readonly BIMSContext _context;

        public RoomStatuesController(BIMSContext context)
        {
            _context = context;
        }

        // GET: RoomStatues
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoomStatues.ToListAsync());
        }

        // GET: RoomStatues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomStatue = await _context.RoomStatues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomStatue == null)
            {
                return NotFound();
            }

            return View(roomStatue);
        }

        // GET: RoomStatues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomStatues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsActive,IsDeleted")] RoomStatue roomStatue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomStatue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomStatue);
        }

        // GET: RoomStatues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomStatue = await _context.RoomStatues.FindAsync(id);
            if (roomStatue == null)
            {
                return NotFound();
            }
            return View(roomStatue);
        }

        // POST: RoomStatues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IsActive,IsDeleted")] RoomStatue roomStatue)
        {
            if (id != roomStatue.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomStatue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomStatueExists(roomStatue.Id))
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
            return View(roomStatue);
        }

        // GET: RoomStatues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomStatue = await _context.RoomStatues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomStatue == null)
            {
                return NotFound();
            }

            return View(roomStatue);
        }

        // POST: RoomStatues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomStatue = await _context.RoomStatues.FindAsync(id);
            if (roomStatue != null)
            {
                _context.RoomStatues.Remove(roomStatue);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomStatueExists(int id)
        {
            return _context.RoomStatues.Any(e => e.Id == id);
        }
    }
}
