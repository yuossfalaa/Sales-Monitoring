using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Sales_Monitoring.SalesMonitoring.EntityFramework;
using Sales_Monitoring.ViewModels;
using Sales_Monitoring.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Sales_Monitoring
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly SalesMonitoringDbContextFactory _contextFactory = new SalesMonitoringDbContextFactory();

        protected override void OnStartup(StartupEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-UK");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-UK");
            using (SalesMonitoringDbContext context = _contextFactory.CreateDbContext())
            {
                context.Database.Migrate();
            }
            Window window = new MainWindow();
            MainViewModel viewModel = new MainViewModel();
            window.DataContext = viewModel;
            window.Show();
            base.OnStartup(e);
        }
    }
}
