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
    public class YoneticilersController : Controller
    {
        private readonly SkContext _context;

        public YoneticilersController()
        {
            _context = new SkContext();
        }
        PublicClass publicClass = new PublicClass();
        // GET: Yoneticilers
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
              return _context.Yoneticilers != null ? 
                          View(await _context.Yoneticilers.ToListAsync()) :
                          Problem("Entity set 'SkContext.Yoneticilers'  is null.");
        }

        // GET: Yoneticilers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Yoneticilers == null)
            {
                return NotFound();
            }

            var yoneticiler = await _context.Yoneticilers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yoneticiler == null)
            {
                return NotFound();
            }

            return View(yoneticiler);
        }

        // GET: Yoneticilers/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yoneticilers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Yoneticiler yoneticiler)
        {

            if (ModelState.IsValid)
            {
                if (yoneticiler.ImgFile != null && yoneticiler.ImgFile.Length > 0)
                    yoneticiler.Profil = publicClass.ImgToBase64(yoneticiler.ImgFile);
                   var sifre= yoneticiler.Hash(yoneticiler.Pasword);
                yoneticiler.Pasword = sifre;
                _context.Add(yoneticiler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yoneticiler);
        }

        // GET: Yoneticilers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Yoneticilers == null)
            {
                return NotFound();
            }

            var yoneticiler = await _context.Yoneticilers.FindAsync(id);
            if (yoneticiler == null)
            {
                return NotFound();
            }
            TempData["key"] = yoneticiler.Pasword;
            return View(yoneticiler);
        }

        // POST: Yoneticilers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [FromForm] Yoneticiler yoneticiler)
        {
            if (id != yoneticiler.Id)
            {
                return NotFound();
            }
            
            if (yoneticiler.KullaniciAdi !=null && yoneticiler.Meil != null)
            {
                try
                {
                    if(yoneticiler.ImgFile!=null && yoneticiler.ImgFile.Length>0)
                        yoneticiler.Profil = publicClass.ImgToBase64(yoneticiler.ImgFile);
                    if (yoneticiler.newPassword != null)
                        yoneticiler.Pasword= yoneticiler.Hash(yoneticiler.newPassword);
                    _context.Update(yoneticiler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YoneticilerExists(yoneticiler.Id))
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
            return View(yoneticiler);
        }

        // GET: Yoneticilers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Yoneticilers == null)
            {
                return NotFound();
            }

            var yoneticiler = await _context.Yoneticilers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yoneticiler == null)
            {
                return NotFound();
            }

            return View(yoneticiler);
        }

        // POST: Yoneticilers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Yoneticilers == null)
            {
                return Problem("Entity set 'SkContext.Yoneticilers'  is null.");
            }
            var yoneticiler = await _context.Yoneticilers.FindAsync(id);
            if (yoneticiler != null)
            {
                _context.Yoneticilers.Remove(yoneticiler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YoneticilerExists(long id)
        {
          return (_context.Yoneticilers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
