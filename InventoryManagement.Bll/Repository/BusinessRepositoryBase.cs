using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Entities.Interfaces;
using InventoryManagement.IDal.IRepository;

namespace InventoryManagement.Bll.Repository
{
    public abstract class BusinessRepositoryBase<TContext, TEntity, TDal>: IBusinessRepository<TEntity>
        where TContext : DbContext, new()
        where TEntity : class, IEntity, new()
        where TDal: class , IEntityRepository<TContext, TEntity>, new()
    {
        private TDal Dal { get; }
        private TContext Context { get; }
        protected BusinessRepositoryBase()
        {
            Dal = new TDal();
            Context = new TContext();
        }

        public bool AddOrUpdate(TEntity entity)
        {
            var result = Dal.AddOrUpdate(Context, entity);
            Dal.Save(Context);
            return result;
        }

        public bool Delete(Func<TEntity, bool> filter)
        {
            try
            {
                Dal.Delete(Context, filter);
                Dal.Save(Context);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<TEntity> GetAllList(Func<TEntity, bool> filter = null)
        {
            var param = Expression.Parameter(typeof(TEntity), "x");
            var trueExp = Expression.Constant(true, typeof(bool?));
            var propertyOrFieldExpression = Expression.PropertyOrField(param, "IsActive");
            var condition = Expression.Equal(propertyOrFieldExpression, trueExp);
            var whereLambda = Expression.Lambda<Func<TEntity, bool>>(condition, param).Compile();

            if (filter != null)
            {
                Func<TEntity, bool> filterExpression = whereLambda + filter;
                return Dal.GetAllList(Context, filterExpression);
            }

            return Dal.GetAllList(Context, whereLambda);
        }

        public TEntity GetByFilter(Func<TEntity, bool> filter)
        {
            return Dal.GetByFilter(Context, filter);
        }
    }
}
