using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcorekampi.Controllers
{

    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());

        WriterManager wm = new WriterManager(new EfWriterRepository());

        Context c = new Context();

        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            var Goruntulendi = c.Blogs.Find(id);
            Goruntulendi.BlogGoruntulenme++;
            c.SaveChanges();
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = bm.GetListWithCategoryByWriterBm(writerId); // BlogManagerden gelen İsim ile eştile (değiştir) İşl. sırası -4-
            return View(values);
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());

            List<SelectListItem> categoryvalues = (from x in cm.Getlist()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cid = categoryvalues;
            return View();
        }

        [HttpPost]
        public IActionResult AddBlog(Blog p)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(p); // Çok önemli... Burada  ValidationResult'ı kullanırken Annodations değil using FluentValidation seçilecek

            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            if (result.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Now;
                p.BlogGoruntulenme = 1;
                p.WriterID = writerId;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
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

        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue = bm.TGetById(id);

            CategoryManager cm = new CategoryManager(new EfCategoryRepository());

            List<SelectListItem> categoryvalues = (from x in cm.Getlist()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cid = categoryvalues;
            return View(blogvalue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            p.WriterID = writerId;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }

        private void UserID()
        {
            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.UsersID = writerId;
        }
    }
}
