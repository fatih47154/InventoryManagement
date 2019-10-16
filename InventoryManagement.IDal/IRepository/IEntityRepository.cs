using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Entities.Interfaces;

namespace InventoryManagement.IDal.IRepository
{
    public interface IEntityRepository<in TContext,TEntity>
        where TContext: DbContext, new()
        where TEntity: class, IEntity, new()
    {
        bool AddOrUpdate(TContext context, TEntity entity);

        void Delete(TContext context, Func<TEntity, bool> filterExpression);

        void Save(TContext context);

        IList<TEntity> GetAllList(TContext context, Func<TEntity, bool> filterExpression = null,
            params Expression<Func<TEntity, object>>[] properties);

        TEntity GetByFilter(TContext context, Func<TEntity, bool> filterExpression, 
            params Expression<Func<TEntity, object>>[] properties);
    }
}
