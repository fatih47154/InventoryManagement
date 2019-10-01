using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BackOffice.Models
{
    public class LocationModel
    {
        [DisplayName("Lokasyon İsmi")]
        public string Name { get; set; }
    }
}
