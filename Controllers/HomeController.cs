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
    }
}