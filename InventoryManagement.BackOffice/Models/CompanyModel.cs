using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BackOffice.Models
{
    public class CompanyModel
    {
        [DisplayName("Şirket Adı")]
        public string Name { get; set; }
        [DisplayName("Şirket Numarası")]
        public int Number { get; set; }
    }
}
