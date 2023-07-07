using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurucuKursu.Models;

namespace SurucuKursu.Controllers
{
	public class HaberController : Controller
    {
        private readonly SkContext _context;

        public HaberController()
        {
            _context = new SkContext();
        }

        // GET: Haber
        public async Task<IActionResult> Index()
        {
            return _context.Haberlers != null ?
                        View(await _context.Haberlers.ToListAsync()) :
                        Problem("Entity set 'SkContext.Haberlers'  is null.");
        }
        // GET: Haberlers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Haberlers == null)
            {
                return NotFound();
            }

            var haberler = await _context.Haberlers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (haberler == null)
            {
                return NotFound();
            }

            return View(haberler);
        }
    }
}
