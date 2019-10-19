using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FluentValidation;
using InventoryManagement.Entities.Interfaces;

namespace InventoryManagement.Dal.Tools
{
    public static class ValidatorTool
    {
        public static bool Validate(IValidator validator, IEntity entity)
        {
            var result = true;
            string message = null;
            var validationResult = validator.Validate(entity);
            
            if (!validationResult.IsValid)
            {
                foreach (var err in validationResult.Errors)
                {
                    message += err.ErrorMessage + System.Environment.NewLine;
                }

                MessageBox.Show(message, "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = false;
            }
            return result;
        }
    }
}
