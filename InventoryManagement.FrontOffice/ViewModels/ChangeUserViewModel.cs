using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using GalaSoft.MvvmLight.CommandWpf;
using InventoryManagement.Bll.BusinessLogic;
using InventoryManagement.Bll.Enums;
using InventoryManagement.Bll.Statics;
using InventoryManagement.Entities.Tables;
using InventoryManagement.FrontOffice.Annotations;
using InventoryManagement.FrontOffice.Models;

namespace InventoryManagement.FrontOffice.ViewModels
{
    public class ChangeUserViewModel: INotifyPropertyChanged
    {
        // Commands
        public RelayCommand<string> SearchCommand { get; set; }
        public RelayCommand SubmitCommand { get; set; }
        public RelayCommand CleanCommand { get; set; }

        // Business Logic
        private OperationBll OperationBll { get; set; }
        private CompanyBll CompanyBll { get; }
        private LocationBll LocationBll { get; }

        // Models
        private ChangeUserModel _changeUser;
        public ChangeUserModel ChangeUserModel
        {
            get { return _changeUser; }
            set
            {
                _changeUser = value;
                if (value != null)
                {  
                    SelectedCompany = Company.FirstOrDefault(x => x.Id == value.CompanyId);
                    SelectedLocation = Location.FirstOrDefault(x => x.Id == value.LocationId);
                }
                OnPropertyChanged(nameof(ChangeUserModel));
            }
        }

        // Combobox Selected Models
        private CompanyModel _selectedCompanyModel;
        public CompanyModel SelectedCompany
        {
            get
            {
                return _selectedCompanyModel;
            }
            set
            {
                _selectedCompanyModel = value;
                OnPropertyChanged(nameof(SelectedCompany));
            }
        }

        private LocationModel _selectedLocation;
        public LocationModel SelectedLocation
        {
            get { return _selectedLocation; }
            set
            {
                _selectedLocation = value;
                OnPropertyChanged(nameof(SelectedLocation));
            }
        }

        // Models
        public ObservableCollection<CompanyModel> Company { get; set; }
        public ObservableCollection<LocationModel> Location { get; set; }
        public Operation Operation { get; set; }
        private Operation _searchOperation;

        // Enums
        private OperationTypeEnums OperationTypeEnums { get; }
        private StatusEnums StatusEnums { get; }

        // Constructor
        public ChangeUserViewModel()
        {
            CompanyBll = new CompanyBll();
            LocationBll = new LocationBll();
            OperationBll = new OperationBll();

            Company = new ObservableCollection<CompanyModel>();
            Location = new ObservableCollection<LocationModel>();

            SearchCommand = new RelayCommand<string>(OnSearch);
            SubmitCommand = new RelayCommand(OnSubmit);
            CleanCommand = new RelayCommand(onClean);

            OperationTypeEnums = new OperationTypeEnums();
            StatusEnums = new StatusEnums();

            BindData();
        }

        // Functions
        private void BindData()
        {
            var companies = CompanyBll.GetAllList(x => x.IsActive == true);
            foreach (var item in companies)
            {
                Company.Add(new CompanyModel() { Id = item.Id, Name = item.Name, Number = item.Number });
            }

            var locations = LocationBll.GetAllList(x => x.IsActive == true);
            foreach (var item in locations)
            {
                Location.Add(new LocationModel() { Id = item.Id, Name = item.Name });
            }
        }
        

        public void OnSearch(string inventoryNumber)
        {
            if (inventoryNumber != "")
            {
                _searchOperation = OperationBll.GetByFilter(x => x.Store.InventoryNumber == inventoryNumber && x.Guncel);
                if (_searchOperation != null)
                {
                    ChangeUserModel = new ChangeUserModel
                    {
                        DeviceType = _searchOperation.Store.Model.DeviceType.Name,
                        InventoryNumber = _searchOperation.Store.InventoryNumber,
                        Model = _searchOperation.Store.Model.Name,
                        OperationTime = _searchOperation.OperationTime,
                        Registrant = _searchOperation.User.Name + " " + _searchOperation.User.Surname,
                        SerialNumber = _searchOperation.Store.SerialNumber,
                        StoreId = _searchOperation.StoreId,
                        WarrantyStart = _searchOperation.Store.WarrantyStart,
                        CompanyId = _searchOperation.CompanyId,
                        LocationId = _searchOperation.LocationId,
                        Name = _searchOperation.Name,
                        Surname = _searchOperation.Surname,
                        UserId = LoggedInUser.LoggedUser.Id
                    };

                }
                else
                {
                    MessageBox.Show("Kayıt Bulunamadı", "Bilgilendirme Mesajı", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        public void OnSubmit()
        {
            if (ChangeUserModel.Name != _searchOperation.Name || ChangeUserModel.Surname != _searchOperation.Surname)
            {
                Operation = new Operation
                {
                    CompanyId = SelectedCompany.Id,
                    LocationId = SelectedLocation.Id,
                    Name = ChangeUserModel.Name,
                    Surname = ChangeUserModel.Surname,
                    OperationTypeId = OperationTypeEnums.KullaniciDegistir,
                    StoreId = ChangeUserModel.StoreId,
                    UserId = LoggedInUser.LoggedUser.Id,
                    UpdatededDate = DateTime.Now,
                    Guncel = true
                };
            }

            var result = OperationBll.AddOrUpdate(Operation);
            if (result)
            {
                MessageBox.Show("Kayıt Girildi", "Bilgilendirme Mesajı", MessageBoxButton.OK, MessageBoxImage.Information);
                var oldOperation = OperationBll.GetByFilter(x => x.Id == _searchOperation.Id);
                oldOperation.Guncel = false;
                result = OperationBll.AddOrUpdate(oldOperation);

                onClean();
            }
        }

        public void onClean()
        {
            ChangeUserModel = new ChangeUserModel();
            SelectedCompany = new CompanyModel();
            SelectedLocation = new LocationModel();
        }

        // Signatures
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
