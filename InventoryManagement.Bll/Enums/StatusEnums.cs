using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Bll.BusinessLogic;

namespace InventoryManagement.Bll.Enums
{
    public class StatusEnums
    {
        private StatusBll OperationTypeBll { get; set; }
        public static Guid Kullanimda { get; set; }
        public static Guid Depoda { get; set; }

        public StatusEnums()
        {
            OperationTypeBll = new StatusBll();
            Kullanimda = new Guid();
            Depoda = new Guid();

            Kullanimda = OperationTypeBll.GetByFilter(x => x.Name == "Kullanımda").Id;
            Depoda = OperationTypeBll.GetByFilter(x => x.Name == "Depoda").Id;
        }
    }
}
