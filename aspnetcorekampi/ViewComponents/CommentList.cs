using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcorekampi.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke() // Invoke çağırmak anlamına geliyor.
        {
            return View();
        }
    }
}
