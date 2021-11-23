using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace aspnetcorekampi.Controllers
{
    
    
    [AllowAnonymous]
    public class LoginController : Controller
    {
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Writer p)
        {
            Context c = new Context();

            var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterParola == p.WriterParola);
            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, p.WriterMail)
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View();
            }

        }

    }
}
