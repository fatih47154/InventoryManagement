using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Entities.Abstract;

namespace InventoryManagement.Entities.Tables
{
    public class Company : AOperationCollectionEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
