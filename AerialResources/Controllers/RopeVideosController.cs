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
    public class RopeVideosController : Controller
    {
        private readonly AerialResourcesContext _context;

        public RopeVideosController(AerialResourcesContext context)
        {
            _context = context;
        }

        // GET: RopeVideos
        public async Task<IActionResult> Index()
        {
            return View(await _context.RopeVideos.ToListAsync());
        }

        // GET: RopeVideos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ropeVideos = await _context.RopeVideos
                .SingleOrDefaultAsync(m => m.VideoID == id);
            if (ropeVideos == null)
            {
                return NotFound();
            }

            return View(ropeVideos);
        }

        // GET: RopeVideos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RopeVideos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VideoID,Name,Url,Level,PreReqs,Description,IsActive")] RopeVideos ropeVideos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ropeVideos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ropeVideos);
        }

        // GET: RopeVideos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ropeVideos = await _context.RopeVideos.SingleOrDefaultAsync(m => m.VideoID == id);
            if (ropeVideos == null)
            {
                return NotFound();
            }
            return View(ropeVideos);
        }

        // POST: RopeVideos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VideoID,Name,Url,Level,PreReqs,Description,IsActive")] RopeVideos ropeVideos)
        {
            if (id != ropeVideos.VideoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ropeVideos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RopeVideosExists(ropeVideos.VideoID))
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
            return View(ropeVideos);
        }

        // GET: RopeVideos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ropeVideos = await _context.RopeVideos
                .SingleOrDefaultAsync(m => m.VideoID == id);
            if (ropeVideos == null)
            {
                return NotFound();
            }

            return View(ropeVideos);
        }

        // POST: RopeVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ropeVideos = await _context.RopeVideos.SingleOrDefaultAsync(m => m.VideoID == id);
            _context.RopeVideos.Remove(ropeVideos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RopeVideosExists(int id)
        {
            return _context.RopeVideos.Any(e => e.VideoID == id);
        }
    }
}
