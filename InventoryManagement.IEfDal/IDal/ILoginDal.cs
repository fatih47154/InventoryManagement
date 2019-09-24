using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Entities.Tables;

namespace InventoryManagement.IEfDal.IDal
{
    public interface ILoginDal
    {
        User Login(string userName, string password);
    }
}
