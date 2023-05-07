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
    public class CikmisSorularsController : Controller
    {
        private readonly SkContext _context;

        public CikmisSorularsController()
        {
            _context = new SkContext();
        }

        // GET: CikmisSorulars
        public async Task<IActionResult> Index()
        {
              return _context.CikmisSorulars != null ? 
                          View(await _context.CikmisSorulars.ToListAsync()) :
                          Problem("Entity set 'SkContext.CikmisSorulars'  is null.");
        }

        // GET: CikmisSorulars/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.CikmisSorulars == null)
            {
                return NotFound();
            }

            var cikmisSorular = await _context.CikmisSorulars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cikmisSorular == null)
            {
                return NotFound();
            }

            return View(cikmisSorular);
        }

        // GET: CikmisSorulars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CikmisSorulars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Url")] CikmisSorular cikmisSorular)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cikmisSorular);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cikmisSorular);
        }

        // GET: CikmisSorulars/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.CikmisSorulars == null)
            {
                return NotFound();
            }

            var cikmisSorular = await _context.CikmisSorulars.FindAsync(id);
            if (cikmisSorular == null)
            {
                return NotFound();
            }
            return View(cikmisSorular);
        }

        // POST: CikmisSorulars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Baslik,Url")] CikmisSorular cikmisSorular)
        {
            if (id != cikmisSorular.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cikmisSorular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CikmisSorularExists(cikmisSorular.Id))
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
            return View(cikmisSorular);
        }

        // GET: CikmisSorulars/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.CikmisSorulars == null)
            {
                return NotFound();
            }

            var cikmisSorular = await _context.CikmisSorulars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cikmisSorular == null)
            {
                return NotFound();
            }

            return View(cikmisSorular);
        }

        // POST: CikmisSorulars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.CikmisSorulars == null)
            {
                return Problem("Entity set 'SkContext.CikmisSorulars'  is null.");
            }
            var cikmisSorular = await _context.CikmisSorulars.FindAsync(id);
            if (cikmisSorular != null)
            {
                _context.CikmisSorulars.Remove(cikmisSorular);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CikmisSorularExists(long id)
        {
          return (_context.CikmisSorulars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
