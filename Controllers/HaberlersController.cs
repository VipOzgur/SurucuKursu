using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SurucuKursu.Models;

namespace SurucuKursu.Controllers
{
	[Authorize]
	public class HaberlersController : Controller
    {
        private readonly SkContext _context;

        public HaberlersController()
        {
            _context = new SkContext();
        }

        // GET: Haberlers
        public async Task<IActionResult> Index()
        {
              return _context.Haberlers != null ? 
                          View(await _context.Haberlers.OrderByDescending(x => x.Id).ToListAsync()) :
                          Problem("Entity set 'SkContext.Haberlers'  is null.");
        }

        // GET: Haberlers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Haberlers == null)
            {
                return NotFound();
            }

            var haberler = await _context.Haberlers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (haberler == null)
            {
                return NotFound();
            }

            return View(haberler);
        }

        // GET: Haberlers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Haberlers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Metin,Medya,Tarih")] Haberler haberler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(haberler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(haberler);
        }

        // GET: Haberlers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Haberlers == null)
            {
                return NotFound();
            }

            var haberler = await _context.Haberlers.FindAsync(id);
            if (haberler == null)
            {
                return NotFound();
            }
            return View(haberler);
        }

        // POST: Haberlers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Baslik,Metin,Medya,Tarih")] Haberler haberler)
        {
            if (id != haberler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(haberler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HaberlerExists(haberler.Id))
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
            return View(haberler);
        }

        // GET: Haberlers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Haberlers == null)
            {
                return NotFound();
            }

            var haberler = await _context.Haberlers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (haberler == null)
            {
                return NotFound();
            }

            return View(haberler);
        }

        // POST: Haberlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Haberlers == null)
            {
                return Problem("Entity set 'SkContext.Haberlers'  is null.");
            }
            var haberler = await _context.Haberlers.FindAsync(id);
            if (haberler != null)
            {
                _context.Haberlers.Remove(haberler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HaberlerExists(long id)
        {
          return (_context.Haberlers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
