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
	public class OnKayitsController : Controller
    {
        private readonly SkContext _context;

        public OnKayitsController()
        {
            _context = new SkContext();
        }

        // GET: OnKayits
        public async Task<IActionResult> Index()
        {
              return _context.OnKayits != null ? 
                          View(await _context.OnKayits.OrderByDescending(x => x.Id).ToListAsync()) :
                          Problem("Entity set 'SkContext.OnKayits'  is null.");
        }

        // GET: OnKayits/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.OnKayits == null)
            {
                return NotFound();
            }

            var onKayit = await _context.OnKayits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (onKayit == null)
            {
                return NotFound();
            }

            return View(onKayit);
        }

        // GET: OnKayits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OnKayits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Sayad,TelNo,Mail,Aciklama")] OnKayit onKayit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(onKayit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(onKayit);
        }

        // GET: OnKayits/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.OnKayits == null)
            {
                return NotFound();
            }

            var onKayit = await _context.OnKayits.FindAsync(id);
            if (onKayit == null)
            {
                return NotFound();
            }
            return View(onKayit);
        }

        // POST: OnKayits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Ad,Sayad,TelNo,Mail,Aciklama")] OnKayit onKayit)
        {
            if (id != onKayit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(onKayit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OnKayitExists(onKayit.Id))
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
            return View(onKayit);
        }

        // GET: OnKayits/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.OnKayits == null)
            {
                return NotFound();
            }

            var onKayit = await _context.OnKayits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (onKayit == null)
            {
                return NotFound();
            }

            return View(onKayit);
        }

        // POST: OnKayits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.OnKayits == null)
            {
                return Problem("Entity set 'SkContext.OnKayits'  is null.");
            }
            var onKayit = await _context.OnKayits.FindAsync(id);
            if (onKayit != null)
            {
                _context.OnKayits.Remove(onKayit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OnKayitExists(long id)
        {
          return (_context.OnKayits?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
