using Sales_Monitoring.SalesMonitoring.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales_Monitoring.SalesMonitoring.Domain.Services
{
    public interface IDataService<T>
    {
        //crud func
        List<T> GetAll();
        T Get(int id);
        T Create(T entity);
        T Update(int id, T entity);
        bool Delete(T entity);

        //custom Func
        Items Get(string name);
        ItemSales GetItemSalesByName(string name);
        ItemSales GetItemSales(int Itemid);
        ItemSales ItemsSalesUpdateByName(string name, ItemSales entity);
        List<OrderCollection> GetAllOrdersBetweenDates(DateTime Start, DateTime End);
        List<RecordExpenses> GetAllExpensesBetweenDates(DateTime Start, DateTime End);

    }
}
