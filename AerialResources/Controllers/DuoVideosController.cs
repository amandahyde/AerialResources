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
    public class DuoVideosController : Controller
    {
        private readonly AerialResourcesContext _context;

        public DuoVideosController(AerialResourcesContext context)
        {
            _context = context;
        }

        // GET: DuoVideos
        public async Task<IActionResult> Index()
        {
            return View(await _context.DuoVideos.ToListAsync());
        }

        // GET: DuoVideos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duoVideos = await _context.DuoVideos
                .SingleOrDefaultAsync(m => m.VideoID == id);
            if (duoVideos == null)
            {
                return NotFound();
            }

            return View(duoVideos);
        }

        // GET: DuoVideos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DuoVideos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VideoID,Name,Url,Level,PreReqs,Description,IsActive")] DuoVideos duoVideos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(duoVideos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(duoVideos);
        }

        // GET: DuoVideos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duoVideos = await _context.DuoVideos.SingleOrDefaultAsync(m => m.VideoID == id);
            if (duoVideos == null)
            {
                return NotFound();
            }
            return View(duoVideos);
        }

        // POST: DuoVideos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VideoID,Name,Url,Level,PreReqs,Description,IsActive")] DuoVideos duoVideos)
        {
            if (id != duoVideos.VideoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(duoVideos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuoVideosExists(duoVideos.VideoID))
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
            return View(duoVideos);
        }

        // GET: DuoVideos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duoVideos = await _context.DuoVideos
                .SingleOrDefaultAsync(m => m.VideoID == id);
            if (duoVideos == null)
            {
                return NotFound();
            }

            return View(duoVideos);
        }

        // POST: DuoVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var duoVideos = await _context.DuoVideos.SingleOrDefaultAsync(m => m.VideoID == id);
            _context.DuoVideos.Remove(duoVideos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuoVideosExists(int id)
        {
            return _context.DuoVideos.Any(e => e.VideoID == id);
        }
    }
}
