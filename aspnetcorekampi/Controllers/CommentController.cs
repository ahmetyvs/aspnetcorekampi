using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcorekampi.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialCommentListByBlog(int id)
        {
            var values = cm.Getlist(id);
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult PartialAddComment( Comment p)
        {
            p.CommentDate = DateTime.Now;
            p.CommentStatus = true;
            p.BlogID=2;
            cm.CommentAdd(p);
            return PartialView();
        }
    }
}
