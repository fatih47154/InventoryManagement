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
using InventoryManagement.FrontOffice.Models;

namespace InventoryManagement.FrontOffice.ViewModels
{
    public class SearchUpdateViewModel : Screen
    {
        private OperationBll OperationBll { get; }
        private IList<Operation> Operations { get; set; }
        public virtual IList<Update> Updates { get; set; }
        public SearchUpdateViewModel()
        {
            OperationBll = new OperationBll();
            if (!ViewModelBase.IsInDesignMode)
                InitializeInRuntime();
            else
                InitializeInDesingMode();
        }
        void InitializeInRuntime()
        {
            Operations = new List<Operation>();
            Operations = OperationBll.GetAllList(x => x.Store.Status.Name == "Kullanımda");
            
            Updates = new List<Update>();
            foreach (var item in Operations)
            {
                var update = new Update()
                {
                    Status = item.Store.Status.Name,
                    Name = item.Name,
                    Surname = item.Surname,
                    Model = item.Store.Model.Name,
                    SerialNumber = item.Store.SerialNumber,
                    Description = item.Description,
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
