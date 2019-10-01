using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BackOffice.Models
{
    public class UsersModel
    {
        [DisplayName("İsim")]
        public string Name { get; set; }
        [DisplayName("Soyisim")]
        public string Surname { get; set; }
        [DisplayName("Şirket")]
        public string Company { get; set; }
    }
}
