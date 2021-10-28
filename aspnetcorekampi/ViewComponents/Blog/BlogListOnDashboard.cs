using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcorekampi.ViewComponents.Blog
{
    public class BlogListOnDashboard : ViewComponent
    {

        BlogManager bm = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            var values = bm.GetBlogListWithCategory(); // Son 10 bloğu çekecek şekilde düzenlenecek
            return View(values);
        }
    }
}
