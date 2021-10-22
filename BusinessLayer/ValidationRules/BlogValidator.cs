using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş geçilemez!");
            RuleFor(x => x.BlogTitle).MinimumLength(4).WithMessage("Başlık için en az 5 karakter girmelisiniz!");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Başlık için en fazla 150 karakter girebilisiniz!");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş geçilemez");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog resmi boş geçilemez");
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Blog kategorisi boş geçilemez, lütfen listeden bir seçim yapın!");
        }
    }
}
