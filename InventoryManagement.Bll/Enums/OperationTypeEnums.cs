using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Bll.BusinessLogic;

namespace InventoryManagement.Bll.Enums
{
    public class OperationTypeEnums
    {
        private OperationTypeBll OperationTypeBll { get; set; }
        public static Guid KullanicidanDepoya { get; set; }
        public static Guid DepodanKullaniciya { get; set; }
        public static Guid DepoyaEklendi { get; set; }

        public OperationTypeEnums()
        {
            OperationTypeBll = new OperationTypeBll();
            KullanicidanDepoya = new Guid();
            DepodanKullaniciya = new Guid();
            DepoyaEklendi = new Guid();

            KullanicidanDepoya = OperationTypeBll.GetByFilter(x => x.Name == "Kullanıcıdan Depoya").Id;
            DepodanKullaniciya = OperationTypeBll.GetByFilter(x => x.Name == "Depodan Kullanıcıya").Id;
            DepoyaEklendi = OperationTypeBll.GetByFilter(x => x.Name == "Depoya Eklendi").Id;
        }

    }
}
