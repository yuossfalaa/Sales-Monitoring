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
using Microsoft.Win32;
using ServiceStack.Text;
using System.Linq;
using System.IO;

namespace Sales_Monitoring.ViewModels
{
    public class ReportViewModel : ViewModelBase
    {
        #region BackGround Workers
        public BackgroundWorker DBGetAll = new BackgroundWorker();
        #endregion
        #region Commands
        public ICommand SelectedDateChnagedCommand { get; private set; }
        public ICommand SelectedStoreTypeChnagedCommand { get; private set; }
        public ICommand ExportCommand { get; private set; }

        #endregion
        #region Private Variables
        private bool _ProductWiseSales;
        private bool _Overallsales;
        private DateTime _dateselected;
        private Visibility _Visibility_ProductWiseSales;
        private Visibility _Visibility_Overallsales;
        private bool _instoreSelected;
        private bool _ZomatoSelected;
        private bool _SwiggySelected;
        private double? _salestotal;
        private double? _expensestotal;

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
        public ObservableCollection<OrderCollecionCSV> OCCSV = new ObservableCollection<OrderCollecionCSV>();
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
        public bool InStoreSelected
        {
            get { return _instoreSelected; }
            set { _instoreSelected = value;RaisePropertyChanged("InStoreSelected"); }
        }
        public bool ZomatoSelected
        {
            get { return _ZomatoSelected; }
            set { _ZomatoSelected = value; RaisePropertyChanged("ZomatoSelected"); }
        }
        public bool SwiggySelected
        {
            get { return _SwiggySelected; }
            set { _SwiggySelected = value; RaisePropertyChanged("SwiggySelected"); }
        }
        public double? SalesTotal
        {
            get { return _salestotal; }
            set { _salestotal = value; RaisePropertyChanged("SalesTotal"); }
        }  
        public double? ExpensesTotal
        {
            get { return _expensestotal; }
            set { _expensestotal = value; RaisePropertyChanged("ExpensesTotal"); }
        }

        #endregion
        #region Constructor
        public ReportViewModel()
        {

            //init Vars
            ProductWiseSales = false;
            Overallsales = true;
            Visibility_ProductWiseSales = Visibility.Collapsed;
            Visibility_Overallsales = Visibility.Visible;
            InStoreSelected = true;
            ZomatoSelected = true;
            SwiggySelected = true;
            SalesTotal = 0;


            //commands
            SelectedDateChnagedCommand = new RelayCommand(SelectedDateChanged);
            SelectedStoreTypeChnagedCommand = new RelayCommand(SelectedStoreTypeChnaged);
            ExportCommand = new RelayCommand(Export);
            DateSelected = DateSelectedView();
            //Get info From DB
            GetAll();
            DBGetAll.DoWork += (obj, e) => GetallItemSales();
            DBGetAll.RunWorkerAsync();


        }
        #endregion
        #region Private Method 
        private void Export()
        {

            var sfd = new SaveFileDialog { Filter = "CSV|*.csv", FileName="Expenses",  AddExtension = true };
            if (sfd.ShowDialog().Value)
            {
                string dirPath = sfd.FileName;
                string csv = CsvSerializer.SerializeToCsv(Expenses.ToList());
                File.WriteAllText(dirPath, csv);
            }
            sfd = new SaveFileDialog { Filter = "CSV|*.csv", FileName = "Product Sales", AddExtension = true };
            if (sfd.ShowDialog().Value)
            {
                string dirPath = sfd.FileName;
                string csv = CsvSerializer.SerializeToCsv(ItemSales.ToList());
                File.WriteAllText(dirPath, csv);
            }
            sfd = new SaveFileDialog { Filter = "CSV|*.csv", FileName = "Overall Sales", AddExtension = true };
            if (sfd.ShowDialog().Value)
            {
                string dirPath = sfd.FileName;
                OrderCSVBuilder();
                string csv = CsvSerializer.SerializeToCsv(OCCSV.ToList());
                File.WriteAllText(dirPath, csv);
            }


        }
        private void OrderCSVBuilder()
        {
            foreach (OrderCollection e in orderCollections)
            {
                foreach (Order obj in e.orders)
                {
                    OrderCollecionCSV Temp = new OrderCollecionCSV();
                    Temp.ItemName = obj.ItemName;
                    Temp.Price= obj.Price;
                    Temp.Quantity= obj.Quantity;
                    Temp.Count = e.Count;
                    Temp.Date = e.Date;
                    Temp.Type = e.Type;
                    Temp.Tax = e.Tax;
                    Temp.Discount = e.Discount;
                    Temp.Roundoff = e.Roundoff;
                    Temp.TotalBill = e.TotalBill;
                    Temp.Payment = e.Payment;
                    OCCSV.Add(Temp);
                }
        
            }
        }
        private void SelectedStoreTypeChnaged()
        {
            GetallOrder();
            ObservableCollection<OrderCollection> Temp = new ObservableCollection<OrderCollection>(orderCollections);
            if (!InStoreSelected)
            {
                foreach (OrderCollection obj in Temp)
                {
                    if (obj.Type== "In Store") orderCollections.Remove(obj);
                }
            }
            if (!ZomatoSelected)
            {
                foreach (OrderCollection obj in Temp)
                {
                    if (obj.Type == "Zomato") orderCollections.Remove(obj);
                }
            }
            if (!SwiggySelected)
            {
                foreach (OrderCollection obj in Temp)
                {
                    if (obj.Type == "Swiggy") orderCollections.Remove(obj);
                }
            }
            if (!InStoreSelected && !ZomatoSelected && !SwiggySelected)
            {
                InStoreSelected = true;
                ZomatoSelected = true;
                SwiggySelected = true;
            }
            CalcSalesTotal();
            Temp = null;
        }
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
            Expenses = new ObservableCollection<RecordExpenses>(GetAllExpensesRecord.GetAllExpensesBetweenDates(DateSelected, DateTime.Now));
            GetallOrder();
            CalcSalesTotal();
            CalcExpensesTotal();

        }
        private void GetallOrder()
        {
            IDataService<Order> GetAllorders = new GenericDataService<Order>(new SalesMonitoringDbContextFactory());
            IDataService<OrderCollection> GetAllorderRecord = new GenericDataService<OrderCollection>(new SalesMonitoringDbContextFactory());
            orderCollections = new ObservableCollection<OrderCollection>(GetAllorderRecord.GetAllOrdersBetweenDates(DateSelected, DateTime.Now));
            foreach (OrderCollection oc in orderCollections)
            {
                oc.orders = GetAllorders.GetAllorders(oc.Id);
            }

        }
        private void CalcSalesTotal()
        {
            SalesTotal = 0;
            foreach (OrderCollection obj in orderCollections)
            {
                SalesTotal += obj.TotalBill;
            }
        }
        private void CalcExpensesTotal()
        {
            ExpensesTotal = 0;
            foreach (RecordExpenses obj in Expenses)
            {
                ExpensesTotal += obj.Amount;
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
