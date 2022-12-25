using Sales_Monitoring.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sales_Monitoring.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get;set; } = new Navigator();
        
        public MainViewModel()
        {

        }



    }
}
