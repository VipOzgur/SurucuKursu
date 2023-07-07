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
                          View(await _context.Galeris.OrderByDescending(x => x.Id)
    .ToListAsync()) :
                          Problem("Entity set 'SkContext.Galeris'  is null.");
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
        public async Task<IActionResult> Create([FromForm] Galeri galeri)
        {
            if (ModelState.IsValid)
            {
                if (galeri.ImageFile != null && galeri.ImageFile.Count > 0)
                {
                    foreach (var item in galeri.ImageFile)
                    {
                    Galeri galeri1 = new Galeri { 
                        Aciklama=galeri.Aciklama,
                        Resim=publicClass.ImgToBase64(item)
					};
                    _context.Add(galeri1);
				    }
                    await _context.SaveChangesAsync();
                    TempData["durum"] = "Resim eklendi";
                        return RedirectToAction(nameof(Index));
                }

            }
            TempData["durum"] = "Resim eklenirken bir sorun oluştu";
            return RedirectToAction(nameof(Index));
        }


        // POST: Galeri/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteResim(string ids)
        {
            string[] strings = ids.Split(',');
            long[] longDizi = new long[strings.Length];
            if (strings.Length > 0)
            {
                for (long s = 0; s < strings.Length; s++)
                {

                    if (long.TryParse(strings[s], out long result))
                    {
                        longDizi[s] = long.Parse(strings[s]);
                    }
                }
            }

            if (_context.Galeris == null)
            {
                TempData["durum"] = "Silme işlemi başarısız";
                return Problem("Entity set 'SkContext.Galeri'  is null.");
            }

            foreach (var item in longDizi)
            {
                var galeri = await _context.Galeris.FindAsync(item);
                if (galeri != null)
                {
                    _context.Galeris.Remove(galeri);
                }
            }

            await _context.SaveChangesAsync();
            TempData["durum"] = "Silme işlemi başarılı";
            return RedirectToAction("Index", "Galeri");
        }

        private bool GaleriExists(long id)
        {
          return (_context.Galeris?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
