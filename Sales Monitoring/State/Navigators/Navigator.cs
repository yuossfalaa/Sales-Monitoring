using Sales_Monitoring.ViewModels;
using Sales_Monitoring.Commands;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using System;

namespace Sales_Monitoring.State.Navigators
{
    public class Navigator : ViewModelBase , INavigator
    {
        private ViewModelBase _currentviewmodel;
        private Visibility homeviewvisibility;
        private Visibility homebuttonvisibility;

        public ICommand UpdateCurrentViewModelCommand => new Commands.UpdateCurrentViewModelCommand(this);
        public ICommand HomeVisibleCommand { get; private set; }

        public ViewModelBase CurrentViewModel
        {
            get { return _currentviewmodel; }
            set 
            { 
                _currentviewmodel = value; 
                RaisePropertyChanged("CurrentViewModel");
                if (CurrentViewModel != null) 
                {
                    HomeViewVisibility = Visibility.Collapsed;
                    HomeButtonVisibility = Visibility.Visible;
                }
             
            }
        }

        public Navigator()
        {
            HomeViewVisibility = Visibility.Visible;
            HomeButtonVisibility = Visibility.Collapsed;
            HomeVisibleCommand = new RelayCommand(VisbilityHandler,true);
        }

        public Visibility HomeViewVisibility
        {
            get
            {
                return homeviewvisibility;
            }
            set
            {
                homeviewvisibility = value;

                RaisePropertyChanged("HomeViewVisibility");
            }
        }
        public Visibility HomeButtonVisibility
        {
            get
            {
                return homebuttonvisibility;
            }
            set
            {
                homebuttonvisibility = value;

                RaisePropertyChanged("HomeButtonVisibility");
            }
        }


        private void VisbilityHandler()
        {
            HomeViewVisibility = Visibility.Visible;
            HomeButtonVisibility = Visibility.Collapsed;
            CurrentViewModel = null;
        }

    }
}
