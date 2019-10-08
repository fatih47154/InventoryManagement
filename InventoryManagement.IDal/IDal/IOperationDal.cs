using System.Collections.Generic;
using InventoryManagement.Entities.Tables;

namespace InventoryManagement.IDal.IDal
{
    public interface IOperationDal
    {
        IList<Operation> GetAllList();
    }
}
