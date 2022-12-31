using Sales_Monitoring.ViewModels;
using System.Windows.Input;

namespace Sales_Monitoring.State.Navigators
{
    public enum ViewType
    {
        EditMenu,
        HomeView,
        RecordExpenses,
        RecordSales,
        RecordSalesZomato,
        RecordSalesSwiggy,
        ReportViewDay,
        ReportViewWeak,
        ReportViewMonth,
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
