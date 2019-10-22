using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using InventoryManagement.Bll.Statics;
using InventoryManagement.FrontOffice.Models;

namespace InventoryManagement.FrontOffice.ViewModels
{
    public class DashboardViewModel : Screen
    {
        public UserModel UserModel { get; set; }

        public DashboardViewModel()
        {
            UserModel = new UserModel
            {
                Name = LoggedInUser.LoggedUser.Name,
                Surname = LoggedInUser.LoggedUser.Surname
            };
        }
    }
}
