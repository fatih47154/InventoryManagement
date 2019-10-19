using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.FrontOffice.Annotations;

namespace InventoryManagement.FrontOffice.Models
{
    public class ToUserFromStoreModel: INotifyPropertyChanged
    {
        private string _name;
        private string _surname;
        private string _deviceType;
        private string _model;
        private string _serialNumber;
        private string _inventoryNumber;
        private string _registrant;
        private DateTime _warrantyStart;
        private DateTime _operationTime;

        public Guid CompanyId { get; set; }
        public Guid LocationId { get; set; }
        public Guid StoreId { get; set; }
        public Guid UserId { get; set; }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; OnPropertyChanged("Surname"); }
        }

        public string DeviceType
        {
            get { return _deviceType; }
            set { _deviceType = value; OnPropertyChanged("DeviceType"); }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; OnPropertyChanged("Model"); }
        }

        public string SerialNumber
        {
            get { return _serialNumber; }
            set { _serialNumber = value; OnPropertyChanged("SerialNumber"); }
        }

        public string InventoryNumber
        {
            get { return _inventoryNumber; }
            set { _inventoryNumber = value; OnPropertyChanged("InventoryNumber"); }
        }

        public string Registrant
        {
            get { return _registrant; }
            set { _registrant = value; OnPropertyChanged("Registrant"); }
        }

        public DateTime WarrantyStart
        {
            get { return _warrantyStart; }
            set { _warrantyStart = value; OnPropertyChanged("WarrantyStart"); }
        }

        public DateTime OperationTime
        {
            get { return _operationTime; }
            set { _operationTime = value; OnPropertyChanged("OperationTime"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
