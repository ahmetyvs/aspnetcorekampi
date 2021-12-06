using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz!");
            RuleFor(x => x.CategoryName).MinimumLength(4).WithMessage("Kategori adı en az 4 karakter girmelisiniz!");
            RuleFor(x => x.CategoryName).MaximumLength(80).WithMessage("Kategori adı en fazla 80 karakter girmelisiniz!");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklaması boş geçilemez");
            RuleFor(x => x.CategoryDescription).MinimumLength(10).WithMessage("Kategori açıklamasını en az 10 karakter girmelisiniz!");
            RuleFor(x => x.CategoryDescription).MaximumLength(100).WithMessage("Kategori açıklamasını en fazla 100 karakter girmelisiniz!");
        }

    }
}
