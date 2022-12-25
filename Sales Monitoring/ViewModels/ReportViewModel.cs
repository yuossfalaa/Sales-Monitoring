using Sales_Monitoring.SalesMonitoring.Domain.Models;
using System.Collections.ObjectModel;

namespace Sales_Monitoring.ViewModels
{
    public class ReportViewModel : ViewModelBase
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
        public ReportViewModel()
        {
            Expenses = new ObservableCollection<RecordExpenses>(TestData.getdataExpenses());

        }
    }
}
