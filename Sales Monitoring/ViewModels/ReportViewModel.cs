using MaterialDesignThemes.Wpf;
using Sales_Monitoring.Commands;
using Sales_Monitoring.SalesMonitoring.Domain.Models;
using Sales_Monitoring.SalesMonitoring.Domain.Services;
using Sales_Monitoring.SalesMonitoring.EntityFramework.Services;
using Sales_Monitoring.SalesMonitoring.EntityFramework;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;

namespace Sales_Monitoring.ViewModels
{
    public class ReportViewModel : ViewModelBase
    {
        #region BackGround Workers
        public BackgroundWorker DBGetAll = new BackgroundWorker();
        #endregion
        #region Commands
        public ICommand SelectedDateChnagedCommand { get; private set; }

        #endregion
        #region Private Variables
        private bool _ProductWiseSales;
        private bool _Overallsales;
        private DateTime _dateselected;
        private Visibility _Visibility_ProductWiseSales;
        private Visibility _Visibility_Overallsales;
        #endregion
        #region Private Objects
        private ObservableCollection<RecordExpenses> _Expenses;
        private ObservableCollection<OrderCollection> _OrdersCollections;
        private ObservableCollection<ItemSales> _ItemSales;
        #endregion
        #region Public Objects
        public ObservableCollection<RecordExpenses> Expenses
        {
            get { return _Expenses; }
            set { _Expenses = value; RaisePropertyChanged("Expenses"); }
        }
        public ObservableCollection<OrderCollection> orderCollections 
        { 
            get { return _OrdersCollections; }
            set { _OrdersCollections = value; RaisePropertyChanged("orderCollections"); }
        }
        public ObservableCollection<ItemSales> ItemSales
        {
            get { return _ItemSales; }
            set { _ItemSales = value; RaisePropertyChanged("ItemSales");}
        }
        #endregion
        #region Public Variables
        public bool ProductWiseSales
        {
            get { return _ProductWiseSales; }
            set {
                _ProductWiseSales = value; 
                RaisePropertyChanged("ProductWiseSales"); 
                if (ProductWiseSales == true)
                {
                    Visibility_ProductWiseSales = Visibility.Visible;
                    Visibility_Overallsales = Visibility.Collapsed;
                }
                else
                {
                    Visibility_ProductWiseSales = Visibility.Collapsed;
                    Visibility_Overallsales = Visibility.Visible;

                }

            }
        }
        public bool Overallsales
        {
            get { return _Overallsales; }
            set 
            { 
                _Overallsales = value; 
                RaisePropertyChanged("Overallsales");
                if (Overallsales == true)
                {
                    Visibility_Overallsales = Visibility.Visible;
                    Visibility_ProductWiseSales = Visibility.Collapsed;
                }
                else
                {
                    Visibility_Overallsales = Visibility.Collapsed;
                    Visibility_ProductWiseSales = Visibility.Visible;

                }
            }
        }
        public Visibility Visibility_ProductWiseSales
        {
            get { return _Visibility_ProductWiseSales; }
            set { _Visibility_ProductWiseSales = value; RaisePropertyChanged("Visibility_ProductWiseSales"); }
        }
        public Visibility Visibility_Overallsales
        {
            get { return _Visibility_Overallsales; }
            set { _Visibility_Overallsales = value; RaisePropertyChanged("Visibility_Overallsales"); }
        }
        public DateTime DateSelected
        {
            get { return _dateselected; }
            set
            {
                _dateselected = value;
                RaisePropertyChanged("DateSelected");
            }
        }

        #endregion
        #region Constructor
        public ReportViewModel()
        {
            ProductWiseSales = true;
            Visibility_ProductWiseSales = Visibility.Visible;
            //commands
            SelectedDateChnagedCommand = new RelayCommand(SelectedDateChanged);
            DateSelected = DateSelectedView();
            //Get info From DB
            GetAll();
            DBGetAll.DoWork += (obj, e) => GetallItemSales();
            DBGetAll.RunWorkerAsync();


        }
        #endregion
        #region Private Method 
        private void GetallItemSales()
        {
            IDataService<ItemSales> GetAllRecord = new GenericDataService<ItemSales>(new SalesMonitoringDbContextFactory());
            ItemSales = new ObservableCollection<ItemSales>(GetAllRecord.GetAll());

        }
        private void SelectedDateChanged()
        {
            GetAll();
        }
        private void GetAll()
        {
            //Get Expenses 
            IDataService<RecordExpenses> GetAllExpensesRecord = new GenericDataService<RecordExpenses>(new SalesMonitoringDbContextFactory());
            IDataService<OrderCollection> GetAllorderRecord = new GenericDataService<OrderCollection>(new SalesMonitoringDbContextFactory());
            IDataService<Order> GetAllorders = new GenericDataService<Order>(new SalesMonitoringDbContextFactory());
            Expenses = new ObservableCollection<RecordExpenses>(GetAllExpensesRecord.GetAllExpensesBetweenDates(DateSelected, DateTime.Now));
            orderCollections = new ObservableCollection<OrderCollection>(GetAllorderRecord.GetAllOrdersBetweenDates(DateSelected, DateTime.Now));
            
            foreach(OrderCollection oc in orderCollections)
            {
                oc.orders=GetAllorders.GetAllorders(oc.Id);
            }

        }

        private DateTime DateSelectedView()
        {
            if (UpdateCurrentViewModelCommand.ViewTypeName == "ReportViewDay") { return StartOfDay(DateTime.Now); }
            else if (UpdateCurrentViewModelCommand.ViewTypeName == "ReportViewWeak") { return DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek); ; }
            else { return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); }
        }
        private DateTime StartOfDay(DateTime theDate)
        {
            return theDate.Date;
        }
        #endregion

    }
}
