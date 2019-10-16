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
    public class InventoryMovementsViewModel : Screen
    {
        private OperationBll OperationBll { get; }
        private IList<Operation> Operations { get; set; }
        public IList<Movement> Movements { get; set; }

        public InventoryMovementsViewModel()
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
            Operations = OperationBll.GetAllList();

            Movements = new List<Movement>();
            foreach (var item in Operations)
            {
                var movements = new Movement
                {
                    Status = item.Store.Status.Name,
                    Name = item.Name,
                    Surname = item.Surname,
                    Model = item.Store.Model.Name,
                    SerialNumber = item.Store.SerialNumber,
                    Description = item.Description,
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
