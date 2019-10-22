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
using InventoryManagement.IDal.IRepository;

namespace InventoryManagement.Bll.BusinessLogic
{
    public class CompanyBll: BusinessRepositoryBase<InventoryManagementContext, Company, CompanyDal>
    {

    }
}
