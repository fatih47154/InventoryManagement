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
    public class ChangeUserViewModel: Screen
    {
        public RelayCommand<string> SearchCommand { get; set; }
        public RelayCommand SubmitCommand { get; set; }
        private OperationBll OperationBll { get; set; }
        private CompanyBll CompanyBll { get; }
        private LocationBll LocationBll { get; }
        public ChangeUserModel ChangeUserModel { get; set; }
        public ObservableCollection<CompanyModel> Company { get; set; }
        public ObservableCollection<LocationModel> Location { get; set; }
        public Operation Operation { get; set; }
        private CompanyModel SelectedCompanyModel { get; set; }

        public CompanyModel SelectedCompany
        {
            get
            {
                return SelectedCompanyModel;
            }
            set
            {
                SelectedCompanyModel = value;
                NotifyOfPropertyChange(() => SelectedCompany);
            }
        }

        public LocationModel SelectedLocation { get; set; }
        private OperationTypeEnums OperationTypeEnums { get; }
        private StatusEnums StatusEnums { get; }
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
        public ChangeUserViewModel()
        {
            CompanyBll = new CompanyBll();
            LocationBll = new LocationBll();
            OperationBll = new OperationBll();
            ChangeUserModel = new ChangeUserModel();
            Company = new ObservableCollection<CompanyModel>();
            Location = new ObservableCollection<LocationModel>();
            SearchCommand = new RelayCommand<string>(OnSearch);
            SubmitCommand = new RelayCommand(OnSubmit);
            OperationTypeEnums = new OperationTypeEnums();
            StatusEnums = new StatusEnums();

            BindData();
        }

        public void OnSearch(string inventoryNumber)
        {
            if (inventoryNumber != "")
            {
                var operation = OperationBll.GetByFilter(x => x.Store.InventoryNumber == inventoryNumber);
                if (operation != null)
                {
                    ChangeUserModel.DeviceType = operation.Store.Model.DeviceType.Name;
                    ChangeUserModel.InventoryNumber = operation.Store.InventoryNumber;
                    ChangeUserModel.Model = operation.Store.Model.Name;
                    ChangeUserModel.OperationTime = operation.OperationTime;
                    ChangeUserModel.Registrant = operation.User.Name + " " + operation.User.Surname;
                    ChangeUserModel.SerialNumber = operation.Store.SerialNumber;
                    ChangeUserModel.StoreId = operation.Id;
                    ChangeUserModel.WarrantyStart = operation.Store.WarrantyStart;
                    ChangeUserModel.LocationId = operation.LocationId;
                    ChangeUserModel.CompanyId = operation.CompanyId;
                    ChangeUserModel.Name = operation.Name;
                    ChangeUserModel.Surname = operation.Surname;

                    SelectedCompany = new CompanyModel
                    {
                        Name = operation.Company.Name, Id = operation.CompanyId, Number = operation.Company.Number
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
            //Operation = new Operation();
            //Operation.CompanyId = SelectedCompany.Id;
            //Operation.LocationId = SelectedLocation.Id;
            //Operation.Name = ToUserFromStore.Name;
            //Operation.Surname = ToUserFromStore.Surname;
            //Operation.OperationTime = DateTime.Now;
            //Operation.OperationTypeId = OperationTypeEnums.DepodanKullaniciya;
            //Operation.StoreId = ToUserFromStore.StoreId;
            //Operation.UserId = LoggedInUser.LoggedUser.Id;
            //Operation.UpdatededDate = DateTime.Now;

            //var result = OperationBll.AddOrUpdate(Operation);
            //if (result)
            //{
            //    MessageBox.Show("Kayıt Girildi", "Bilgilendirme Mesajı", MessageBoxButton.OK, MessageBoxImage.Information);
            //    var store = StoreBll.GetByFilter(x => x.InventoryNumber == ToUserFromStore.InventoryNumber);
            //    store.Kullanimda = true;
            //    store.StatusId = StatusEnums.Kullanimda;
            //    result = StoreBll.AddOrUpdate(store);
            //}
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
