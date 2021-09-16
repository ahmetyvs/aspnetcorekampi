using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICatagoryDal
    {
        List<Category> ListAllCategory();

        void AddCategory(Category category);

        void DeleteCatagoy(Category category);

        void UpdateCategory(Category category);

        Category GetByID(int id);
    }
}
