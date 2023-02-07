using System;

namespace Sales_Monitoring.SalesMonitoring.Domain.Models
{
    public class OrderCollecionCSV
    {
        public string? Date { get; set; }
        public string? Time { get; set; }
        public string? Type { get; set; }
        public int? Count { get; set; }
        public string ItemName { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public double? Tax { get; set; }
        public double? Discount { get; set; }
        public double? Roundoff { get; set; }
        public double? TotalBill { get; set; }
        public string? Payment { get; set; }

    }
}
