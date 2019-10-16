using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Dal.Context;
using InventoryManagement.Dal.Repository;
using InventoryManagement.Entities.Tables;
using InventoryManagement.Entities.Validations;

namespace InventoryManagement.Dal.DataAccess
{
    public class StatusDal: EntityRepositoryBase<InventoryManagementContext, Status, StatusValidator>
    {
    }
}
