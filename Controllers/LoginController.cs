using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using SurucuKursu.Models;

namespace SurucuKursu.Controllers
{
    public class LoginController : Controller
    {

        private readonly SkContext _context;

        public LoginController()
        {
            _context = new SkContext();
        }
        public IActionResult Index()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if(claimUser.Identity.IsAuthenticated )
            {
                return RedirectToAction("Index","Admin");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index([FromForm] Yoneticiler p)
        {
            var bilgiler = _context.Yoneticilers.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.Pasword==p.Hash(p.Pasword));
            if (bilgiler != null) 
            {
                p.Durum = p.ChkDurum ? 1 : 0;
               await  _context.SaveChangesAsync();

                List<Claim> claims = new List<Claim>() { 
                new Claim(ClaimTypes.NameIdentifier,p.KullaniciAdi),
                new Claim("OtherProperties","Admin")
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties() {
                    AllowRefresh = true ,
                    IsPersistent = p.ChkDurum
                };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),properties);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                TempData["hata"] = "Giriş bilgileriniz yanlış";
                return RedirectToAction("Index", "Login");
            }
        }


    }
}
    
