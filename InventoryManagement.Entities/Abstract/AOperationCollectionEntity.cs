using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Entities.Tables;

namespace InventoryManagement.Entities.Abstract
{
    public abstract class AOperationCollectionEntity : ABaseEntity
    {
        public ICollection<Operation> Operations { get; set; }
    }
}
