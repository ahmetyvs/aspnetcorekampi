using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NewsletterManager : INewsletterService
    {
        INewsletterDal _newsletterdal;

        public NewsletterManager(INewsletterDal newsletterdal)
        {
            _newsletterdal = newsletterdal;
        }

        public void AddNewsLetter(NewsLetter newsletter)
        {
            _newsletterdal.Insert(newsletter);
        }

    }
}
