using Sales_Monitoring.SalesMonitoring.Domain.Models;
using System.Collections.ObjectModel;

namespace Sales_Monitoring.ViewModels
{
    public class EditMenuViewModel : ViewModelBase
    {
        #region Private Objects
        private ObservableCollection<Items> _items;
        #endregion
        #region Public Objects
        public ObservableCollection<Items> items 
        {
            get { return _items; }
            set { _items = value; RaisePropertyChanged("items"); }
        }
        #endregion
        public EditMenuViewModel()
        {
             items = new ObservableCollection<Items>(TestData.getdataItem());
        }
    }
}
