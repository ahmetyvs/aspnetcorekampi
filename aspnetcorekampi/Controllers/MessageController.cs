using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcorekampi.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager Mm = new Message2Manager(new EfMessage2Repository());

        [AllowAnonymous]
        public IActionResult InBox()
        {
            int id = 2; // buradaki değer daha sonra sessiondan gelen değer ile belirlenecek
            var values = Mm.GetInboxlistByWriter(id);
            return View(values);
        }

        [AllowAnonymous]
        public IActionResult MessageDetails(int id)
        {
            var value = Mm.TGetById(id);
            return View(value);
        }
    }
}
