using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InventoryManagement.Entities.Tables;

namespace InventoryManagement.Entities.Validations
{
    public class ModelValidator : AbstractValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Model Adı Alanı Boş Geçilemez.").Length(5, 200)
                .WithMessage("Model Adı Alanı 5 ile 10 Karakter Arasında Olmalıdır.");
        }
    }
}
