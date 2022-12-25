using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace Sales_Monitoring.SalesMonitoring.Domain.Models
{
    public class TestData
    {

        static public List<Items> getdataItem()
        {
            List<Items> Data = new List<Items>
            {

                new Items { ItemName = "item #3" , ItemPrice = 700,ItemInstorePrice=700,ItemZomatoPrice= 550, ItemSwiggyPrice= 500},
                new Items { ItemName = "item #3" , ItemPrice = 700,ItemInstorePrice=700,ItemZomatoPrice= 550, ItemSwiggyPrice= 500},
                new Items { ItemName = "item #3" , ItemPrice = 700,ItemInstorePrice=700,ItemZomatoPrice= 550, ItemSwiggyPrice= 500},
                new Items { ItemName = "item #3" , ItemPrice = 700,ItemInstorePrice=700,ItemZomatoPrice= 550, ItemSwiggyPrice= 500},
                new Items { ItemName = "item #3" , ItemPrice = 700,ItemInstorePrice=700,ItemZomatoPrice= 550, ItemSwiggyPrice= 500},
                new Items { ItemName = "item #3" , ItemPrice = 700,ItemInstorePrice=700,ItemZomatoPrice= 550, ItemSwiggyPrice= 500},
                new Items { ItemName = "item #3" , ItemPrice = 700,ItemInstorePrice=700,ItemZomatoPrice= 550, ItemSwiggyPrice= 500},
                new Items { ItemName = "item #3" , ItemPrice = 700,ItemInstorePrice=700,ItemZomatoPrice= 550, ItemSwiggyPrice= 500},


            };
            return Data;
        }
        static public List<RecordExpenses> getdataExpenses()
        {
            List<RecordExpenses> Data = new List<RecordExpenses>
            {

               new RecordExpenses{ Date = DateTime.Now,ItemName="Item",Amount=20,Mode="Cash"},
               new RecordExpenses{ Date = DateTime.Now,ItemName="Item",Amount=250,Mode="Cash"},
               new RecordExpenses{ Date = DateTime.Now,ItemName="Item",Amount=20,Mode="Cash"},
               new RecordExpenses{ Date = DateTime.Now,ItemName="Item",Amount=260,Mode="Cash"},
               new RecordExpenses{ Date = DateTime.Now,ItemName="Item",Amount=20,Mode="Cash"},
               new RecordExpenses{ Date = DateTime.Now,ItemName="Item",Amount=230,Mode="Cash"},
               new RecordExpenses{ Date = DateTime.Now,ItemName="Item",Amount=20,Mode="Cash"},
               new RecordExpenses{ Date = DateTime.Now,ItemName="Item",Amount=20,Mode="Cash"},
            };
            return Data;
        }
        static public List<Order> getdataorder()
        {
            List<Order> Data = new List<Order>
            {
                new Order { item = new Items { ItemName = "item #1", ItemPrice = 500 },Quantity=55 },
                new Order { item = new Items { ItemName = "item #3", ItemPrice = 500 },Quantity=58 },
                new Order { item = new Items { ItemName = "item #2", ItemPrice = 500 },Quantity=58 },

               
            };
            return Data;
        }
    }
}
   