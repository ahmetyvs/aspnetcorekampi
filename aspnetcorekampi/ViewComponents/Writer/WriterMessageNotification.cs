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

        MessageManager mm = new MessageManager(new EfMessageRepository());

        public IViewComponentResult Invoke() // Invoke çağırmak anlamına geliyor.
        {
            string p;
            p = "deneme@deneme.com.tr"; // buradaki değer daha sonra sessiondan gelen değer ile belirlenecek
            var values = mm.GetInboxlistByWriter(p);
            return View(values);
        }

    }
}
