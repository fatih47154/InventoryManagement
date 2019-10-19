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
    public class LocationBll: IBusinessRepository<Location>
    {
        private LocationDal LocationDal { get; }
        private InventoryManagementContext InventoryManagementContext { get; }

        public LocationBll()
        {
            LocationDal = new LocationDal();
            InventoryManagementContext = new InventoryManagementContext();
        }

        public bool AddOrUpdate(Location entity)
        {
            var result = LocationDal.AddOrUpdate(InventoryManagementContext, entity);
            LocationDal.Save(InventoryManagementContext);
            return result;
        }

        public bool Delete(Func<Location, bool> filter)
        {
            try
            {
                LocationDal.Delete(InventoryManagementContext, filter);
                LocationDal.Save(InventoryManagementContext);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<Location> GetAllList(Func<Location, bool> filter = null)
        {
            if (filter != null)
            {
                Func<Location, bool> filterExpression = (x => x.IsActive == true) + filter;
                return LocationDal.GetAllList(InventoryManagementContext, filterExpression);
            }

            return LocationDal.GetAllList(InventoryManagementContext, filterExpression => filterExpression.IsActive == true);
        }

        public Location GetByFilter(Func<Location, bool> filter)
        {
            return LocationDal.GetByFilter(InventoryManagementContext, filter);
        }
    }
}
