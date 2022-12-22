using System.Collections.Generic;
using System.Windows.Media;

namespace Sales_Monitoring
{
    public class TestData
    {

        static public List<Items> getdataItem()
        {
            List<Items> Data = new List<Items>
            {
                new Items { ItemName = "item #1" , ItemPrice = 500, color = new SolidColorBrush(Color.FromRgb(116, 185, 255))},
                new Items { ItemName = "item #2" , ItemPrice = 200, color = new SolidColorBrush(Color.FromRgb(116, 185, 255))},
                new Items { ItemName = "item #3" , ItemPrice = 200, color = new SolidColorBrush(Color.FromRgb(214, 48, 49))},
                new Items { ItemName = "item #4" , ItemPrice = 300, color = new SolidColorBrush(Color.FromRgb(0, 184, 148))},
                new Items { ItemName = "item #1" , ItemPrice = 8500, color = new SolidColorBrush(Color.FromRgb(116, 185, 255))},
                new Items { ItemName = "item #2" , ItemPrice = 900, color = new SolidColorBrush(Color.FromRgb(116, 185, 255))},
                new Items { ItemName = "item #3" , ItemPrice = 700, color = new SolidColorBrush(Color.FromRgb(214, 48, 49))},
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
   