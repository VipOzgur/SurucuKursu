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
    public class HarclarsController : Controller
    {
        private readonly SkContext _context;

        public HarclarsController()
        {
            _context = new SkContext();
        }

        // GET: Harclars
        public async Task<IActionResult> Index()
        {
              return _context.Harclars != null ? 
                          View(await _context.Harclars.ToListAsync()) :
                          Problem("Entity set 'SkContext.Harclars'  is null.");
        }

        // GET: Harclars/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Harclars == null)
            {
                return NotFound();
            }

            var harclar = await _context.Harclars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (harclar == null)
            {
                return NotFound();
            }

            return View(harclar);
        }

        // GET: Harclars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Harclars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Belge,Ucret,KagitBedeli,VakifBedeli")] Harclar harclar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(harclar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(harclar);
        }

        // GET: Harclars/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Harclars == null)
            {
                return NotFound();
            }

            var harclar = await _context.Harclars.FindAsync(id);
            if (harclar == null)
            {
                return NotFound();
            }
            return View(harclar);
        }

        // POST: Harclars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Belge,Ucret,KagitBedeli,VakifBedeli")] Harclar harclar)
        {
            if (id != harclar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(harclar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HarclarExists(harclar.Id))
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
            return View(harclar);
        }

        // GET: Harclars/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Harclars == null)
            {
                return NotFound();
            }

            var harclar = await _context.Harclars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (harclar == null)
            {
                return NotFound();
            }

            return View(harclar);
        }

        // POST: Harclars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Harclars == null)
            {
                return Problem("Entity set 'SkContext.Harclars'  is null.");
            }
            var harclar = await _context.Harclars.FindAsync(id);
            if (harclar != null)
            {
                _context.Harclars.Remove(harclar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HarclarExists(long id)
        {
          return (_context.Harclars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
