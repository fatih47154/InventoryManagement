using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using InventoryManagement.Bll.BusinessLogic;
using InventoryManagement.Bll.Enums;
using InventoryManagement.Bll.Statics;
using InventoryManagement.Dal.Context;
using InventoryManagement.Entities.Tables;
using InventoryManagement.FrontOffice.Annotations;
using InventoryManagement.FrontOffice.Interface;
using InventoryManagement.FrontOffice.Models;
using Microsoft.Xaml.Behaviors.Core;

namespace InventoryManagement.FrontOffice.ViewModels
{
    public class ToUserFromStoreViewModel
    {
        public RelayCommand<string> SearchCommand { get; set; }
        public RelayCommand SubmitCommand { get; set; }
        private OperationBll OperationBll { get; set; }
        private StoreBll StoreBll { get; }
        private CompanyBll CompanyBll { get; }
        private LocationBll LocationBll { get; }
        public ToUserFromStoreModel ToUserFromStore { get; set; }
        public ObservableCollection<CompanyModel> Company { get; set; }
        public ObservableCollection<LocationModel> Location { get; set; }
        public Operation Operation { get; set; }
        public CompanyModel SelectedCompany { get; set; }
        public LocationModel SelectedLocation { get; set; }
        private OperationTypeEnums OperationTypeEnums { get; }
        private StatusEnums StatusEnums { get; }

        private void BindData()
        {
            var companies = CompanyBll.GetAllList(x => x.IsActive == true);
            foreach (var item in companies)
            {
                Company.Add(new CompanyModel() {Id = item.Id, Name = item.Name, Number = item.Number});
            }

            var locations = LocationBll.GetAllList(x => x.IsActive == true);
            foreach (var item in locations)
            {
                Location.Add(new LocationModel() {Id = item.Id, Name = item.Name});
            }
        }

        public ToUserFromStoreViewModel()
        {
            StoreBll = new StoreBll();
            CompanyBll = new CompanyBll();
            LocationBll = new LocationBll();
            OperationBll = new OperationBll();
            ToUserFromStore = new ToUserFromStoreModel();
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
                var store = StoreBll.GetByFilter(x => x.InventoryNumber == inventoryNumber && x.Kullanimda == false);
                if (store != null)
                {
                    ToUserFromStore.DeviceType = store.Model.DeviceType.Name;
                    ToUserFromStore.InventoryNumber = store.InventoryNumber;
                    ToUserFromStore.Model = store.Model.Name;
                    ToUserFromStore.OperationTime = DateTime.Now;
                    ToUserFromStore.Registrant = LoggedInUser.LoggedUser.Name + " " + LoggedInUser.LoggedUser.Surname;
                    ToUserFromStore.SerialNumber = store.SerialNumber;
                    ToUserFromStore.StoreId = store.Id;
                    ToUserFromStore.WarrantyStart = store.WarrantyStart;
                }
                else
                {
                    MessageBox.Show("Kayıt Bulunamadı", "Bilgilendirme Mesajı", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        public void OnSubmit()
        {
            Operation = new Operation();
            Operation.CompanyId = SelectedCompany.Id;
            Operation.LocationId = SelectedLocation.Id;
            Operation.Name = ToUserFromStore.Name;
            Operation.Surname = ToUserFromStore.Surname;
            Operation.OperationTime = DateTime.Now;
            Operation.OperationTypeId = OperationTypeEnums.DepodanKullaniciya;
            Operation.StoreId = ToUserFromStore.StoreId;
            Operation.UserId = LoggedInUser.LoggedUser.Id;
            Operation.UpdatededDate = DateTime.Now;

            var result = OperationBll.AddOrUpdate(Operation);
            if (result)
            {
                MessageBox.Show("Kayıt Girildi", "Bilgilendirme Mesajı", MessageBoxButton.OK, MessageBoxImage.Information);
                var store = StoreBll.GetByFilter(x => x.InventoryNumber == ToUserFromStore.InventoryNumber);
                store.Kullanimda = true;
                store.StatusId = StatusEnums.Kullanimda;
                result = StoreBll.AddOrUpdate(store);
            }
        }


    }
}
