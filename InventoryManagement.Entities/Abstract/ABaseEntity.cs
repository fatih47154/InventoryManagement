using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Entities.Interfaces;

namespace InventoryManagement.Entities.Abstract
{
    public abstract class ABaseEntity: IEntity
    {
        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        [DisplayName("Oluşturma Tarihi")]
        public virtual DateTime? CreatedDate { get; set; } = DateTime.Now;

        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        [DisplayName("Güncelleme Tarihi")]
        public virtual DateTime? UpdatededDate { get; set; }

        [DisplayName("Aktif")]
        public bool? IsActive { get; set; } = true;

        [DisplayName("Açıklama")]
        public string Description { get; set; }
    }
}
