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
    public class SilksVideosController : Controller
    {
        private readonly AerialResourcesContext _context;

        public SilksVideosController(AerialResourcesContext context)
        {
            _context = context;
        }

        // GET: SilksVideos
        public async Task<IActionResult> Index()
        {
            return View(await _context.SilksVideos.ToListAsync());
        }

        //Library
        public async Task<IActionResult> Library()
        {
            return View(await _context.SilksVideos.ToListAsync());
        }

        // GET: SilksVideos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var silksVideos = await _context.SilksVideos
                .SingleOrDefaultAsync(m => m.VideoID == id);
            if (silksVideos == null)
            {
                return NotFound();
            }

            return View(silksVideos);
        }

        // GET: SilksVideos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SilksVideos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VideoID,Name,Url,Level,PreReqs,Description,IsActive")] SilksVideos silksVideos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(silksVideos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(silksVideos);
        }

        // GET: SilksVideos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var silksVideos = await _context.SilksVideos.SingleOrDefaultAsync(m => m.VideoID == id);
            if (silksVideos == null)
            {
                return NotFound();
            }
            return View(silksVideos);
        }

        // POST: SilksVideos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VideoID,Name,Url,Level,PreReqs,Description,IsActive")] SilksVideos silksVideos)
        {
            if (id != silksVideos.VideoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(silksVideos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SilksVideosExists(silksVideos.VideoID))
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
            return View(silksVideos);
        }

        // GET: SilksVideos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var silksVideos = await _context.SilksVideos
                .SingleOrDefaultAsync(m => m.VideoID == id);
            if (silksVideos == null)
            {
                return NotFound();
            }

            return View(silksVideos);
        }

        // POST: SilksVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var silksVideos = await _context.SilksVideos.SingleOrDefaultAsync(m => m.VideoID == id);
            _context.SilksVideos.Remove(silksVideos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SilksVideosExists(int id)
        {
            return _context.SilksVideos.Any(e => e.VideoID == id);
        }
    }
}
