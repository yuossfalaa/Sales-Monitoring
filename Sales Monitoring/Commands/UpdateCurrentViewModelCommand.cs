using Sales_Monitoring.State.Navigators;
using Sales_Monitoring.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sales_Monitoring.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private INavigator _navigator;

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
                        break;
                    case ViewType.HomeView:
                        _navigator.CurrentViewModel = new HomeViewModel();
                        break;
                    case ViewType.RecordExpenses:
                        _navigator.CurrentViewModel = new RecordExpensesViewModel();
                        break;
                    case ViewType.RecordSales:
                        _navigator.CurrentViewModel = new RecordSalesViewModel();
                        break;
                    case ViewType.ReportView:
                        _navigator.CurrentViewModel = new ReportViewModel();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}