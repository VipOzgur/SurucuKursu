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
	public class AraclarController : Controller
    {
        private readonly SkContext _context;

        public AraclarController()
        {
            _context = new SkContext();
        }
        PublicClass publicClass = new PublicClass();
        // GET: Araclar
        public async Task<IActionResult> Index()
        {
            
              return _context.Araclars != null ? 
                          View(await _context.Araclars.ToListAsync()) :
                          Problem("Entity set 'SkContext.Araclars'  is null.");
        }

        // GET: Araclar/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Araclars == null)
            {
                return NotFound();
            }

            var araclar = await _context.Araclars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (araclar == null)
            {
                return NotFound();
            }

            return View(araclar);
        }

        // GET: Araclar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Araclar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Araclar araclar)
        {
            if (ModelState.IsValid)
            {
                _context.Araclars.Add(araclar); // Araclar nesnesini ekleyin

                foreach (var file in araclar.ImageFile)
                {
                    var aracResim = new AracResim
                    {
                        Resim = publicClass.ImgToBase64(file)
                    };

                    araclar.AracResims.Add(aracResim); // Her bir resmi araclar.AracResims'e ekleyin
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(araclar);
        }

        // GET: Araclar/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Araclars == null)
            {
                return NotFound();
            }

            var araclar = await _context.Araclars.FindAsync(id);
            if (araclar == null)
            {
                return NotFound();
            }
            return View(araclar);
        }

        // POST: Araclar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [FromForm] Araclar araclar)
        {
            if (id != araclar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(araclar);
                    foreach (var file in araclar.ImageFile)
                    {
                        var aracResim = new AracResim
                        {
                            Resim = publicClass.ImgToBase64(file)
                        };

                        araclar.AracResims.Add(aracResim); // Her bir resmi araclar.AracResims'e ekleyin
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AraclarExists(araclar.Id))
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
            return View(araclar);
        }

        // GET: Araclar/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Araclars == null)
            {
                return NotFound();
            }

            var araclar = await _context.Araclars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (araclar == null)
            {
                return NotFound();
            }

            return View(araclar);
        }

        // POST: Araclar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Araclars == null)
            {
                return Problem("Entity set 'SkContext.Araclars'  is null.");
            }
            var araclar = await _context.Araclars.FindAsync(id);
            if (araclar != null)
            {
                var resims=_context.AracResims.Where(m => m.ParentId == id).ToList();
                if (resims.Count > 0)
                {
                    foreach (var resim in resims) { 
                    _context.AracResims.Remove(resim);
                    }
                }
                _context.Araclars.Remove(araclar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AraclarExists(long id)
        {
          return (_context.Araclars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
		// POST: AracResim/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteResim(string ids)
		{
            long id = 0;
            string[] strings = ids.Split(',');
			long[] longDizi = new long[strings.Length];
            if (strings.Length > 0)
            {
				for(long s=0; s<strings.Length;s++)
                {
                    
                    if (long.TryParse(strings[s], out long result)) 
                    { 
                    longDizi[s] = long.Parse(strings[s]);
					}
				}
            }

			if (_context.AracResims == null)
			{
				return Problem("Entity set 'SkContext.AracResims'  is null.");
			}

			foreach (var item in longDizi)
			{
				var aracResim = await _context.AracResims.FindAsync(item);
				if (aracResim != null)
				{
					id = aracResim.ParentId;
					_context.AracResims.Remove(aracResim);
				}
			}

			await _context.SaveChangesAsync();
			return RedirectToAction("Edit", "Araclar", new { id = id });
		}
	}
}
