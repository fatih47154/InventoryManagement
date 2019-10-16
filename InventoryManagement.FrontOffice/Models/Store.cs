using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.FrontOffice.Models
{
    public class Store
    {
        [DisplayName("Envanter Numarası")]
        public string InventoryNumber { get; set; }
        [DisplayName("Seri Numarası")]
        public string SerialNumber { get; set; }
        [DisplayName("Cihaz Tipi")]
        public string DeviceType { get; set; }
        [DisplayName("Cihaz Modeli")]
        public string Model { get; set; }
        [DisplayName("Garanti Başlangıç Zamanı")]
        public DateTime WarrantyStart { get; set; }
        [DisplayName("İşlem Zamanı")]
        public DateTime OperationTime { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
    }
}
