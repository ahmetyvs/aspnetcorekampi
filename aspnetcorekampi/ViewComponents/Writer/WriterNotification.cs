using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcorekampi.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());

        public IViewComponentResult Invoke() // Invoke çağırmak anlamına geliyor.
        {
            var values = nm.Getlist();
            return View(values);
        }
    }
}
