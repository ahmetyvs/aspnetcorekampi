using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcorekampi.Controllers
{
    public class WriterController : Controller
    {

        [AllowAnonymous] // çalışma bittikten sonra sileceğim
        public IActionResult Index()
        {
            return View();
        }
    }
}
