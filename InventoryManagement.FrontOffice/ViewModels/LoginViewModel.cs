using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using GalaSoft.MvvmLight.CommandWpf;
using InventoryManagement.Bll.BusinessLogic;
using InventoryManagement.Entities.Tables;
using InventoryManagement.FrontOffice.Interface;
using InventoryManagement.FrontOffice.Views;

namespace InventoryManagement.FrontOffice.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName;
        private string _password;
        private LoginBll LoginBll { get; set; }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value; 
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public bool CanLogIn
        {
            get
            {
                var output = UserName?.Length > 0 && Password?.Length > 0;

                return output;
            }
        }

        public LoginViewModel()
        {
            LoginBll = new LoginBll();
        }

        public void LogIn()
        {
            var user = LoginBll.Login(_userName, _password);
            var dashboardView = new DashboardView();
            
            if (user != null)
            {
                dashboardView.Show();
            }
            else
            {
                
            }
        }

        public void Close()
        {
            Application.Current.Shutdown();
        }
    }
}
