using Sales_Monitoring.Commands;
using Sales_Monitoring.SalesMonitoring.Domain.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Sales_Monitoring.ViewModels
{
    public class ReportViewModel : ViewModelBase
    {
        #region Private Objects
        private ObservableCollection<RecordExpenses> _Expenses;
        private ObservableCollection<Order> _Orders;
        #endregion

        #region Private Variables
        private bool _ProductWiseSales;
        private bool _Overallsales;
        private DateTime _dateselected;
        private Visibility _Visibility_ProductWiseSales;
        private Visibility _Visibility_Overallsales;
        #endregion

        #region Public Objects
        public ObservableCollection<RecordExpenses> Expenses
        {
            get { return _Expenses; }
            set { _Expenses = value; RaisePropertyChanged("Expenses"); }
        }
        public ObservableCollection<Order> Orders 
        { 
            get { return _Orders; }
            set { _Orders = value; RaisePropertyChanged("Orders"); }
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
            //Expenses = new ObservableCollection<RecordExpenses>(TestData.getdataExpenses());
            ProductWiseSales = true;
            Visibility_ProductWiseSales = Visibility.Visible;
            //Orders = new ObservableCollection<Order>(TestData.getdataorder());
            DateSelected = DateSelectedView();
        }


        #endregion
        #region Private Method 
        private DateTime DateSelectedView()
        {
            if (UpdateCurrentViewModelCommand.ViewTypeName == "ReportViewDay") { return DateTime.Now; }
            else if (UpdateCurrentViewModelCommand.ViewTypeName == "ReportViewWeak") { return DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek); ; }
            else { return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); }
        }
        #endregion

    }
}
