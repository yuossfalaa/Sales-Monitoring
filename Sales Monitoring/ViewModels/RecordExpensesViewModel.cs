using CommunityToolkit.Mvvm.Input;
using Sales_Monitoring.SalesMonitoring.Domain.Models;
using Sales_Monitoring.SalesMonitoring.Domain.Services;
using Sales_Monitoring.SalesMonitoring.EntityFramework;
using Sales_Monitoring.SalesMonitoring.EntityFramework.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Sales_Monitoring.ViewModels
{
    public class RecordExpensesViewModel : ViewModelBase
    {
        #region Commands
        public ICommand AddRecordCommand { get;private set; }
        public ICommand DeleteSelectedItem { get;private set; }
        public ICommand EditSelectedItemCommand { get;private set; }
        #endregion
        #region BackGround Workers
        public BackgroundWorker DBGetAll = new BackgroundWorker();
        #endregion
        #region Private Objects
        private ObservableCollection<RecordExpenses> _Expenses;
        private RecordExpenses _recordtobeadded;
        private RecordExpenses _selecteditem;
        #endregion
        #region Public Objects
        public ObservableCollection<RecordExpenses> Expenses
        {
            get { return _Expenses; }
            set { _Expenses = value; RaisePropertyChanged("Expenses"); }
        }
        public RecordExpenses RecordtobeAdded
        {
            get { return _recordtobeadded;}
            set { _recordtobeadded = value; RaisePropertyChanged("RecordtobeAdded"); }
        }
        public RecordExpenses SelectedItem
        {
            get { return _selecteditem; }
            set { _selecteditem = value; RaisePropertyChanged("SelectedItem"); }
        }
        #endregion

        public  RecordExpensesViewModel()
        {
            //Commands
            AddRecordCommand = new RelayCommand(AddRecord);
            DeleteSelectedItem = new RelayCommand(DeleteRecord);
            EditSelectedItemCommand = new RelayCommand(EditSelectedItem);
            //Get info From DB
            DBGetAll.DoWork += (obj, e) => GetAll();
            DBGetAll.RunWorkerAsync();
            //Vars
            RecordtobeAdded = new RecordExpenses();
            RecordtobeAdded.Date = DateTime.Now;
        }

        #region Private Method
        private void EditSelectedItem()
        {
            if (SelectedItem.ItemName == null) SelectedItem.ItemName = "Item";
            if (SelectedItem.VendorName == null) SelectedItem.ItemName = "Vendor";
            if (SelectedItem.TaxId == null) SelectedItem.ItemName = "TaxId";
            if (SelectedItem.Mode == null) SelectedItem.Mode = "UPI";
            if (SelectedItem.Amount == null) SelectedItem.Amount = 0;
            if (SelectedItem.Date == null) SelectedItem.Date = DateTime.Now;
            try
            {
                IDataService<RecordExpenses> EditRecord = new GenericDataService<RecordExpenses>(new SalesMonitoringDbContextFactory());
                EditRecord.Update(SelectedItem.Id, SelectedItem);

            }
            catch { }
        }

        private void DeleteRecord()
        {
            if (SelectedItem != null)
            {
                try
                {
                    IDataService<RecordExpenses> DeleteRecord = new GenericDataService<RecordExpenses>(new SalesMonitoringDbContextFactory());
                    DeleteRecord.Delete(SelectedItem);
                    Expenses.Remove(SelectedItem);
                }
                catch {; }
            }

        }
        private void AddRecord()
        {
            if (RecordtobeAdded != null)
            {
                try
                {
                    if (RecordtobeAdded.ItemName == null) RecordtobeAdded.ItemName = "Item";
                    if (RecordtobeAdded.VendorName == null) RecordtobeAdded.ItemName = "Vendor";
                    if (RecordtobeAdded.TaxId == null) RecordtobeAdded.ItemName = "TaxId";
                    if (RecordtobeAdded.Mode  == null) RecordtobeAdded.Mode = "UPI";
                    if (RecordtobeAdded.Amount == null) RecordtobeAdded.Amount = 0;
                    if (RecordtobeAdded.Date == null) RecordtobeAdded.Date = DateTime.Now;
                    Expenses.Add(RecordtobeAdded);
                    IDataService<RecordExpenses> AddRecordToDb = new GenericDataService<RecordExpenses>(new SalesMonitoringDbContextFactory());
                    AddRecordToDb.Create(RecordtobeAdded);
                    RecordtobeAdded = null;
                    RecordtobeAdded = new RecordExpenses();


                }
                catch {; }


            }
            RecordtobeAdded.Date = DateTime.Now;
            RaisePropertyChanged(nameof(RecordtobeAdded));



        }
        private void GetAll()
        {
            IDataService<RecordExpenses> GetAllRecord = new GenericDataService<RecordExpenses>(new SalesMonitoringDbContextFactory());
            Expenses = new ObservableCollection<RecordExpenses>(GetAllRecord.GetAll());
        }
        
        #endregion
    }
}
