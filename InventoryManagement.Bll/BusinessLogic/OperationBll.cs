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

        public OperationBll()
        {
            OperationDal = new OperationDal();
        }

        public IList<Operation> GetAllList()
        {
            return OperationDal.GetAllList(new InventoryManagementContext(), filterExpression => filterExpression.IsActive == true,
                properties => properties.User,
                properties => properties.Location,
                properties => properties.Company,
                properties => properties.Status,
                properties => properties.Store.Model.DeviceType,
                properties => properties.OperationType);
        }
    }
}
