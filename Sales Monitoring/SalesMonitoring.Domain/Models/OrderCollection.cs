using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sales_Monitoring.SalesMonitoring.Domain.Models
{
    public class OrderCollection : DomainObject
    {
        public ObservableCollection<Order> orders { get; set; }
        public int? Count { get; set; }
        public DateTime? Date { get; set; }
        public string? Type { get; set; }
        public double? Tax { get; set; }
        public double? Discount { get; set; }
        public double? Roundoff { get; set; }
        public double? TotalBill { get; set; }
        public string? Payment { get; set; }


    }
}
