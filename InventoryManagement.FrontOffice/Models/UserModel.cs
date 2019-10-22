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
    public class UserModel: INotifyPropertyChanged
    {
        private Guid _id;
        private string _name;
        private string _surname;
        private string _nameSurname;

        public event PropertyChangedEventHandler PropertyChanged;

        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }

        public string NameSurname
        {
            get { return _name + " " + _surname; }
            set
            {
                _nameSurname = value;
                OnPropertyChanged("NameSurname");
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
