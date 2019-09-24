using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.EfDal.DataAccess;
using InventoryManagement.Entities.Tables;
using InventoryManagement.IEfDal.IDal;

namespace InventoryManagement.Bll.BusinessLogic
{
    public class LoginBll : ILoginDal
    {
        public ILoginDal LoginDal { get; set; }

        public LoginBll()
        {
            LoginDal = new LoginDal();
        }
        public User Login(string userName, string password)
        {
            return LoginDal.Login(userName, password);
        }
    }
}
