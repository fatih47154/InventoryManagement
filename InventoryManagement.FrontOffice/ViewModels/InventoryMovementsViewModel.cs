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
    public class InventoryMovementsViewModel : Screen
    {
        private InventoryManagementContext _inventoryManagementContext;
        public virtual IList<Operation> Operations { get; protected set; }
        public virtual IList<Movement> Movements { get; set; }

        public InventoryMovementsViewModel()
        {
            if (!ViewModelBase.IsInDesignMode)
                InitializeInRuntime();
            else
                InitializeInDesingMode();
        }
        void InitializeInRuntime()
        {
            _inventoryManagementContext = new InventoryManagementContext();
            Operations = _inventoryManagementContext.Operations.ToList();
            Movements = new List<Movement>();
            foreach (var item in Operations)
            {
                var movements = new Movement
                {
                    Status = item.Status.Name,
                    Name = item.Name,
                    Surname = item.Surname,
                    Model = item.Store.Model.Name,
                    SerialNumber = item.Store.SerialNumber,
                    Description = item.description,
                    DeviceType = item.Store.Model.DeviceType.Name,
                    InventoryNumber = item.Store.InventoryNumber,
                    OperationType = item.OperationType.Name,
                    OperationTime = item.OperationTime,
                    Location = item.Location.Name,
                    Company = item.Company.Name
                };
                Movements.Add(movements);
            }
        }

        void InitializeInDesingMode()
        {
            
        }
    }
}
