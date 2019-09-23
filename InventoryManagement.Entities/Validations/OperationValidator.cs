using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InventoryManagement.Entities.Tables;

namespace InventoryManagement.Entities.Validations
{
    public class OperationValidator : AbstractValidator<Operation>
    {
        public OperationValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Kullanıcı Adı Alanı Boş Geçilemez.").Length(5, 200)
                .WithMessage("Kullanıcı Adı Alanı 5 ile 200 Karakter Arasında Olmalıdır.");
            RuleFor(p => p.Surname).NotEmpty().WithMessage("Kullanıcı Soyadı Alanı Boş Geçilemez.").Length(5, 200)
                .WithMessage("Kullanıcı Soyadı Alanı 5 ile 200 Karakter Arasında Olmalıdır.");
        }
    }
}
