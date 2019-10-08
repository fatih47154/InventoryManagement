using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Dal.Context;
using InventoryManagement.Entities.Tables;
using InventoryManagement.IDal.IDal;

namespace InventoryManagement.Dal.DataAccess
{
    public class LoginDal : ILoginDal
    {
        private User User { get; set; }
        public User Login(string userName, string password)
        {
            var db = new InventoryManagementContext();
            var resultUser = db.Users.SingleOrDefault(x => x.Username == userName && x.Password == password);

            return resultUser;
        }
    }
}
