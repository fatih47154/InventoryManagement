using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Dal.Context;
using InventoryManagement.Dal.DataAccess;
using InventoryManagement.Entities.Tables;
using InventoryManagement.IDal.IRepository;

namespace InventoryManagement.Bll.BusinessLogic
{
    public class DeviceTypeBll: IBusinessRepository<DeviceType>
    {
        private DeviceTypeDal DeviceTypeDal { get; }
        private InventoryManagementContext InventoryManagementContext { get; set; }
        //private Expression<Func<Store, object>>[] IncludeExpressions { get; }
        public DeviceTypeBll()
        {
            DeviceTypeDal = new DeviceTypeDal();
            InventoryManagementContext = new InventoryManagementContext();

            //IncludeExpressions = new Expression<Func<Company, object>>[1] {
            //
            //};
        }

        public bool AddOrUpdate(DeviceType entity)
        {
            var result = DeviceTypeDal.AddOrUpdate(InventoryManagementContext, entity);
            DeviceTypeDal.Save(InventoryManagementContext);
            return result;
        }

        public bool Delete(Func<DeviceType, bool> filter)
        {
            try
            {
                DeviceTypeDal.Delete(InventoryManagementContext, filter);
                DeviceTypeDal.Save(InventoryManagementContext);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<DeviceType> GetAllList(Func<DeviceType, bool> filter = null)
        {
            if (filter != null)
            {
                Func<DeviceType, bool> filterExpression = (x => x.IsActive == true) + filter;
                return DeviceTypeDal.GetAllList(InventoryManagementContext, filterExpression);
            }

            return DeviceTypeDal.GetAllList(InventoryManagementContext, filterExpression => filterExpression.IsActive == true);
        }

        public DeviceType GetByFilter(Func<DeviceType, bool> filter)
        {
            return DeviceTypeDal.GetByFilter(InventoryManagementContext, filter);
        }
    }
}
