using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InventoryManagement.Dal.Tools;
using InventoryManagement.Entities.Interfaces;
using InventoryManagement.IDal.IRepository;

namespace InventoryManagement.Dal.Repository
{
    public abstract class EntityRepositoryBase<TContext, TEntity, TValidator>: IEntityRepository<TContext,TEntity>
        where TContext : DbContext, new()
        where TEntity : class, IEntity, new()
        where TValidator : class , IValidator, new()
    {
        public bool AddOrUpdate(TContext context, TEntity entity)
        {
            TValidator validator = new TValidator();
            var validationResult = ValidatorTool.Validate(validator, entity);
            if (validationResult)
            {
                context.Set<TEntity>().AddOrUpdate(entity);
            }

            return validationResult;
        }

        public void Delete(TContext context, Func<TEntity, bool> filterExpression)
        {
            context.Set<TEntity>().RemoveRange(context.Set<TEntity>().Where(filterExpression));
        }

        public virtual IList<TEntity> GetAllList(TContext context, Func<TEntity, bool> filterExpression,
            params Expression<Func<TEntity, object>>[] properties)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            if (properties != null)
            {
                foreach (Expression<Func<TEntity, object>> item in properties)
                    query = query.Include(item);
            }

            return filterExpression == null
                ? query.AsNoTracking().AsEnumerable().ToList()
                : query.AsNoTracking().AsEnumerable().Where(filterExpression).ToList();
        }

        public TEntity GetByFilter(TContext context, Func<TEntity, bool> filterExpression,
            params Expression<Func<TEntity, object>>[] properties)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            if (properties != null)
            {
                foreach (Expression<Func<TEntity, object>> item in properties)
                    query = query.Include(item);
            }

            return query.AsNoTracking().AsEnumerable().FirstOrDefault(filterExpression);
        }

        public void Save(TContext context)
        {
            context.SaveChanges();
        }
    }
}
