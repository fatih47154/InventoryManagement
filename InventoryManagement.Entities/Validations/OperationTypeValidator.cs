using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InventoryManagement.Entities.Tables;

namespace InventoryManagement.Entities.Validations
{
    public class OperationTypeValidator : AbstractValidator<OperationType>
    {
        public OperationTypeValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotEmpty().WithMessage("İşlem Türü Adı Alanı Boş Geçilemez.").Length(5, 200)
                .WithMessage("İşlem Türü Adı Alanı 5 ile 200 Karakter Arasında Olmalıdır.");
        }
    }
}
