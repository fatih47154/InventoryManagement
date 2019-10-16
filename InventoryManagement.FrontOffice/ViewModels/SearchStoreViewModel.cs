using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DevExpress.Mvvm;
using InventoryManagement.Bll.BusinessLogic;
using InventoryManagement.Dal.Context;
using InventoryManagement.Entities.Tables;
using Store = InventoryManagement.Entities.Tables.Store;

namespace InventoryManagement.FrontOffice.ViewModels
{
    public class SearchStoreViewModel : Screen
    {
        private StoreBll StoreBll { get; }
        public virtual IList<Store> Stores { get; protected set; }
        public virtual IList<Models.Store> StoresModel { get; set; }
        public SearchStoreViewModel()
        {
            StoreBll = new StoreBll();
            if (!ViewModelBase.IsInDesignMode)
                InitializeInRuntime();
            else
                InitializeInDesingMode();
        }
        void InitializeInRuntime()
        {
            Stores = StoreBll.GetAllList();

            StoresModel = new List<Models.Store>();
            foreach (var item in Stores)
            {
                var store = new Models.Store()
                {
                    OperationTime = item.OperationTime,
                    InventoryNumber = item.InventoryNumber,
                    SerialNumber = item.SerialNumber,
                    WarrantyStart = item.WarrantyStart,
                    Model = item.Model.Name,
                    DeviceType = item.Model.DeviceType.Name,
                    Description = item.Description
                };
                StoresModel.Add(store);
            }
        }

        void InitializeInDesingMode()
        {

        }
    }
}
