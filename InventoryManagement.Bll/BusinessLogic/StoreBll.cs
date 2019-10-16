using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Dal.Context;
using InventoryManagement.Dal.DataAccess;
using InventoryManagement.Entities.Tables;
using InventoryManagement.IDal.IRepository;

namespace InventoryManagement.Bll.BusinessLogic
{
    public class StoreBll : IBusinessRepository<Store>
    {
        private StoreDal StoreDal { get; }
        private InventoryManagementContext InventoryManagementContext { get; set; }
        private Expression<Func<Store, object>>[] IncludeExpressions { get; }
        public StoreBll()
        {
            StoreDal = new StoreDal();
            InventoryManagementContext = new InventoryManagementContext();
            IncludeExpressions = new Expression<Func<Store, object>>[4] {
                properties => properties.User,
                properties => properties.Model.DeviceType,
                properties => properties.Model,
                properties => properties.Status
            };
        }
        public bool AddOrUpdate(Store entity)
        {
            var result = StoreDal.AddOrUpdate(InventoryManagementContext, entity);
            StoreDal.Save(InventoryManagementContext);
            return result;
        }

        public bool Delete(Func<Store, bool> filter)
        {
            try
            {
                StoreDal.Delete(InventoryManagementContext, filter);
                StoreDal.Save(InventoryManagementContext);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<Store> GetAllList(Func<Store, bool> filter = null)
        {
            if (filter != null)
            {
                Func<Store, bool> filterExpression = (x => x.IsActive == true) + filter;
                return StoreDal.GetAllList(InventoryManagementContext, filterExpression,
                    IncludeExpressions);
            }

            return StoreDal.GetAllList(InventoryManagementContext, filterExpression => filterExpression.IsActive == true,
                IncludeExpressions);
        }

        public Store GetByFilter(Func<Store, bool> filter)
        {
            return StoreDal.GetByFilter(InventoryManagementContext, filter,
                IncludeExpressions);
        }
    }
}
