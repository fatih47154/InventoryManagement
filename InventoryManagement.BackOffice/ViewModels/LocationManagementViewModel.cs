using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DevExpress.Mvvm;
using InventoryManagement.BackOffice.Models;
using InventoryManagement.EfDal.Context;
using InventoryManagement.Entities.Tables;

namespace InventoryManagement.BackOffice.ViewModels
{
    public class LocationManagementViewModel : Screen
    {
        private InventoryManagementContext _inventoryManagementContext;
        public virtual IList<Location> Locations { get; protected set; }
        public virtual IList<LocationModel> LocationModels { get; set; }

        public LocationManagementViewModel()
        {
            if (!ViewModelBase.IsInDesignMode)
                InitializeInRuntime();
            else
                InitializeInDesingMode();
        }
        void InitializeInRuntime()
        {
            _inventoryManagementContext = new InventoryManagementContext();
            Locations = _inventoryManagementContext.Locations.ToList();
            LocationModels = new List<LocationModel>();
            foreach (var item in Locations)
            {
                var locationModel = new LocationModel()
                {
                    Name = item.Name
                };
                LocationModels.Add(locationModel);
            }
        }

        void InitializeInDesingMode()
        {

        }
    }
}
