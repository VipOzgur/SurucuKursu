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
	public class EhliyetsController : Controller
    {
        private readonly SkContext _context;

        public EhliyetsController()
        {
            _context = new SkContext();
        }

        // GET: Ehliyets
        public async Task<IActionResult> Index()
        {
              return _context.Ehliyets != null ? 
                          View(await _context.Ehliyets.ToListAsync()) :
                          Problem("Entity set 'SkContext.Ehliyets'  is null.");
        }

        // GET: Ehliyets/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Ehliyets == null)
            {
                return NotFound();
            }

            var ehliyet = await _context.Ehliyets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ehliyet == null)
            {
                return NotFound();
            }

            return View(ehliyet);
        }

        // GET: Ehliyets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ehliyets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Ehliyet ehliyet)
        {
            if (ModelState.IsValid)
            {
                PublicClass publicClass = new PublicClass();
                ehliyet.Arac = publicClass.ImgToBase64(ehliyet.ResimFile);
                _context.Add(ehliyet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ehliyet);
        }

        // GET: Ehliyets/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Ehliyets == null)
            {
                return NotFound();
            }

            var ehliyet = await _context.Ehliyets.FindAsync(id);
            if (ehliyet == null)
            {
                return NotFound();
            }
            return View(ehliyet);
        }

        // POST: Ehliyets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Sinifi,Arac,Aciklama")] Ehliyet ehliyet)
        {
            if (id != ehliyet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ehliyet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EhliyetExists(ehliyet.Id))
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
            return View(ehliyet);
        }

        // GET: Ehliyets/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Ehliyets == null)
            {
                return NotFound();
            }

            var ehliyet = await _context.Ehliyets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ehliyet == null)
            {
                return NotFound();
            }

            return View(ehliyet);
        }

        // POST: Ehliyets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Ehliyets == null)
            {
                return Problem("Entity set 'SkContext.Ehliyets'  is null.");
            }
            var ehliyet = await _context.Ehliyets.FindAsync(id);
            if (ehliyet != null)
            {
                _context.Ehliyets.Remove(ehliyet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EhliyetExists(long id)
        {
          return (_context.Ehliyets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
