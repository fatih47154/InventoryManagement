using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using InventoryManagement.FrontOffice.Interface;
using InventoryManagement.FrontOffice.ViewModels;

namespace InventoryManagement.FrontOffice.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window, IClosable
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();   
        }
    }
}
