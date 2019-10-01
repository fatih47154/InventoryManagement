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

namespace InventoryManagement.FrontOffice.ViewModels
{
    public class SearchUpdateViewModel : Screen
    {
        private InventoryManagementContext _inventoryManagementContext;
        public virtual IList<Operation> Operations { get; protected set; }
        public virtual IList<Update> Updates { get; set; }
        public SearchUpdateViewModel()
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
            Updates = new List<Update>();
            foreach (var item in Operations)
            {
                var update = new Update()
                {
                    Status = item.Status.Name,
                    Name = item.Name,
                    Surname = item.Surname,
                    Model = item.Store.Model.Name,
                    SerialNumber = item.Store.SerialNumber,
                    Description = item.description,
                    DeviceType = item.Store.Model.DeviceType.Name,
                    InventoryNumber = item.Store.InventoryNumber,
                    WarrantyStart = item.Store.WarrantyStart,
                    Location = item.Location.Name,
                    Company = item.Company.Name
                };
                Updates.Add(update);
            }
        }

        void InitializeInDesingMode()
        {

        }
    }
}
