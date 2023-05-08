using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SurucuKursu.Models;

namespace SurucuKursu.Controllers
{
    public class HaberResimController : Controller
    {
        private readonly SkContext _context;

        public HaberResimController()
        {
            _context = new SkContext();
        }

        // GET: HaberResim
        public async Task<IActionResult> Index()
        {
            var skContext = _context.HaberResims.Include(h => h.Parent);
            return View(await skContext.ToListAsync());
        }

        // GET: HaberResim/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.HaberResims == null)
            {
                return NotFound();
            }

            var haberResim = await _context.HaberResims
                .Include(h => h.Parent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (haberResim == null)
            {
                return NotFound();
            }

            return View(haberResim);
        }

        // GET: HaberResim/Create
        public IActionResult Create()
        {
            ViewData["ParentId"] = new SelectList(_context.Haberlers, "Id", "Id");
            return View();
        }

        // POST: HaberResim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParentId,Aciklama")] HaberResim haberResim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(haberResim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentId"] = new SelectList(_context.Haberlers, "Id", "Id", haberResim.ParentId);
            return View(haberResim);
        }

        // GET: HaberResim/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.HaberResims == null)
            {
                return NotFound();
            }

            var haberResim = await _context.HaberResims.FindAsync(id);
            if (haberResim == null)
            {
                return NotFound();
            }
            ViewData["ParentId"] = new SelectList(_context.Haberlers, "Id", "Id", haberResim.ParentId);
            return View(haberResim);
        }

        // POST: HaberResim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ParentId,Aciklama")] HaberResim haberResim)
        {
            if (id != haberResim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(haberResim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HaberResimExists(haberResim.Id))
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
            ViewData["ParentId"] = new SelectList(_context.Haberlers, "Id", "Id", haberResim.ParentId);
            return View(haberResim);
        }

        // GET: HaberResim/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.HaberResims == null)
            {
                return NotFound();
            }

            var haberResim = await _context.HaberResims
                .Include(h => h.Parent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (haberResim == null)
            {
                return NotFound();
            }

            return View(haberResim);
        }

        // POST: HaberResim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.HaberResims == null)
            {
                return Problem("Entity set 'SkContext.HaberResims'  is null.");
            }
            var haberResim = await _context.HaberResims.FindAsync(id);
            if (haberResim != null)
            {
                _context.HaberResims.Remove(haberResim);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HaberResimExists(long id)
        {
          return (_context.HaberResims?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
