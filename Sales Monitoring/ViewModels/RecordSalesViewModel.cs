using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Sales_Monitoring.ViewModels
{
    public class RecordSalesViewModel : ViewModelBase
    {
        #region Constructor
        public RecordSalesViewModel()
        {
            items = new ObservableCollection<Items>(TestData.getdataItem());
            order = new ObservableCollection<Order>(TestData.getdataorder());
            AddItemCommand = new RelayCommand<Order>(Additem, true);
            RemoveItemCommand = new RelayCommand<Order>(Removeitem, true);
            AddItemToOrderCommand = new RelayCommand<Items>(AddItemToOrder, true);
            SaveBillCommand = new RelayCommand<ObservableCollection<Order>>(SaveBill, true);
            QuantityTextChangedCommand = new RelayCommand<Order>(QuantityTextChanged, true);
            SearchTextChangedCommand = new RelayCommand<string>(SearchItem, true);
            CashSelected = true;


            //For Example
            //Should implement function to calculate this 
            TaxesLabel = "90";
            RoundoffLabel = "0.30";
            DiscountLabel = "2.5";
        }
        #endregion

        #region Commands
        public ICommand AddItemCommand { get; private set; }
        public ICommand RemoveItemCommand { get; private set; }
        public ICommand AddItemToOrderCommand { get; private set; }
        public ICommand SaveBillCommand { get; private set; }
        public ICommand QuantityTextChangedCommand { get; private set; }
        public ICommand SearchTextChangedCommand { get; private set; }

        #endregion

        #region private objects
        private ObservableCollection<Items> _items { get; set; }
        public ObservableCollection<Order> _order { get; set; }
        #endregion

        #region Public objects
        public ObservableCollection<Items> items
        {
            get
            {
                return _items;
            }
            set 
            { 
                _items = value;
                RaisePropertyChanged("items");

            }
        }
        public ObservableCollection<Order> order 
        {
            get
            {
                return _order;
            }
            set
            {
                _order = value;
                RaisePropertyChanged("order");
            }
        }
        #endregion

        #region Private Variables
        private bool _cashselected { get; set; }
        private bool _cardselected { get; set; }
        private bool _upi_gpayselected { get; set; }
        private string _searchitemtext { get; set; }
        private string _taxeslabel { get; set; }
        private string _roundofflabel { get; set; }
        private string _discountlabel { get; set; }
        #endregion

        #region Public Variables
        public bool CashSelected
        {
            get { return _cashselected; }
            set
            {
                _cashselected = value;
                RaisePropertyChanged("CashSelected");
            }
        }     
        public bool CardSelected
        {
            get { return _cardselected; }
            set
            {
                _cardselected = value;
                RaisePropertyChanged("CardSelected");
            }
        }   
        public bool UPI_GPAYSelected
        {
            get { return _upi_gpayselected; }
            set
            {
                _upi_gpayselected = value;
                RaisePropertyChanged("UPI_GPAYSelected");
            }
        }
        public string SearchItemText
        {
            get { return _searchitemtext; }
            set
            {
                _searchitemtext = value;
                RaisePropertyChanged("SearchItemText");
                if (SearchItemText == "")
                {
                    GetAllITems();
                }
                else if (SearchItemText != "")
                {
                    SearchDB(SearchItemText);
                }
            }
        }
        public string TaxesLabel
        {
            get { return _taxeslabel; }
            set
            {
                _taxeslabel = value;
                RaisePropertyChanged("TaxesLabel");
            }
        } 
        public string RoundoffLabel
        {
            get { return _roundofflabel; }
            set
            {
                _roundofflabel = value;
                RaisePropertyChanged("RoundoffLabel");
            }
        } 
        public string DiscountLabel
        {
            get { return _discountlabel; }
            set
            {
                _discountlabel = value;
                RaisePropertyChanged("DiscountLabel");
            }
        }
       

        #endregion

        #region Private Methods
        private void SearchItem(string itemname)
        {
            
            
        }
        private void Additem(Order Addedorder)
        {
            Addedorder.Quantity += 1;
        }
 
        private void Removeitem(Order ordertoberemoved)
        {
            if (ordertoberemoved.Quantity >= 1) ordertoberemoved.Quantity -= 1;
            if (ordertoberemoved.Quantity <= 0) order.Remove(ordertoberemoved);
        }
        private void QuantityTextChanged(Order ordertoberemoved)
        {
            if (ordertoberemoved.Quantity <= 0)
            {
                order.Remove(ordertoberemoved);

            }
        }
        private void AddItemToOrder(Items item)
        {
            order.Add(new Order { item =item ,Quantity=1});
        }
        /// <summary>
        /// Take Order List 
        /// then Send it To The DB
        /// </summary>
        /// <param name="order"></param>
        private void SaveBill(ObservableCollection<Order> order)
        {
            //Write Logic To Save Here 
        }
        /// <summary>
        /// Search Db For Item And Send The Item To ObservableCollection<Items> items
        /// use the items Object To Search the Db
        /// Clear ObservableCollection<Items> items using items.Clear(); before next Step
        /// Set ObservableCollection<Items> items to the Result Comming from DB
        /// </summary>
        /// <param name="ItemName"></param>
        private void SearchDB(string ItemName)
        {
            Items item = new Items();
            item.ItemName = ItemName;
        
        }
        /// <summary>
        /// Get All Items From Db As A list Then Set ObservableCollection<Items> items to That List
        /// Set ObservableCollection<Items> items to the Result Comming from DB
        /// </summary>
        private void GetAllITems()
        {            
            
        }
        #endregion

    }
}
