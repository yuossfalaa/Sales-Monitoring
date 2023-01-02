using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Monitoring.SalesMonitoring.Domain.Models
{
    public class OrderCollecionCSV
    {
        public string ItemName { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
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
