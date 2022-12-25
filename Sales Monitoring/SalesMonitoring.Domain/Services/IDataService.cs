using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales_Monitoring.SalesMonitoring.Domain.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T entity);
        Task<T> Update(int id, T entity);
        Task<bool> Delete(T entity);

    }
}
