using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.IDal.IRepository;

namespace InventoryManagement.EfDal.Repository
{
    public abstract class EntityRepositoryBase<TContext, TEntity>: IEntityRepository<TContext,TEntity>
        where TContext : DbContext, new()
        where TEntity : class, IEntity, new()
    {
        public virtual IEnumerable<TEntity> GetAllList(TContext context, Expression<Func<TEntity, bool>> filterExpression = null, params Expression<Func<TEntity, object>>[] properties)
        {
            var query = context.Set<TEntity>();
            if (properties != null)
            {  
                query = properties
                    .Aggregate(query, (current, property) => (DbSet<TEntity>)current.Include(property));   
            }

            return filterExpression == null
                ? query.ToList()
                : query.Where(filterExpression).ToList();
        }
        public void AddOrUpdate(TContext context, TEntity entity)
        {
            context.Set<TEntity>().AddOrUpdate();
        }

        public void Delete(TContext context, Expression<Func<TEntity, bool>> filterExpression)
        {
            context.Set<TEntity>().RemoveRange(context.Set<TEntity>().Where(filterExpression));
        }

        public void Save(TContext context)
        {
            context.SaveChanges();
        }
    }
}
