using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Entities.Abstract
{
    public abstract class ABaseEntity
    {
        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        [DisplayName("OLUŞTURMA TARİHİ")]
        public virtual DateTime? CreatedDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        [DisplayName("GÜNCELLEME TARİHİ")]
        public virtual DateTime? UpdatededDate { get; set; }

        public bool? IsActive { get; set; }

        public string description { get; set; }
    }
}
