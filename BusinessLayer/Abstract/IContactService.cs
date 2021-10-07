using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface IContactService
    {
         void ContactAdd(Contact contact);

        //void AboutDelete(About about);

        // void AboutUpdate(About about);

        List<Contact> Getlist();

        // About GetById(int id);

    }
}
