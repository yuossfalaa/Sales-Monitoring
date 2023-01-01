using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Monitoring.SalesMonitoring.Domain.Models
{
    public class ItemSales : DomainObject
    {
        public int? ItemID { get; set; }
        public string? ItemName { get; set; }
        public int? QtyInStore { get; set; }
        public double? InStoreSales { get; set; }
        public int? QtyZomato { get; set; }
        public double? ZomatoSales { get; set; }
        public int? QtySwiggy { get; set; }
        public double? SwiggySales { get; set; }

    }
}
