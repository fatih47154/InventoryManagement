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
    public class CompanyBll: IBusinessRepository<Company>
    {
        private CompanyDal CompanyDal { get; }
        private InventoryManagementContext InventoryManagementContext { get; set; }
        //private Expression<Func<Store, object>>[] IncludeExpressions { get; }
        public CompanyBll()
        {
            CompanyDal = new CompanyDal();
            InventoryManagementContext = new InventoryManagementContext();

            //IncludeExpressions = new Expression<Func<Company, object>>[1] {
            //
            //};
        }

        public bool AddOrUpdate(Company entity)
        {
            var result = CompanyDal.AddOrUpdate(InventoryManagementContext, entity);
            CompanyDal.Save(InventoryManagementContext);
            return result;
        }

        public bool Delete(Func<Company, bool> filter)
        {
            try
            {
                CompanyDal.Delete(InventoryManagementContext, filter);
                CompanyDal.Save(InventoryManagementContext);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<Company> GetAllList(Func<Company, bool> filter = null)
        {
            if (filter != null)
            {
                Func<Company, bool> filterExpression = (x => x.IsActive == true) + filter;
                return CompanyDal.GetAllList(InventoryManagementContext, filterExpression);
            }

            return CompanyDal.GetAllList(InventoryManagementContext, filterExpression => filterExpression.IsActive == true);
        }

        public Company GetByFilter(Func<Company, bool> filter)
        {
            return CompanyDal.GetByFilter(InventoryManagementContext, filter);
        }
    }
}
