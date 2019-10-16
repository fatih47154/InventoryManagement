using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Dal.Context;
using InventoryManagement.Dal.DataAccess;
using InventoryManagement.Entities.Tables;
using InventoryManagement.IDal.IDal;
using InventoryManagement.IDal.IRepository;

namespace InventoryManagement.Bll.BusinessLogic
{
    public class OperationBll: IOperationDal
    {
        private OperationDal OperationDal { get; }
        private InventoryManagementContext InventoryManagementContext { get; set; }
        private Expression<Func<Operation, object>>[] IncludeExpressions { get; }

        public OperationBll()
        {
            OperationDal = new OperationDal();
            InventoryManagementContext = new InventoryManagementContext();
            IncludeExpressions = new Expression<Func<Operation, object>>[6] {
                properties => properties.User,
                properties => properties.Location,
                properties => properties.Company,
                properties => properties.Store.Status,
                properties => properties.Store.Model.DeviceType,
                properties => properties.OperationType

            };
        }
        
        public bool AddOrUpdate(Operation entity)
        {
            var result = OperationDal.AddOrUpdate(InventoryManagementContext, entity);
            OperationDal.Save(InventoryManagementContext);
            return result;
        }

        public bool Delete(Func<Operation, bool> filter)
        {
            try
            {
                OperationDal.Delete(InventoryManagementContext, filter);
                OperationDal.Save(InventoryManagementContext);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<Operation> GetAllList(Func<Operation, bool> filter = null)
        {
            if (filter != null)
            {
                Func<Operation, bool> filterExpression = (x => x.IsActive == true) + filter;
                return OperationDal.GetAllList(InventoryManagementContext, filterExpression,
                    IncludeExpressions);
            }

            return OperationDal.GetAllList(InventoryManagementContext, filterExpression => filterExpression.IsActive == true,
                IncludeExpressions);
        }

        public Operation GetByFilter(Func<Operation, bool> filter)
        {
            return OperationDal.GetByFilter(InventoryManagementContext, filter,
                IncludeExpressions);
        }
    }
}
