using CommunityToolkit.Mvvm.Input;
using Sales_Monitoring.SalesMonitoring.Domain.Models;
using Sales_Monitoring.SalesMonitoring.Domain.Services;
using Sales_Monitoring.SalesMonitoring.EntityFramework;
using Sales_Monitoring.SalesMonitoring.EntityFramework.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Sales_Monitoring.ViewModels
{
    public class RecordExpensesViewModel : ViewModelBase
    {
        #region Commands
        public ICommand AddRecordCommand { get;private set; }
        #endregion
        #region BackGround Workers
        public BackgroundWorker DBGetAll = new BackgroundWorker();
        #endregion
        #region Private Objects
        private ObservableCollection<RecordExpenses> _Expenses;
        private RecordExpenses _recordtobeadded;
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
        #endregion
        public  RecordExpensesViewModel()
        {
            //Commands
            AddRecordCommand = new RelayCommand(AddRecord);
            //Get info From DB
            DBGetAll.DoWork += (obj, e) => GetAll();
            DBGetAll.RunWorkerAsync();
            //Vars
            RecordtobeAdded = new RecordExpenses();
            RecordtobeAdded.Date = DateTime.Now;
        }
        #region Private Method
        private void AddRecord()
        {
            if (RecordtobeAdded != null)
            {
                Expenses.Add(RecordtobeAdded);
                IDataService<RecordExpenses> AddRecordToDb = new GenericDataService<RecordExpenses>(new SalesMonitoringDbContextFactory());
                AddRecordToDb.Create(RecordtobeAdded);

            }

        }
        private void GetAll()
        {
            IDataService<RecordExpenses> GetAllRecord = new GenericDataService<RecordExpenses>(new SalesMonitoringDbContextFactory());
            Expenses = new ObservableCollection<RecordExpenses>(GetAllRecord.GetAll());
        }
        #endregion
    }
}
