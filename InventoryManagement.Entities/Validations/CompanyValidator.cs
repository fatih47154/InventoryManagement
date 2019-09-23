using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InventoryManagement.Entities.Tables;

namespace InventoryManagement.Entities.Validations
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Şirket İsmi Alanı Boş Geçilemez.").Length(5, 200)
                .WithMessage("Şirket İsmi Alanı 5 ile 50 Karakter Arasında Olmalıdır.");
            RuleFor(p => p.Number).NotEmpty().WithMessage("Şirket Numarası Alanı Boş Geçilemez.");
        }
    }
}
