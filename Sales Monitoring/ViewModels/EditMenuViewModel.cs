using Sales_Monitoring.SalesMonitoring.Domain.Models;
using Sales_Monitoring.SalesMonitoring.Domain.Services;
using Sales_Monitoring.SalesMonitoring.EntityFramework.Services;
using Sales_Monitoring.SalesMonitoring.EntityFramework;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System;

namespace Sales_Monitoring.ViewModels
{
    public class EditMenuViewModel : ViewModelBase
    {
        #region Commands
        public ICommand AddingItemStartedCommand { get; private set; }
        public ICommand AddItemCommand { get; private set; }
        public ICommand SearchItemCommand { get; private set; }
        public ICommand DeleteSelectedItem { get; private set; }
        #endregion
        #region BackGround Workers
        public BackgroundWorker DBGetAll = new BackgroundWorker();
        #endregion
        #region Private Objects
        private ObservableCollection<Items> _items;
        private Items _selecteditem;

        #endregion
        #region Private Vars
        private bool _isaddingitems = false;
        private string _searchitemname;
        #endregion
        #region Public Objects
        public ObservableCollection<Items> items 
        {
            get { return _items; }
            set { _items = value; RaisePropertyChanged("items"); }
        }
        public Items SelectedItem
        {
            get { return _selecteditem; }
            set { _selecteditem = value; RaisePropertyChanged("SelectedItem"); }
        }
        #endregion
        #region Public Vars
        public string SearchItemName
        {
            get { return _searchitemname; }
            set { _searchitemname = value; RaisePropertyChanged("SearchItemName"); }
        }
        #endregion

        public EditMenuViewModel()
        {
            //Command
            AddItemCommand = new RelayCommand(AddItem);
            AddingItemStartedCommand = new RelayCommand(AddingItem);
            SearchItemCommand = new RelayCommand(SearchItem);
            DeleteSelectedItem = new RelayCommand(DeleteRecord);
            //Get info From DB
            DBGetAll.DoWork += (obj, e) => GetAll();
            DBGetAll.RunWorkerAsync();
        }


        #region Private Method
        private void DeleteRecord()
        {
            if (SelectedItem != null)
            {
                try
                {
                    IDataService<Items> DeleteRecord = new GenericDataService<Items>(new SalesMonitoringDbContextFactory());
                    DeleteRecord.Delete(SelectedItem);
                    items.Remove(SelectedItem);
                }
                catch {; }
            }
        }
        private void SearchItem()
        {
            if (SearchItemName == "" || SearchItemName == null)
            {
                items.Clear();
                DBGetAll.RunWorkerAsync();
            }
            else
            {
                IDataService<Items> SearchRecord = new GenericDataService<Items>(new SalesMonitoringDbContextFactory());

                if (SearchRecord.Get(SearchItemName) != null)
                {
                    items.Clear();
                    items = new ObservableCollection<Items>();
                    items.Add(SearchRecord.Get(SearchItemName));

                }


            }
        }
        private void AddingItem()
        {
            _isaddingitems = true;
        }
        private void AddItem()
        {
            IDataService<ItemSales> AddItemSalesRecord = new GenericDataService<ItemSales>(new SalesMonitoringDbContextFactory());
            IDataService<ItemSales> EditItemSalesRecord = new GenericDataService<ItemSales>(new SalesMonitoringDbContextFactory());
            IDataService<Items> AddItemRecord = new GenericDataService<Items>(new SalesMonitoringDbContextFactory());
            IDataService<Items> EditRecord = new GenericDataService<Items>(new SalesMonitoringDbContextFactory());

            if (_isaddingitems)
            {
                try
                {
                    AddItemRecord.Create(SelectedItem);


                    Items id = AddItemRecord.Get(SelectedItem.ItemName);
                    ItemSales itemSales= new ItemSales();
                    itemSales.ItemID = id.Id;
                    itemSales.ItemName = SelectedItem.ItemName;
                    itemSales.QtyInStore = 0;
                    itemSales.InStoreSales = 0;
                    itemSales.QtyZomato = 0;
                    itemSales.ZomatoSales = 0;
                    itemSales.QtySwiggy = 0;
                    itemSales.SwiggySales = 0;
                    itemSales.TaxesPercentage = 0;

                    AddItemSalesRecord.Create(itemSales);
                }
                catch { }

                _isaddingitems =false;
            }
            else if (!_isaddingitems)
            {
                if (SelectedItem.ItemName == null) SelectedItem.ItemName="Item";
                if (SelectedItem.ItemInstorePrice == null) SelectedItem.ItemInstorePrice = 0;
                if (SelectedItem.ItemSwiggyPrice == null) SelectedItem.ItemSwiggyPrice = 0;
                if (SelectedItem.ItemZomatoPrice == null) SelectedItem.ItemZomatoPrice = 0;
                if (SelectedItem.TaxesPercentage == null) SelectedItem.TaxesPercentage = 0;
                try
                {
                    EditRecord.Update(SelectedItem.Id, SelectedItem);
                     
                    ItemSales itemSales = EditItemSalesRecord.GetItemSales(SelectedItem.Id);
                    itemSales.ItemName=SelectedItem.ItemName;
                    EditItemSalesRecord.Update(itemSales.Id, itemSales);

                }
                catch { }
                _isaddingitems = false;

            }
        }
        private void GetAll()
        {
            IDataService<Items> GetAllRecord = new GenericDataService<Items>(new SalesMonitoringDbContextFactory());
            items = new ObservableCollection<Items>(GetAllRecord.GetAll());
        }
        #endregion
    }
}
