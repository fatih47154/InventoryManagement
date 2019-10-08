using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.EfDal.Context;
using InventoryManagement.EfDal.Repository;
using InventoryManagement.Entities.Tables;

namespace InventoryManagement.EfDal.DataAccess
{
    public class OperationDal: EntityRepositoryBase<InventoryManagementContext, Operation>
    {
    }
}
