using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Soyadı boş geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("E-mail adresi boş geçilemez");
            RuleFor(x => x.WriterParola).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter yazın");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter yazın");
            // en az 1 büyük harf, en az 1 küçük harf ve rakam iste
        }
    }
}
