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
    public class GaleriController : Controller
    {
        private readonly SkContext _context;

        public GaleriController()
        {
            _context = new SkContext();
        }

        PublicClass publicClass = new PublicClass();

        // GET: Galeri
        public async Task<IActionResult> Index()
        {
              return _context.Galeris != null ? 
                          View(await _context.Galeris.ToListAsync()) :
                          Problem("Entity set 'SkContext.Galeris'  is null.");
        }

        // GET: Galeri/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Galeris == null)
            {
                return NotFound();
            }

            var galeri = await _context.Galeris
                .FirstOrDefaultAsync(m => m.Id == id);
            if (galeri == null)
            {
                return NotFound();
            }

            return View(galeri);
        }

        // GET: Galeri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Galeri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Aciklama,Resim,ImageFile")] Galeri galeri)
        {
            if (ModelState.IsValid)
            {
                if (galeri.ImageFile != null && galeri.ImageFile.Length > 0)
                {
                    
                    galeri.Resim=publicClass.ImgToBase64(galeri.ImageFile);
                        _context.Add(galeri);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                }

            }
            return View("Create","Galeri");
        }



        // GET: Galeri/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Galeris == null)
            {
                return NotFound();
            }

            var galeri = await _context.Galeris.FindAsync(id);
            if (galeri == null)
            {
                return NotFound();
            }
            return View(galeri);
        }

        // POST: Galeri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Aciklama,Resim")] Galeri galeri)
        {
            if (id != galeri.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(galeri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GaleriExists(galeri.Id))
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
            return View(galeri);
        }

        // GET: Galeri/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Galeris == null)
            {
                return NotFound();
            }

            var galeri = await _context.Galeris
                .FirstOrDefaultAsync(m => m.Id == id);
            if (galeri == null)
            {
                return NotFound();
            }

            return View(galeri);
        }

        // POST: Galeri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Galeris == null)
            {
                return Problem("Entity set 'SkContext.Galeris'  is null.");
            }
            var galeri = await _context.Galeris.FindAsync(id);
            if (galeri != null)
            {
                _context.Galeris.Remove(galeri);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GaleriExists(long id)
        {
          return (_context.Galeris?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
