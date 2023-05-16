using Microsoft.AspNetCore.Mvc;
using SurucuKursu.Models;

namespace SurucuKursu.Controllers
{
    public class OnKayitController : Controller
    {
        private readonly SkContext _context;

        public OnKayitController()
        {
            _context = new SkContext();
        }
        // GET: OnKayits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OnKayits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Sayad,TelNo,Mail,Aciklama")] OnKayit onKayit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(onKayit);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            return View(onKayit);
        }

    }
}
