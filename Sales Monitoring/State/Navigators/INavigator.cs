using Sales_Monitoring.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sales_Monitoring.State.Navigators
{
    public enum ViewType
    {
        EditMenu,
        HomeView,
        RecordExpenses,
        RecordSales,
        ReportView
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
