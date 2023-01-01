using Sales_Monitoring.SalesMonitoring.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales_Monitoring.SalesMonitoring.Domain.Services
{
    public interface IDataService<T>
    {
        List<T> GetAll();
        List<OrderCollection> GetAllOrdersBetweenDates(DateTime Start, DateTime End);
        T Get(int id);
        Items Get(string name);
        ItemSales GetItemSalesByName(string name);
        ItemSales GetItemSales(int Itemid);
        ItemSales ItemsSalesUpdateByName(string name, ItemSales entity);
        T Create(T entity);
        T Update(int id, T entity);
        bool Delete(T entity);

    }
}
