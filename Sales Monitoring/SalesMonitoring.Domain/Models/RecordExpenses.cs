using System;

namespace Sales_Monitoring.SalesMonitoring.Domain.Models
{
    public class RecordExpenses : DomainObject
    {
        public DateTime Date { get; set; }
        public string ItemName { get; set; }
        public double Amount { get; set; }
        public string Mode { get; set; }
    }
}
