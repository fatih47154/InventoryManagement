using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Entities.Interfaces;

namespace InventoryManagement.IDal.IRepository
{
    public interface IBusinessRepository<TEntity> where TEntity: class, IEntity
    {
        bool AddOrUpdate(TEntity entity);
        bool Delete(Func<TEntity, bool> filter);
        IList<TEntity> GetAllList(Func<TEntity, bool> filter = null);
        TEntity GetByFilter(Func<TEntity, bool> filter);
    }
}
