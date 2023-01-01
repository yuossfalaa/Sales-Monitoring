using System.ComponentModel;

namespace Sales_Monitoring.SalesMonitoring.Domain.Models
{
    public class Items : DomainObject
    {
        
        public string ItemName { get; set; }
        public double? ItemInstorePrice { get; set; }
        public double? ItemZomatoPrice { get; set; }
        public double? ItemSwiggyPrice { get; set; }

    }
}
