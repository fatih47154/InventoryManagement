using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Bll.Repository;
using InventoryManagement.Dal.Context;
using InventoryManagement.Dal.DataAccess;
using InventoryManagement.Entities.Tables;
using InventoryManagement.IDal.IDal;
using InventoryManagement.IDal.IRepository;

namespace InventoryManagement.Bll.BusinessLogic
{
    public class OperationBll: BusinessRepositoryBase<InventoryManagementContext, Operation, OperationDal>
    {
        protected override void IncludeExpressionDefine()
        {
            IncludeExpressions = new Expression<Func<Operation, object>>[6] {
                 properties => properties.User,
                 properties => properties.Location,
                 properties => properties.Company,
                 properties => properties.Store.Status,
                 properties => properties.Store.Model.DeviceType,
                 properties => properties.OperationType
            };
        }
    }
}
