using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.IDal.IRepository
{
    public interface IEntityRepository<in TContext,TEntity> 
        where TContext: DbContext, new()
        where TEntity: class, IEntity, new()
    {
        void AddOrUpdate(TContext context, TEntity entity);
        void Delete(TContext context, Expression<Func<TEntity, bool>> filterExpression);
        void Save(TContext context);
    }
}
