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
    public class CompanyManagementViewModel : Screen
    {
        private InventoryManagementContext _inventoryManagementContext;
        public virtual IList<Company> Companies { get; protected set; }
        public virtual IList<CompanyModel> CompanyModels { get; set; }

        public CompanyManagementViewModel()
        {
            if (!ViewModelBase.IsInDesignMode)
                InitializeInRuntime();
            else
                InitializeInDesingMode();
        }
        void InitializeInRuntime()
        {
            _inventoryManagementContext = new InventoryManagementContext();
            Companies = _inventoryManagementContext.Companies.ToList();
            CompanyModels = new List<CompanyModel>();
            foreach (var item in Companies)
            {
                var companyModel = new CompanyModel()
                {
                    Name = item.Name,
                    Number = item.Number
                };
                CompanyModels.Add(companyModel);
            }
        }

        void InitializeInDesingMode()
        {

        }
    }
}
