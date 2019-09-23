using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InventoryManagement.Entities.Tables;

namespace InventoryManagement.Entities.Validations
{
    public class LocationValidator : AbstractValidator<Location>
    {
        public LocationValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Lokasyon Adı Alanı Boş Geçilemez.").Length(5, 200)
                .WithMessage("Lokasyon Adı Alanı 5 ile 200 Karakter Arasında Olmalıdır");
            
        }
    }
}
