using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DevExpress.Mvvm;
using InventoryManagement.EfDal.Context;
using InventoryManagement.Entities.Tables;
using InventoryManagement.FrontOffice.Models;
using Store = InventoryManagement.FrontOffice.Models.Store;

namespace InventoryManagement.FrontOffice.ViewModels
{
    public class SearchStoreViewModel : Screen
    {
        private InventoryManagementContext _inventoryManagementContext;
        public virtual IList<Operation> Operations { get; protected set; }
        public virtual IList<InventoryManagement.FrontOffice.Models.Store> Stores { get; set; }
        public SearchStoreViewModel()
        {
            if (!ViewModelBase.IsInDesignMode)
                InitializeInRuntime();
            else
                InitializeInDesingMode();
        }
        void InitializeInRuntime()
        {
            _inventoryManagementContext = new InventoryManagementContext();
            Operations = _inventoryManagementContext.Operations.Where(x => x.Status.Name == "Kullanımda").ToList();
            Stores = new List<Store>();
            foreach (var item in Operations)
            {
                var store = new Store()
                {
                    Status = item.Status.Name,
                    Model = item.Store.Model.Name,
                    SerialNumber = item.Store.SerialNumber,
                    Description = item.description,
                    DeviceType = item.Store.Model.DeviceType.Name,
                    InventoryNumber = item.Store.InventoryNumber,
                    WarrantyStart = item.Store.WarrantyStart,
                };
                Stores.Add(store);
            }
        }

        void InitializeInDesingMode()
        {

        }
    }
}
