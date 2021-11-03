using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcorekampi.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {

        WriterManager writermanager = new WriterManager(new EfWriterRepository());

        public IViewComponentResult Invoke()
        {
            //var values = writermanager.GetBlogListWithCategory(); // Son 10 bloğu çekecek şekilde düzenlenecek
            return View(/*values*/);
        }
    }
}
