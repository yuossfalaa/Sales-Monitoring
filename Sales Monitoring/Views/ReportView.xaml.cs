using Sales_Monitoring.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sales_Monitoring.Views
{
    /// <summary>
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : UserControl
    {
        public ReportView()
        {
            InitializeComponent();
        }

        private void DataGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ReportViewModel viewModel = (ReportViewModel)DataContext;
            if (viewModel.RowDetailsVisible == DataGridRowDetailsVisibilityMode.Collapsed)
            {
                viewModel.RowDetailsVisible = DataGridRowDetailsVisibilityMode.VisibleWhenSelected;
            }
            else
            {
                viewModel.RowDetailsVisible = DataGridRowDetailsVisibilityMode.Collapsed;
            }
        }
    }
}
