using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InventoryManagement.Entities.Tables;

namespace InventoryManagement.Entities.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez.").Length(5, 200)
                .WithMessage("Durum Adı Alanı 5 ile 200 Karakter Arasında Olmalıdır.");
            RuleFor(p => p.Surname).NotEmpty().WithMessage("Soyisim Alanı Boş Geçilemez.").Length(5, 200)
                .WithMessage("Soyisim Alanı 5 ile 200 Karakter Arasında Olmalıdır.");
            RuleFor(p => p.Username).NotEmpty().WithMessage("Kullanıcı Adı Alanı Boş Geçilemez.").Length(5, 200)
                .WithMessage("Kullanıcı Adı Alanı 5 ile 200 Karakter Arasında Olmalıdır.");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre Alanı Boş Geçilemez.").Length(5, 30)
                .WithMessage("Şifre Alanı 5 ile 30 Karakter Arasında Olmalıdır.");
        }
    }
}
