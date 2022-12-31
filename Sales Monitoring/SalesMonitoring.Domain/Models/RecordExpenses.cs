using System;
using System.ComponentModel;

namespace Sales_Monitoring.SalesMonitoring.Domain.Models
{
    public class RecordExpenses : DomainObject
    {
        private DateTime _date;
        private string _itemname;
        private string _mode;
        private double _amount;
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; RaisePropertyChanged("Date"); }
        }
        public string ItemName 
        {
            get { return _itemname; }
            set { _itemname = value; RaisePropertyChanged("ItemName"); }
        }
        public double Amount
        {
            get { return _amount; }
            set { _amount = value; RaisePropertyChanged("Amount"); }
        }
        public string Mode
        {
            get { return _mode; }
            set { _mode = value; RaisePropertyChanged("Mode"); }
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
