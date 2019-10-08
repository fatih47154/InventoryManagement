using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Entities.Interfaces;
using InventoryManagement.IDal.IRepository;

namespace InventoryManagement.Dal.Repository
{
    public abstract class EntityRepositoryBase<TContext, TEntity>: IEntityRepository<TContext,TEntity>
        where TContext : DbContext, new()
        where TEntity : class, IEntity, new()
    {
        public virtual IList<TEntity> GetAllList(TContext context, Func<TEntity, bool> filterExpression,
            params Expression<Func<TEntity, object>>[] properties)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            if (properties != null)
            {
                foreach (Expression<Func<TEntity, object>> item in properties)
                    query = query.Include<TEntity, object>(item);
            }

            return filterExpression == null
                ? query.AsNoTracking().AsEnumerable().ToList()
                : query.AsNoTracking().AsEnumerable().Where(filterExpression).ToList();
        }

        public TEntity GetByFilter(TContext context, Func<TEntity, bool> filterExpression, params Expression<Func<TEntity, object>>[] properties)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            if (properties != null)
            {
                foreach (Expression<Func<TEntity, object>> item in properties)
                    query = query.Include<TEntity, object>(item);
            }

            return query.AsNoTracking().AsEnumerable().FirstOrDefault(filterExpression);
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
