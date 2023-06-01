using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurucuKursu.Models;
using System.Diagnostics;

namespace SurucuKursu.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly SkContext _context;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

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
            return View();
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