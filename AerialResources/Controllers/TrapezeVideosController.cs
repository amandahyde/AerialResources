using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AerialResources.Data;
using AerialResources.Models;

namespace AerialResources.Controllers
{
    public class TrapezeVideosController : Controller
    {
        private readonly AerialResourcesContext _context;

        public TrapezeVideosController(AerialResourcesContext context)
        {
            _context = context;
        }

        // GET: TrapezeVideos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrapezeVideos.ToListAsync());
        }

        //Video Library
        public async Task<IActionResult> Library()
        {
            return View(await _context.TrapezeVideos.ToListAsync());
        }

        // GET: TrapezeVideos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trapezeVideos = await _context.TrapezeVideos
                .SingleOrDefaultAsync(m => m.VideoID == id);
            if (trapezeVideos == null)
            {
                return NotFound();
            }

            return View(trapezeVideos);
        }

        // GET: TrapezeVideos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrapezeVideos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VideoID,Name,Url,Level,PreReqs,Description,IsActive")] TrapezeVideos trapezeVideos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trapezeVideos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trapezeVideos);
        }

        // GET: TrapezeVideos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trapezeVideos = await _context.TrapezeVideos.SingleOrDefaultAsync(m => m.VideoID == id);
            if (trapezeVideos == null)
            {
                return NotFound();
            }
            return View(trapezeVideos);
        }

        // POST: TrapezeVideos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VideoID,Name,Url,Level,PreReqs,Description,IsActive")] TrapezeVideos trapezeVideos)
        {
            if (id != trapezeVideos.VideoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trapezeVideos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrapezeVideosExists(trapezeVideos.VideoID))
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
            return View(trapezeVideos);
        }

        // GET: TrapezeVideos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trapezeVideos = await _context.TrapezeVideos
                .SingleOrDefaultAsync(m => m.VideoID == id);
            if (trapezeVideos == null)
            {
                return NotFound();
            }

            return View(trapezeVideos);
        }

        // POST: TrapezeVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trapezeVideos = await _context.TrapezeVideos.SingleOrDefaultAsync(m => m.VideoID == id);
            _context.TrapezeVideos.Remove(trapezeVideos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrapezeVideosExists(int id)
        {
            return _context.TrapezeVideos.Any(e => e.VideoID == id);
        }
    }
}
