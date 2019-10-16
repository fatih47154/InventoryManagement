using System;
using System.Collections.Generic;
using InventoryManagement.Entities.Tables;

namespace InventoryManagement.IDal.IDal
{
    public interface IOperationDal
    {
        bool AddOrUpdate(Operation entity);
        bool Delete(Func<Operation, bool> filter);
        IList<Operation> GetAllList(Func<Operation, bool> filter = null);
        Operation GetByFilter(Func<Operation, bool> filter);
    }
}
