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
    public class LyraVideosController : Controller
    {
        private readonly AerialResourcesContext _context;

        public LyraVideosController(AerialResourcesContext context)
        {
            _context = context;
        }

        // GET: LyraVideos
        public async Task<IActionResult> Index()
        {
            return View(await _context.LyraVideos.ToListAsync());
        }

        // GET: LyraVideos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lyraVideos = await _context.LyraVideos
                .SingleOrDefaultAsync(m => m.VideoID == id);
            if (lyraVideos == null)
            {
                return NotFound();
            }

            return View(lyraVideos);
        }

        // GET: LyraVideos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LyraVideos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VideoID,Name,Url,Level,PreReqs,Description,IsActive")] LyraVideos lyraVideos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lyraVideos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lyraVideos);
        }

        // GET: LyraVideos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lyraVideos = await _context.LyraVideos.SingleOrDefaultAsync(m => m.VideoID == id);
            if (lyraVideos == null)
            {
                return NotFound();
            }
            return View(lyraVideos);
        }

        // POST: LyraVideos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VideoID,Name,Url,Level,PreReqs,Description,IsActive")] LyraVideos lyraVideos)
        {
            if (id != lyraVideos.VideoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lyraVideos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LyraVideosExists(lyraVideos.VideoID))
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
            return View(lyraVideos);
        }

        // GET: LyraVideos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lyraVideos = await _context.LyraVideos
                .SingleOrDefaultAsync(m => m.VideoID == id);
            if (lyraVideos == null)
            {
                return NotFound();
            }

            return View(lyraVideos);
        }

        // POST: LyraVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lyraVideos = await _context.LyraVideos.SingleOrDefaultAsync(m => m.VideoID == id);
            _context.LyraVideos.Remove(lyraVideos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LyraVideosExists(int id)
        {
            return _context.LyraVideos.Any(e => e.VideoID == id);
        }
    }
}
