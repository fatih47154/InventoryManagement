using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using GalaSoft.MvvmLight.CommandWpf;
using InventoryManagement.Bll.BusinessLogic;
using InventoryManagement.Bll.Statics;
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
        public RelayCommand<IClosable> LogInCommand { get; private set; }

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
            this.LogInCommand = new RelayCommand<IClosable>(this.LogIn);
        }

        public void LogIn(IClosable loginWindow)
        {
            var user = LoginBll.Login(_userName, _password);
            
            if (user != null)
            {
                LoggedInUser.LoggedUser = user;

                loginWindow.Close();
                var dashboardView = new DashboardView();
                dashboardView.Show();
            }
            else
            {
                MessageBox.Show("Girdiğiniz Kullanıcı Bilgileri Eşleşmiyor", "Giriş Hatası", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void Close()
        {
            Application.Current.Shutdown();
        }
    }
}
