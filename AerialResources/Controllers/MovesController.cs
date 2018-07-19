using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AerialResources.Data;
using AerialResources.Models;
using Microsoft.AspNetCore.Authorization;

namespace AerialResources.Controllers
{
    public class MovesController : Controller
    {
        private readonly AerialResourcesContext _context;

        public MovesController(AerialResourcesContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: Moves
        public async Task<IActionResult> Index()
        {
            return View(await _context.Move.ToListAsync());
        }
        [Authorize]

        // GET: Moves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var move = await _context.Move
                .SingleOrDefaultAsync(m => m.MoveID == id);
            if (move == null)
            {
                return NotFound();
            }

            return View(move);
        }
        [Authorize]
        // GET: Moves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Moves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MoveID,Name,Description,CourseID,VideoLink,PreReq")] Move move)
        {
            if (ModelState.IsValid)
            {
                _context.Add(move);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(move);
        }

        // GET: Moves/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var move = await _context.Move.SingleOrDefaultAsync(m => m.MoveID == id);
            if (move == null)
            {
                return NotFound();
            }
            return View(move);
        }

        // POST: Moves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MoveID,Name,Description,CourseID,VideoLink,PreReq")] Move move)
        {
            if (id != move.MoveID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(move);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoveExists(move.MoveID))
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
            return View(move);
        }

        // GET: Moves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var move = await _context.Move
                .SingleOrDefaultAsync(m => m.MoveID == id);
            if (move == null)
            {
                return NotFound();
            }

            return View(move);
        }

        // POST: Moves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var move = await _context.Move.SingleOrDefaultAsync(m => m.MoveID == id);
            _context.Move.Remove(move);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoveExists(int id)
        {
            return _context.Move.Any(e => e.MoveID == id);
        }
    }
}
