namespace Sales_Monitoring.SalesMonitoring.Domain.Models
{
    public class Items : DomainObject
    {
        
        public string? ItemName { get; set; }
        public float? ItemPrice { get; set; }
        public float? ItemInstorePrice { get; set; }
        public float? ItemZomatoPrice { get; set; }
        public float? ItemSwiggyPrice { get; set; }

    }
}
