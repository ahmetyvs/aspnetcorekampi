using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcorekampi.ViewComponents.Blog
{
    public class WritersLastBlog : ViewComponent
    {

        BlogManager bm = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke(int id) 
        {
            var values = bm.GetBlogListByWriter(1);
            return View(values);
        }

    }
}
