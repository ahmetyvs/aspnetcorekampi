using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcorekampi.Controllers
{
    [AllowAnonymous]

    public class AdminController : Controller
    {
        public IActionResult _Index()
        {
            return View();
        }

        public PartialViewResult _AdminSolnavbar()
        {
            return PartialView();
        }
    }
}
