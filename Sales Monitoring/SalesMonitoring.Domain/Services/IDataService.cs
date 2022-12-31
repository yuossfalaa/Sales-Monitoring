using Sales_Monitoring.SalesMonitoring.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales_Monitoring.SalesMonitoring.Domain.Services
{
    public interface IDataService<T>
    {
        List<T> GetAll();
        List<Order> GetAllOrdersBetweenDates(DateTime Start, DateTime End);
        T Get(int id);
        Items Get(string name);
        T Create(T entity);
        T Update(int id, T entity);
        bool Delete(T entity);

    }
}
