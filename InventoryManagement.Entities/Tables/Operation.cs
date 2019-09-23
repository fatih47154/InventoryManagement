using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Entities.Abstract;

namespace InventoryManagement.Entities.Tables
{
    public class Operation : ABaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime OperationTime { get; set; }
        public Guid LocationId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid StoreId { get; set; }
        public Guid UserId { get; set; }
        public Guid OperationTypeId { get; set; }
        public Guid StatusId { get; set; }
        public virtual Location Location { get; set; }
        public virtual Company Company { get; set; }
        public virtual Store Store { get; set; }
        public virtual User User { get; set; }
        public virtual OperationType OperationType { get; set; }
        public virtual Status Status { get; set; }
    }
}
