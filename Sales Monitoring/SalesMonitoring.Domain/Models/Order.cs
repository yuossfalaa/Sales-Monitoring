using System.ComponentModel;

namespace Sales_Monitoring.SalesMonitoring.Domain.Models
{
    public class Order : DomainObject
    {
        private Items _item { get; set; }
        public Items item
        {
            get { return _item; }
            set { _item = value; RaisePropertyChanged("item"); }
        }

        private int _quantity { get; set; }
        public int Quantity
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
