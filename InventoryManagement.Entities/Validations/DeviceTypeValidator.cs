using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InventoryManagement.Entities.Tables;

namespace InventoryManagement.Entities.Validations
{
    public class DeviceTypeValidator : AbstractValidator<DeviceType>
    {
        public DeviceTypeValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Cihaz Türü Adı Alanı Boş Geçilemez.").Length(5,200)
                .WithMessage("Cihaz Adı Alanı 5 ile 200 Karakter Arasında Olmalıdır.");
            RuleFor(p => p.Character).NotNull().WithMessage("Cihaz Karakter Alanı Boş Geçilemez");
        }
    }
}
