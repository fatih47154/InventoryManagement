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
    public class StatusBll: IBusinessRepository<Status>
    {
        private StatusDal StatusDal { get; set; }
        private InventoryManagementContext InventoryManagementContext { get; set; }
        public StatusBll()
        {
            StatusDal = new StatusDal();
            InventoryManagementContext = new InventoryManagementContext();
        }
        public bool AddOrUpdate(Status entity)
        {
            var result = StatusDal.AddOrUpdate(InventoryManagementContext, entity);
            StatusDal.Save(InventoryManagementContext);
            return result;
        }

        public bool Delete(Func<Status, bool> filter)
        {
            try
            {
                StatusDal.Delete(InventoryManagementContext, filter);
                StatusDal.Save(InventoryManagementContext);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<Status> GetAllList(Func<Status, bool> filter = null)
        {
            if (filter != null)
            {
                Func<Status, bool> filterExpression = (x => x.IsActive == true) + filter;
                return StatusDal.GetAllList(InventoryManagementContext, filterExpression);
            }

            return StatusDal.GetAllList(InventoryManagementContext, filterExpression => filterExpression.IsActive == true);
        }

        public Status GetByFilter(Func<Status, bool> filter)
        {
            return StatusDal.GetByFilter(InventoryManagementContext, filter);
        }
    }
}
