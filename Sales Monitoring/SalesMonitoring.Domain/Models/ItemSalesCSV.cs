using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Monitoring.SalesMonitoring.Domain.Models
{
    public class ItemSalesCSV
    {
        public string? Product_Name { get; set; }
        public int? Qty_InStore { get; set; }
        public double? In_Store_Sales { get; set; }
        public int? Qty_Zomato { get; set; }
        public double? Zomato_Sales { get; set; }
        public int? Qty_Swiggy { get; set; }
        public double? Swiggy_Sales { get; set; }
        public double? TaxesPercentage { get; set; }

    }
}
