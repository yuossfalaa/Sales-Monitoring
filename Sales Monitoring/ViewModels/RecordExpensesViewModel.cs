using Sales_Monitoring.SalesMonitoring.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Monitoring.ViewModels
{
    public class RecordExpensesViewModel : ViewModelBase
    {
        #region Private Objects
        private ObservableCollection<RecordExpenses> _Expenses;
        #endregion
        #region Public Objects
        public ObservableCollection<RecordExpenses> Expenses
        {
            get { return _Expenses; }
            set { _Expenses = value; RaisePropertyChanged("Expenses"); }
        }
        #endregion
        public RecordExpensesViewModel()
        {
            //Expenses = new ObservableCollection<RecordExpenses>(TestData.getdataExpenses());
            
        }
    }
}
