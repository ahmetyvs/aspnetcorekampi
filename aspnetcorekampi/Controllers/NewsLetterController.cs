using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcorekampi.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
    {
        NewsletterManager nm = new NewsletterManager(new EfNewsletterRepository());
        //Context c = new Context();

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        //[HttpPost]
        //public PartialViewResult SubscribeMail(NewsLetter p)
        //{
        //    //p.MailStatus = true;
        //    //nm.AddNewsLetter(p);
        //    return PartialView();
        //}

        public JsonResult SubscribeMaill(NewsLetter p)
        {
            if (p.Mail==null) //formun doğru dolduruludu mu?
            {
                return Json("0");
            }
            else
            {
                p.MailStatus = true;
                nm.AddNewsLetter(p);
                return Json("1");
            }
        }
    }
}

