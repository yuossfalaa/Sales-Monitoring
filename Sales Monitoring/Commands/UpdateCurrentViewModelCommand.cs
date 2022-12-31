using Sales_Monitoring.State.Navigators;
using Sales_Monitoring.ViewModels;
using System;
using System.Windows.Input;

namespace Sales_Monitoring.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private INavigator _navigator;
        public static string ViewTypeName { get; set; }
        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType= (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.EditMenu:
                        _navigator.CurrentViewModel = new EditMenuViewModel();
                        ViewTypeName = "EditMenu";
                        break;
                    case ViewType.HomeView:
                        _navigator.CurrentViewModel = new HomeViewModel();
                        ViewTypeName = "HomeView";
                        break;
                    case ViewType.RecordExpenses:
                        _navigator.CurrentViewModel = new RecordExpensesViewModel();
                        ViewTypeName = "RecordExpenses";
                        break;
                    case ViewType.RecordSales:
                        _navigator.CurrentViewModel = new RecordSalesViewModel();
                        ViewTypeName = "RecordSales";
                        break;
                    case ViewType.RecordSalesZomato:
                        _navigator.CurrentViewModel = new RecordSalesViewModel();
                        ViewTypeName = "RecordSalesZomato";
                        break;
                    case ViewType.RecordSalesSwiggy:
                        _navigator.CurrentViewModel = new RecordSalesViewModel();
                        ViewTypeName = "RecordSalesSwiggy";
                        break;
                    case ViewType.ReportViewDay:
                        _navigator.CurrentViewModel = new ReportViewModel();
                        ViewTypeName = "ReportViewDay";
                        break;
                    case ViewType.ReportViewWeak:
                        _navigator.CurrentViewModel = new ReportViewModel();
                        ViewTypeName = "ReportViewWeak";
                        break;
                    case ViewType.ReportViewMonth:
                        _navigator.CurrentViewModel = new ReportViewModel();
                        ViewTypeName = "ReportViewMonth";
                        break;
                    default:
                        break;
                }
            }
        }
    }
}