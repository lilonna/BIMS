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
    public class RoomsController : Controller
    {
        private readonly BIMSContext _context;

        public RoomsController(BIMSContext context)
        {
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            var bIMSContext = _context.Rooms.Include(r => r.Floor).Include(r => r.RoomStatus).Include(r => r.User);
            return View(await bIMSContext.ToListAsync());
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.Floor)
                .Include(r => r.RoomStatus)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            ViewData["FloorId"] = new SelectList(_context.Floors, "Id", "Name");
            ViewData["RoomStatusId"] = new SelectList(_context.RoomStatues, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,FloorId,UserId,RoomStatusId,SizeInm2,Width,Length,Description,IsActive,IsDeleted")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FloorId"] = new SelectList(_context.Floors, "Id", "Name", room.FloorId);
            ViewData["RoomStatusId"] = new SelectList(_context.RoomStatues, "Id", "Name", room.RoomStatusId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", room.UserId);
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["FloorId"] = new SelectList(_context.Floors, "Id", "Name", room.FloorId);
            ViewData["RoomStatusId"] = new SelectList(_context.RoomStatues, "Id", "Name", room.RoomStatusId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", room.UserId);
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,FloorId,UserId,RoomStatusId,SizeInm2,Width,Length,Description,IsActive,IsDeleted")] Room room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.Id))
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
            ViewData["FloorId"] = new SelectList(_context.Floors, "Id", "Name", room.FloorId);
            ViewData["RoomStatusId"] = new SelectList(_context.RoomStatues, "Id", "Name", room.RoomStatusId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", room.UserId);
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.Floor)
                .Include(r => r.RoomStatus)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }
    }
}
