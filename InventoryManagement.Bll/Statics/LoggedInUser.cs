using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Entities.Tables;

namespace InventoryManagement.Bll.Statics
{
    public static class LoggedInUser
    {
        public static User LoggedUser { get; set; }
    }
}
