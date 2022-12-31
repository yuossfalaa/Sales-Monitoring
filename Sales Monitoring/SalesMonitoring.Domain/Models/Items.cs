using System.ComponentModel;

namespace Sales_Monitoring.SalesMonitoring.Domain.Models
{
    public class Items : DomainObject
    {
        
        public string ItemName { get; set; }
        public double? ItemInstorePrice { get; set; }
        public double? ItemZomatoPrice { get; set; }
        public double? ItemSwiggyPrice { get; set; }
        private int? _quantity { get; set; }
        public int? Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                RaisePropertyChanged("Quantity");
            }
        }
        #region RaisePropertyChanged
        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
