using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Entities.Abstract;

namespace InventoryManagement.Entities.Tables
{
    public class OperationType : AOperationCollectionEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
