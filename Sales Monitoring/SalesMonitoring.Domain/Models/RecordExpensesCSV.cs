using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Monitoring.SalesMonitoring.Domain.Models
{
    public class RecordExpensesCSV
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public string ItemName { get; set; }
        public string VendorName { get; set; }
        public string TaxId { get; set; }
        public double Amount { get; set; }
        public string Mode { get; set; }
    }
}
