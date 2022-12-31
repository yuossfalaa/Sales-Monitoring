using Sales_Monitoring.SalesMonitoring.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales_Monitoring.SalesMonitoring.Domain.Services
{
    public interface IDataService<T>
    {
        Task<List<T>> GetAll();
        Task<List<Order>> GetAllOrdersBetweenDates(DateTime Start, DateTime End);
        Task<T> Get(int id);
        Task<T> Create(T entity);
        Task<T> Update(int id, T entity);
        Task<bool> Delete(T entity);

    }
}
