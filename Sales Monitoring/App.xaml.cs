using Sales_Monitoring.ViewModels;
using Sales_Monitoring.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Sales_Monitoring
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Window window = new MainWindow();

            MainViewModel viewModel= new MainViewModel();
            window.DataContext = viewModel;

            window.Show();

            base.OnStartup(e);
        }
    }
}
