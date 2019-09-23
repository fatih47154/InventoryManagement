using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InventoryManagement.Entities.Tables;

namespace InventoryManagement.Entities.Validations
{
    public class StoreValidator : AbstractValidator<Store>
    {
        public StoreValidator()
        {
            RuleFor(p => p.InventoryNumber).NotEmpty().WithMessage("Envanter Numarası Alanı Boş Geçilemez.");
            RuleFor(p => p.SerialNumber).NotEmpty().WithMessage("Seri Numarası Alanı Boş Geçilemez.");
        }
    }
}
