using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Sales_Monitoring.SalesMonitoring.Domain.Models
{
    public class Order : DomainObject
    {
        #region Prop With INotify
        public string ItemName { get; set; }
        public double? Price { get; set; }
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
        #endregion

        public int? OrderCollectionId { get; set; }
        public OrderCollection? OrderCollection { get; set; }

    }
}
