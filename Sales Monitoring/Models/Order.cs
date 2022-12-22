using MVVM;

namespace Sales_Monitoring
{
    public class Order : ViewModelBase
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

        
    }
}
