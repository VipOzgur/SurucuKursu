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
                          View(await _context.Sorus.Where(x=> x.Cevap != null && x.Visibility == 1).OrderByDescending(x => x.Id).ToListAsync()) :
                          Problem("Entity set 'SkContext.Sorus'  is null.");
        }
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
            }
            else
            {
 TempData["FeedBack"] = "Sorunuzun İletiminde Bir Hata Oluştu";
            }
               soru.IsPosted=true;
            return View(soru);
        }
        //private bool SoruExists(long id)
        //{
        //  return (_context.Sorus?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
