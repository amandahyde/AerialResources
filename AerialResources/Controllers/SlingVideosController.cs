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
    public class SlingVideosController : Controller
    {
        private readonly AerialResourcesContext _context;

        public SlingVideosController(AerialResourcesContext context)
        {
            _context = context;
        }

        // GET: SlingVideos
        public async Task<IActionResult> Index()
        {
            return View(await _context.SlingVideos.ToListAsync());
        }

        // GET: SlingVideos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slingVideos = await _context.SlingVideos
                .SingleOrDefaultAsync(m => m.VideoID == id);
            if (slingVideos == null)
            {
                return NotFound();
            }

            return View(slingVideos);
        }

        // GET: SlingVideos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SlingVideos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VideoID,Name,Url,Level,PreReqs,Description,IsActive")] SlingVideos slingVideos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slingVideos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slingVideos);
        }

        // GET: SlingVideos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slingVideos = await _context.SlingVideos.SingleOrDefaultAsync(m => m.VideoID == id);
            if (slingVideos == null)
            {
                return NotFound();
            }
            return View(slingVideos);
        }

        // POST: SlingVideos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VideoID,Name,Url,Level,PreReqs,Description,IsActive")] SlingVideos slingVideos)
        {
            if (id != slingVideos.VideoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slingVideos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlingVideosExists(slingVideos.VideoID))
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
            return View(slingVideos);
        }

        // GET: SlingVideos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slingVideos = await _context.SlingVideos
                .SingleOrDefaultAsync(m => m.VideoID == id);
            if (slingVideos == null)
            {
                return NotFound();
            }

            return View(slingVideos);
        }

        // POST: SlingVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slingVideos = await _context.SlingVideos.SingleOrDefaultAsync(m => m.VideoID == id);
            _context.SlingVideos.Remove(slingVideos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlingVideosExists(int id)
        {
            return _context.SlingVideos.Any(e => e.VideoID == id);
        }
    }
}
