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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerdal;

        public WriterManager(IWriterDal writerdal)
        {
            _writerdal = writerdal;
        }

        public List<Writer> Getlist() //Admin panelinde tüm yazarları listelemek için kullanılacak.
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetWriterById(int id) // Writer paneli için giriş yapan tek yazar getirmek için kullanılacak
        {
            return _writerdal.GetListAll(x=>x.WriterID==id);
        }

        public void TAdd(Writer t)
        {
            _writerdal.Insert(t);
        }

        public void TDelete(Writer t)
        {
            throw new NotImplementedException();
        }

        public Writer TGetById(int id)
        {
            return _writerdal.GetByID(id);
        }

        public void TUpdate(Writer t)
        {
            _writerdal.Update(t);
        }

        //public void WriterAdd(Writer t)
        //{
        //    _writerdal.Insert(t);
        //}
    }
}
