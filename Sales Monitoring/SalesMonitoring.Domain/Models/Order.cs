using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Documents;

namespace Sales_Monitoring.SalesMonitoring.Domain.Models
{
    public class Order : DomainObject
    {
        #region Prop With INotify
        private List<Items> _item { get; set; }
        public List<Items> item
        {
            get { return _item; }
            set { _item = value; RaisePropertyChanged("item"); }
        }
       
        #endregion
        public DateTime? Date { get; set; } 
        public string? Type { get; set; }
        public int? Count { get; set; }
        public double? Tax { get; set; }
        public double? Discount { get; set; }
        public double? Roundoff { get; set; }
        public double? TotalBill { get; set; }
        public string? Payment { get; set; }


        #region RaisePropertyChanged
        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


    }
}
