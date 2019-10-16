using System;
using System.Collections.Generic;
using InventoryManagement.Entities.Tables;

namespace InventoryManagement.IDal.IDal
{
    public interface IStoreDal
    {
        bool AddOrUpdate(Store entity);
        bool Delete(Func<Store, bool> filter);
        IList<Store> GetAllList(Func<Store, bool> filter = null);
        Store GetByFilter(Func<Store, bool> filter);
    }
}
