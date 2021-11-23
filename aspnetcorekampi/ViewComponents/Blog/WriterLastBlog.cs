using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcorekampi.ViewComponents.Blog
{
    public class WriterLastBlog : ViewComponent
    {

        BlogManager bm = new BlogManager(new EfBlogRepository());

        Context c = new Context();

        public IViewComponentResult Invoke() 
        {
            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = bm.GetBlogListByWriter(writerId);
            return View(values);
        }

    }
}
