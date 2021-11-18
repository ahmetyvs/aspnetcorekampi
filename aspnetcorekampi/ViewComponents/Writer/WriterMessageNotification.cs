using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcorekampi.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {

        Message2Manager mm = new Message2Manager(new EfMessage2Repository());

        public IViewComponentResult Invoke() // Invoke çağırmak anlamına geliyor.
        {
            int id = 2; // buradaki değer daha sonra sessiondan gelen değer ile belirlenecek
            var values = mm.GetInboxlistByWriter(id);
            return View(values);
        }

    }
}
