using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.FrontOffice.Models
{
    public class Movement
    {
        [DisplayName("Durumu")]
        public string Status { get; set; }
        [DisplayName("Adı")]
        public string Name { get; set; }
        [DisplayName("Soyadı")]
        public string Surname { get; set; }
        [DisplayName("Şirket")]
        public string Company { get; set; }
        [DisplayName("Lokasyon")]
        public string Location { get; set; }
        [DisplayName("Envanter Numarası")]
        public string InventoryNumber { get; set; }
        [DisplayName("Seri Numarası")]
        public string SerialNumber { get; set; }
        [DisplayName("Cihaz Tipi")]
        public string DeviceType { get; set; }
        [DisplayName("Cihaz Modeli")]
        public string Model { get; set; }
        [DisplayName("İşlem Türü")]
        public string OperationType { get; set; }
        [DisplayName("İşlem Zamanı")]
        public DateTime OperationTime { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }   
    }
}
