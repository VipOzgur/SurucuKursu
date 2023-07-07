using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurucuKursu.Models;
using System.Diagnostics;

namespace SurucuKursu.Controllers
{
    public class HomeController : Controller
    {
        private readonly SkContext _context;

        public HomeController()
        {
            _context = new SkContext();
        }

        public IActionResult Index()
        {
            ViewData["yorumlar"]=_context.Yorumlars.Where(x=>x.Visibility == 1).ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            PublicClass publicClass = new PublicClass();
           TempData["hata"]= publicClass.SendEmail("vipozgurozkan@gmail.com", "Bu Bir Deneme Mesajıdır", "Privacy sayfasına giriş yapıldı");
            return View(TempData["hata"]);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // GET: Ehliyets
        public async Task<IActionResult> EhliyetSiniflari()
        {
            return _context.Ehliyets != null ?
                        View(await _context.Ehliyets.ToListAsync()) :
                        Problem("Entity set 'SkContext.Ehliyets'  is null.");
        }


        // GET: Galeri
        public async Task<IActionResult> Galeri()
        {
            return _context.Galeris != null ?
                        View(await _context.Galeris.ToListAsync()) :
                        Problem("Entity set 'SkContext.Galeris'  is null.");
        }
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> YorumCreate([FromForm] string Ad,string Mail,string Metin)
		{
			if (ModelState.IsValid)
			{
                Yorumlar yorumlar = new Yorumlar {
                Ad=Ad,
                Mail=Mail, 
                Metin=Metin
                };
				_context.Add(yorumlar);
				await _context.SaveChangesAsync();
                ViewData["mesaj"] = "Yorumunuz iletildi";
				return RedirectToAction(nameof(Index));
			}
            ViewData["mesaj"] = "Yorumunuz iletilirken bir hata oluştu";
			return RedirectToAction(nameof(Index));
		}
        // GET: Egitmen
        public async Task<IActionResult> Egitmenler()
        {
            return _context.Egitmenlers != null ?
                        View(await _context.Egitmenlers.OrderByDescending(x => x.Id).ToListAsync()) :
                        Problem("Entity set 'SkContext.Egitmenlers'  is null.");
        }
        // GET: Araclar
        public async Task<IActionResult> Araclar()
        {

            return _context.Araclars != null ?
                        View(await _context.Araclars.ToListAsync()) :
                        Problem("Entity set 'SkContext.Araclars'  is null.");
        }

        // GET: Araclar/Details/5
        public async Task<IActionResult> AracDetay(long? id)
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
        // GET: CikmisSorulars
        public async Task<IActionResult> CıkmısSorular()
        {
            return _context.CikmisSorulars != null ?
                        View(await _context.CikmisSorulars.OrderByDescending(x => x.Id).ToListAsync()) :
                        Problem("Entity set 'SkContext.CikmisSorulars'  is null.");
        }
    }
}