using aspnetcorekampi.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcorekampi.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        Context c = new Context();

        [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail; //kullanıcı mail adresini getirir
            Context context = new Context();
            var writerName = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = writerName; //kullanıcının kullanıcı adını getirir
            return View();
        }

        public PartialViewResult Solnavbar()
        {
            return PartialView();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult EditWriterProfile()
        {
            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = wm.GetWriterById(writerId);
            var writervalues = wm.TGetById(writerId);
            return View(writervalues);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult EditWriterProfile(Writer p)
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult result = wv.Validate(p); // Çok önemli... Burada  ValidationResult'ı kullanırken Annodations değil using FluentValidation seçilecek
            if (result.IsValid)
            {
                wm.TUpdate(p);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult AddWriter()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddWriter(AddProfileImage p)
        {
            Writer w = new Writer();
            if (p.WriterImage != null)
            {
                var extention = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extention;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
            }
            w.WriterName = p.WriterName;
            w.WriterMail = p.WriterMail;
            w.WriterParola = p.WriterParola;
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;
            wm.TAdd(w);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
