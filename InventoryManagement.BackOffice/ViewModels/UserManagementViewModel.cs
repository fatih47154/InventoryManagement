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
using InventoryManagement.FrontOffice.Models;

namespace InventoryManagement.BackOffice.ViewModels
{
    public class UserManagementViewModel : Screen
    {
        private InventoryManagementContext _inventoryManagementContext;
        public virtual IList<User> Users { get; protected set; }
        public virtual IList<UsersModel> UsersModels { get; set; }

        public UserManagementViewModel()
        {
            if (!ViewModelBase.IsInDesignMode)
                InitializeInRuntime();
            else
                InitializeInDesingMode();
        }
        void InitializeInRuntime()
        {
            _inventoryManagementContext = new InventoryManagementContext();
            Users = _inventoryManagementContext.Users.ToList();
            UsersModels = new List<UsersModel>();
            foreach (var item in Users)
            {
                var user = new UsersModel()
                {
                    Name = item.Name,
                    Surname = item.Surname,
                    Company = item.Company.Name
                };
                UsersModels.Add(user);
            }
        }

        void InitializeInDesingMode()
        {

        }
    }
}
