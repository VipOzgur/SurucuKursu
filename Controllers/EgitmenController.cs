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
    public class EgitmenController : Controller
    {
        private readonly SkContext _context;

        public EgitmenController()
        {
            _context = new SkContext();
        }

        // GET: Egitmen
        public async Task<IActionResult> Index()
        {
              return _context.Egitmenlers != null ? 
                          View(await _context.Egitmenlers.ToListAsync()) :
                          Problem("Entity set 'SkContext.Egitmenlers'  is null.");
        }

        // GET: Egitmen/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Egitmenlers == null)
            {
                return NotFound();
            }

            var egitmenler = await _context.Egitmenlers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (egitmenler == null)
            {
                return NotFound();
            }

            return View(egitmenler);
        }

        // GET: Egitmen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Egitmen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Soyad,Aciklama,Profil")] Egitmenler egitmenler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(egitmenler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(egitmenler);
        }

        // GET: Egitmen/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Egitmenlers == null)
            {
                return NotFound();
            }

            var egitmenler = await _context.Egitmenlers.FindAsync(id);
            if (egitmenler == null)
            {
                return NotFound();
            }
            return View(egitmenler);
        }

        // POST: Egitmen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Ad,Soyad,Aciklama,Profil")] Egitmenler egitmenler)
        {
            if (id != egitmenler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(egitmenler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EgitmenlerExists(egitmenler.Id))
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
            return View(egitmenler);
        }

        // GET: Egitmen/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Egitmenlers == null)
            {
                return NotFound();
            }

            var egitmenler = await _context.Egitmenlers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (egitmenler == null)
            {
                return NotFound();
            }

            return View(egitmenler);
        }

        // POST: Egitmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Egitmenlers == null)
            {
                return Problem("Entity set 'SkContext.Egitmenlers'  is null.");
            }
            var egitmenler = await _context.Egitmenlers.FindAsync(id);
            if (egitmenler != null)
            {
                _context.Egitmenlers.Remove(egitmenler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EgitmenlerExists(long id)
        {
          return (_context.Egitmenlers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
