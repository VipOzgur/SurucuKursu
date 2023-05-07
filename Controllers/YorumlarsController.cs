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
    public class YorumlarsController : Controller
    {
        private readonly SkContext _context;

        public YorumlarsController()
        {
            _context = new SkContext();
        }

        // GET: Yorumlars
        public async Task<IActionResult> Index()
        {
              return _context.Yorumlars != null ? 
                          View(await _context.Yorumlars.ToListAsync()) :
                          Problem("Entity set 'SkContext.Yorumlars'  is null.");
        }

        // GET: Yorumlars/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Yorumlars == null)
            {
                return NotFound();
            }

            var yorumlar = await _context.Yorumlars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yorumlar == null)
            {
                return NotFound();
            }

            return View(yorumlar);
        }

        // GET: Yorumlars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yorumlars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParentId,Ad,Mail,Metin,Yildiz")] Yorumlar yorumlar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yorumlar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yorumlar);
        }

        // GET: Yorumlars/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Yorumlars == null)
            {
                return NotFound();
            }

            var yorumlar = await _context.Yorumlars.FindAsync(id);
            if (yorumlar == null)
            {
                return NotFound();
            }
            return View(yorumlar);
        }

        // POST: Yorumlars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ParentId,Ad,Mail,Metin,Yildiz")] Yorumlar yorumlar)
        {
            if (id != yorumlar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yorumlar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YorumlarExists(yorumlar.Id))
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
            return View(yorumlar);
        }

        // GET: Yorumlars/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Yorumlars == null)
            {
                return NotFound();
            }

            var yorumlar = await _context.Yorumlars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yorumlar == null)
            {
                return NotFound();
            }

            return View(yorumlar);
        }

        // POST: Yorumlars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Yorumlars == null)
            {
                return Problem("Entity set 'SkContext.Yorumlars'  is null.");
            }
            var yorumlar = await _context.Yorumlars.FindAsync(id);
            if (yorumlar != null)
            {
                _context.Yorumlars.Remove(yorumlar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YorumlarExists(long id)
        {
          return (_context.Yorumlars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
