using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Entities.Abstract;

namespace InventoryManagement.Entities.Tables
{
    public class Store : ABaseEntity
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; }
        public DateTime OperationTime { get; set; }
        public string InventoryNumber { get; set; }
        public DateTime WarrantyStart { get; set; }
        public Guid ModelId { get; set; }
        public Guid UserId { get; set; }
        public Guid OperationTypeId { get; set; }
        public virtual Model Model { get; set; }
        public virtual User User { get; set; }
        public virtual OperationType OperationType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Operation> Operations { get; set; }

    }
}
