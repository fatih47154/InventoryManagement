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
    public class OperationTypeBll: IBusinessRepository<OperationType>
    {
        public OperationTypeDal OperationTypeDal { get; set; }
        public InventoryManagementContext InventoryManagementContext { get; set; }

        public OperationTypeBll()
        {
            OperationTypeDal = new OperationTypeDal();
            InventoryManagementContext = new InventoryManagementContext();
        }

        public bool AddOrUpdate(OperationType entity)
        {
            var result = OperationTypeDal.AddOrUpdate(InventoryManagementContext, entity);
            OperationTypeDal.Save(InventoryManagementContext);
            return result;
        }

        public bool Delete(Func<OperationType, bool> filter)
        {
            try
            {
                OperationTypeDal.Delete(InventoryManagementContext, filter);
                OperationTypeDal.Save(InventoryManagementContext);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<OperationType> GetAllList(Func<OperationType, bool> filter = null)
        {
            if (filter != null)
            {
                Func<OperationType, bool> filterExpression = (x => x.IsActive == true) + filter;
                return OperationTypeDal.GetAllList(InventoryManagementContext, filterExpression);
            }

            return OperationTypeDal.GetAllList(InventoryManagementContext, filterExpression => filterExpression.IsActive == true);
        }

        public OperationType GetByFilter(Func<OperationType, bool> filter)
        {
            return OperationTypeDal.GetByFilter(InventoryManagementContext, filter);
        }
    }
}
