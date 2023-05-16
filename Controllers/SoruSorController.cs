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
    public class SoruSorController : Controller
    {
        private readonly SkContext _context;

        public SoruSorController()
        {
            _context = new SkContext();
        }

        // GET: SoruSor
        public async Task<IActionResult> Index()
        {
              return _context.Sorus != null ? 
                          View(await _context.Sorus.ToListAsync()) :
                          Problem("Entity set 'SkContext.Sorus'  is null.");
        }

        //// GET: SoruSor/Details/5
        //public async Task<IActionResult> Details(long? id)
        //{
        //    if (id == null || _context.Sorus == null)
        //    {
        //        return NotFound();
        //    }

        //    var soru = await _context.Sorus
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (soru == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(soru);
        //}

        // GET: SoruSor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SoruSor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ad,Mail,Metin")] Soru soru)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soru);
                await _context.SaveChangesAsync();
                TempData["FeedBack"] = "Sorunuz İletildi";
                return RedirectToAction(nameof(Index));
            }
                TempData["FeedBack"] = "Sorunuzun İletiminde Bir Hata Oluştu";
            return View(soru);
        }

        // GET: SoruSor/Edit/5
        //public async Task<IActionResult> Edit(long? id)
        //{
        //    if (id == null || _context.Sorus == null)
        //    {
        //        return NotFound();
        //    }

        //    var soru = await _context.Sorus.FindAsync(id);
        //    if (soru == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(soru);
        //}

        // POST: SoruSor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(long id, [Bind("Id,ParentId,Ad,Mail,Metin,Cevap")] Soru soru)
        //{
        //    if (id != soru.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(soru);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SoruExists(soru.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(soru);
        //}

        // GET: SoruSor/Delete/5
        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null || _context.Sorus == null)
        //    {
        //        return NotFound();
        //    }

        //    var soru = await _context.Sorus
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (soru == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(soru);
        //}

        //// POST: SoruSor/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    if (_context.Sorus == null)
        //    {
        //        return Problem("Entity set 'SkContext.Sorus'  is null.");
        //    }
        //    var soru = await _context.Sorus.FindAsync(id);
        //    if (soru != null)
        //    {
        //        _context.Sorus.Remove(soru);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool SoruExists(long id)
        //{
        //  return (_context.Sorus?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
