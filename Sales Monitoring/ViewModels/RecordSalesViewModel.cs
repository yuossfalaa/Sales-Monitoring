using GalaSoft.MvvmLight.Command;
using Sales_Monitoring.Commands;
using Sales_Monitoring.SalesMonitoring.Domain.Models;
using Sales_Monitoring.SalesMonitoring.Domain.Services;
using Sales_Monitoring.SalesMonitoring.EntityFramework.Services;
using Sales_Monitoring.SalesMonitoring.EntityFramework;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace Sales_Monitoring.ViewModels
{
    public class RecordSalesViewModel : ViewModelBase
    {
        #region BackGround Workers
        public BackgroundWorker DBGetAll = new BackgroundWorker();
        #endregion

        #region Constructor
        public RecordSalesViewModel()
        {
            //Get info From DB
            DBGetAll.DoWork += (obj, e) => GetAll();
            DBGetAll.RunWorkerAsync();
            AddItemCommand = new RelayCommand<Order>(Additem);
            RemoveItemCommand = new RelayCommand<Order>(Removeitem);
            AddItemToOrderCommand = new RelayCommand<Items>(AddItemToOrder, true);
            SaveBillCommand = new RelayCommand(SaveBill, true);
            QuantityTextChangedCommand = new RelayCommand<Order>(QuantityTextChanged, true);
            SearchTextChangedCommand = new RelayCommand(SearchItem, true);
            //TaxesTextChangedCommand = new RelayCommand(TaxesTextChanged, true);
            RoundoffTextChangedCommand = new RelayCommand(RoundoffText, true);
            DiscountTextChangedCommand = new RelayCommand(DiscountText, true);
            PriceChangedCommand = new RelayCommand(Pricechange, true);
            CashSelected = true;
            StoreName = checkStoreName();
            TaxesLabel = 0.0;
            RoundoffLabel = 0.0;
            DiscountLabel = 0.0;
            TotalBill = 0;
            order = new ObservableCollection<Order>();
        }



        #endregion

        #region Commands
        public ICommand AddItemCommand { get; private set; }
        public ICommand RemoveItemCommand { get; private set; }
        public ICommand AddItemToOrderCommand { get; private set; }
        public ICommand SaveBillCommand { get; private set; }
        public ICommand QuantityTextChangedCommand { get; private set; }
        public ICommand SearchTextChangedCommand { get; private set; }
        public ICommand RoundoffTextChangedCommand { get; private set; }
        public ICommand DiscountTextChangedCommand { get; private set; }
        public ICommand TaxesTextChangedCommand { get; private set; }
        public ICommand PriceChangedCommand { get; private set; }

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
        private string _storename { get; set; }
        private string _searchitemtext { get; set; }
        private double? _taxeslabel { get; set; }
        private double _roundofflabel { get; set; }
        private double _discountlabel { get; set; }
        private double? _TotalBill { get; set; }
        private bool taxesadded = false;
        private bool discountadded = false;
        private bool roundoffadded = false;
        private double taxesamount=0;
        private double discountamount=0;
        private double roundoffamount=0;

        private Visibility _InstorePriceTextBoxVisibility { get; set; }
        private Visibility _ZomatoPriceTextBoxVisibility { get; set; }
        private Visibility _SwiggyPriceTextBoxVisibility { get; set; }
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
        public string StoreName
        {
            get { return _storename; }
            set
            {
                _storename = value;
                RaisePropertyChanged("StoreName");
            }
        }
        public string SearchItemText
        {
            get { return _searchitemtext; }
            set
            {
                _searchitemtext = value;
                RaisePropertyChanged("SearchItemText");
                
            }
        }
        public double? TaxesLabel
        {
            get { return _taxeslabel; }
            set
            {
                if (_taxeslabel != value)
                {
                    _taxeslabel = value;
                    RaisePropertyChanged("TaxesLabel");
                }

            }
        } 
        public double RoundoffLabel
        {
            get { return _roundofflabel; }
            set
            {
                if (_roundofflabel != value)
                {
                    _roundofflabel = value;
                    RaisePropertyChanged("RoundoffLabel");
                }

            }
        } 
        public double DiscountLabel
        {
            get { return _discountlabel; }
            set
            {
                if (_discountlabel != value)
                {
                    _discountlabel = value;
                    RaisePropertyChanged("DiscountLabel");
                }
                
            }
        }
        public double? TotalBill
        {
            get { return _TotalBill; }
            set
            {
                _TotalBill = value;
                RaisePropertyChanged("TotalBill");
            }
        }
        public Visibility InstorePriceTextBoxVisibility
        {
            get { return _InstorePriceTextBoxVisibility; }
            set { _InstorePriceTextBoxVisibility = value; RaisePropertyChanged("InstorePriceTextBoxVisibility"); }
        }
        public Visibility ZomatoPriceTextBoxVisibility
        {
            get { return _ZomatoPriceTextBoxVisibility; }
            set { _ZomatoPriceTextBoxVisibility = value; RaisePropertyChanged("ZomatoPriceTextBoxVisibility"); }
        }
        public Visibility SwiggyPriceTextBoxVisibility
        {
            get { return _SwiggyPriceTextBoxVisibility; }
            set { _SwiggyPriceTextBoxVisibility = value; RaisePropertyChanged("SwiggyPriceTextBoxVisibility"); }
        }


        #endregion

        #region Private Methods
        private void GetAll()
        {
            IDataService<Items> GetAllRecord = new GenericDataService<Items>(new SalesMonitoringDbContextFactory());
            items = new ObservableCollection<Items>(GetAllRecord.GetAll());
        }
        private string checkStoreName()
        {
            if (UpdateCurrentViewModelCommand.ViewTypeName == "RecordSales") 
            {
                InstorePriceTextBoxVisibility = Visibility.Visible;
                ZomatoPriceTextBoxVisibility = Visibility.Collapsed;
                SwiggyPriceTextBoxVisibility = Visibility.Collapsed;
                return "In Store";
            }
            else if (UpdateCurrentViewModelCommand.ViewTypeName == "RecordSalesZomato") 
            {
                InstorePriceTextBoxVisibility = Visibility.Collapsed;
                ZomatoPriceTextBoxVisibility = Visibility.Visible;
                SwiggyPriceTextBoxVisibility = Visibility.Collapsed;
                return "Zomato";
            }
            else 
            {
                InstorePriceTextBoxVisibility = Visibility.Collapsed;
                ZomatoPriceTextBoxVisibility = Visibility.Collapsed;
                SwiggyPriceTextBoxVisibility = Visibility.Visible;
                return "Swiggy";
            }
        }
        private void SearchItem()
        {

            if (SearchItemText == "" || SearchItemText == null)
            {
                items.Clear();
                DBGetAll.RunWorkerAsync();
            }
            else
            {
                IDataService<Items> SearchRecord = new GenericDataService<Items>(new SalesMonitoringDbContextFactory());

                if (SearchRecord.Get(SearchItemText) != null)
                {
                    items.Clear();
                    items = new ObservableCollection<Items>();
                    items.Add(SearchRecord.Get(SearchItemText));

                }


            }
        }
        private void AddItemToOrder(Items item)
        {
            Order ordertobeadded = new Order();
            ordertobeadded.ItemName = item.ItemName;
            ordertobeadded.Quantity = 1;
            ordertobeadded.TaxesPercentage = item.TaxesPercentage;
            order.Add(ordertobeadded);
            if (StoreName == "In Store")
            {
                ordertobeadded.Price = item.ItemInstorePrice;
            }
            else if (StoreName == "Zomato")
            {
                ordertobeadded.Price = item.ItemZomatoPrice;
            }
            else
            {
                ordertobeadded.Price = item.ItemSwiggyPrice;
            }
            RecalculatTotal();

        }
        private void RecalculatTotal()
        {
            TotalBill = 0;
            TaxesLabel = 0;
            foreach (Order obj in order)
            {
                TotalCalculator(obj.Quantity, obj.Price, obj.TaxesPercentage);
            }
            discountadded = false;
            roundoffadded = false;
            DiscountText();
            RoundoffText();
        }
        private void DiscountText()
        {
            if (discountadded)
            {
                TotalBill += discountamount;
                TotalBill -= DiscountLabel;
                discountamount = DiscountLabel;
                discountadded = true;
            }
            else
            {
                TotalBill -= DiscountLabel;
                discountamount = DiscountLabel;
                discountadded = true;
            }



        }
        private void RoundoffText()
        {
            if (roundoffadded)
            {
                TotalBill += roundoffamount;
                TotalBill -= RoundoffLabel;
                roundoffamount = RoundoffLabel;
                roundoffadded = true;
            }
            else
            {
                TotalBill -= RoundoffLabel;
                roundoffamount = RoundoffLabel;
                roundoffadded = true;
            }

        }
        private void QuantityTextChanged(Order ordertoberemoved)
        {
            if (ordertoberemoved.Quantity <= 0) order.Remove(ordertoberemoved);
            RecalculatTotal();
        }
        private void Pricechange()
        {
            RecalculatTotal();
        }

        private void TotalCalculator(int? Quantity , double? price, double? taxesPercentage)
        {
            TotalBill += 
                (Quantity * price) +
                ((Quantity * price)*(taxesPercentage/100));

            TaxesLabel +=
                ((Quantity * price) *(taxesPercentage / 100));

            TotalBill = Math.Round((double)TotalBill, 2);
            TaxesLabel = Math.Round((double)TaxesLabel, 2);
            
        }
        private void Additem(Order Addedorder)
        {
            Addedorder.Quantity++;
            RecalculatTotal();
        }
        private void Removeitem(Order ordertoberemoved)
        {
            if (ordertoberemoved.Quantity >= 1) ordertoberemoved.Quantity -= 1;
            if (ordertoberemoved.Quantity <= 0) order.Remove(ordertoberemoved);
            RecalculatTotal();

        }
        private void SaveBill()
        {
            IDataService<OrderCollection> SaveOrder = new GenericDataService<OrderCollection>(new SalesMonitoringDbContextFactory());
            OrderCollection ordercollection = new OrderCollection();
            ordercollection.orders = order;
            ordercollection.Count = order.Count;
            ordercollection.Date= DateTime.Now;
            ordercollection.Type = StoreName;
            ordercollection.Tax = TaxesLabel;
            ordercollection.Discount = DiscountLabel;
            ordercollection.Roundoff = RoundoffLabel;
            ordercollection.TotalBill = TotalBill;

            if (CardSelected)
            {
                ordercollection.Payment = "Card";

            }
            else if (CashSelected)
            {
                ordercollection.Payment = "Cash";
            }
            else if (UPI_GPAYSelected)
            {
                ordercollection.Payment = "UPI/GPAY";

            }

            SaveOrder.Create(ordercollection);
            //Edit Sales
            IDataService<ItemSales> SaveItemSales = new GenericDataService<ItemSales>(new SalesMonitoringDbContextFactory());
            foreach (Order obj in order)
            {
                ItemSales item =new ItemSales();
                item = SaveItemSales.GetItemSalesByName(obj.ItemName);
                if (item.Taxes == null) item.Taxes = 0;

                if (item.QtyInStore == null) item.QtyInStore = 0;
                if (item.InStoreSales == null) item.InStoreSales = 0;

                if (item.QtyZomato == null) item.QtyZomato = 0;
                if (item.ZomatoSales == null) item.ZomatoSales = 0;

                if (item.QtySwiggy == null) item.QtySwiggy = 0;
                if (item.SwiggySales == null) item.SwiggySales = 0;

                item.Taxes += 
                    (obj.Quantity * obj.Price)*
                    ( obj.TaxesPercentage/100);

                if (StoreName == "In Store")
                {
                    item.QtyInStore += obj.Quantity;
                    item.InStoreSales += obj.Quantity * obj.Price;

                }
                else if (StoreName == "Zomato")
                {
                    item.QtyZomato += obj.Quantity;
                    item.ZomatoSales += obj.Quantity * obj.Price;
                }
                else
                {
                    item.QtySwiggy += obj.Quantity;
                    item.SwiggySales += obj.Quantity * obj.Price;
                }

                SaveItemSales.Update(item.Id,item);
            }
            //Cleaning
            TaxesLabel = 0;
            DiscountLabel=0;
            RoundoffLabel = 0; 
            TotalBill=0;
            order.Clear();

        }
        #endregion

    }
}
