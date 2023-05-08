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
    public class AracResimController : Controller
    {
        private readonly SkContext _context;

        public AracResimController()
        {
            _context = new SkContext();
        }

        // GET: AracResim
        public async Task<IActionResult> Index()
        {
              return _context.AracResims != null ? 
                          View(await _context.AracResims.ToListAsync()) :
                          Problem("Entity set 'SkContext.AracResims'  is null.");
        }

        // GET: AracResim/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.AracResims == null)
            {
                return NotFound();
            }

            var aracResim = await _context.AracResims
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aracResim == null)
            {
                return NotFound();
            }

            return View(aracResim);
        }

        // GET: AracResim/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AracResim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParentId,Resimler")] AracResim aracResim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aracResim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aracResim);
        }

        // GET: AracResim/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.AracResims == null)
            {
                return NotFound();
            }

            var aracResim = await _context.AracResims.FindAsync(id);
            if (aracResim == null)
            {
                return NotFound();
            }
            return View(aracResim);
        }

        // POST: AracResim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ParentId,Resimler")] AracResim aracResim)
        {
            if (id != aracResim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aracResim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AracResimExists(aracResim.Id))
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
            return View(aracResim);
        }

        // GET: AracResim/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.AracResims == null)
            {
                return NotFound();
            }

            var aracResim = await _context.AracResims
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aracResim == null)
            {
                return NotFound();
            }

            return View(aracResim);
        }

        // POST: AracResim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.AracResims == null)
            {
                return Problem("Entity set 'SkContext.AracResims'  is null.");
            }
            var aracResim = await _context.AracResims.FindAsync(id);
            if (aracResim != null)
            {
                _context.AracResims.Remove(aracResim);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AracResimExists(long id)
        {
          return (_context.AracResims?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
