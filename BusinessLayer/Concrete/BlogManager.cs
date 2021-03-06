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
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public List<Blog> GetListWithCategoryByWriterBm(int id) // (İşl. sırası -3-)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }

        public Blog TGetById(int id)
        {
            return _blogDal.GetByID(id);
        }

        public List<Blog> GetBlogByID(int id)
        {
            return _blogDal.GetListAll(x => x.BlogID == id);
        }

        public List<Blog> Getlist()
        {
            return _blogDal.GetListAll();
        }

        // Eklenen en son 3 bloğu getir
        public List<Blog> Getlast3Blog()
        {
            return _blogDal.GetListAll().OrderByDescending(x=>x.BlogID).Take(3).ToList();
        }

        //// Eklenen en son 10 bloğu getir
        //public List<Blog> Getlast10Blog()
        //{
        //    return _blogDal.GetListAll().OrderByDescending(x => x.BlogID).Take(10).ToList();
        //}

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.GetListAll(x => x.WriterID == id);
        }

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t); // t'ye gelen değer blogvalue; blogvalue ise BlogControllerdan geliyor.
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }
    }
}