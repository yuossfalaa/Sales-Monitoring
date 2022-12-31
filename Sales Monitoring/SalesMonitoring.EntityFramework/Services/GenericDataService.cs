using Sales_Monitoring.SalesMonitoring.Domain.Models;
using Sales_Monitoring.SalesMonitoring.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Sales_Monitoring.SalesMonitoring.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly SalesMonitoringDbContextFactory _contextFactory;

        public GenericDataService(SalesMonitoringDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using(SalesMonitoringDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return createdResult.Entity;
            }
        }

        public async Task<bool> Delete(T entity)
        {
            using (SalesMonitoringDbContext context = _contextFactory.CreateDbContext())
            {
                T ToBeDeletedEntity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == entity.Id);
                context.Set<T>().Remove(ToBeDeletedEntity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<T> Get(int id)
        {
            using (SalesMonitoringDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<List<T>> GetAll()
        {

            using (SalesMonitoringDbContext context = _contextFactory.CreateDbContext())
            {
                List<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        public async Task<List<Order>> GetAllOrdersBetweenDates(DateTime Start, DateTime End)
        {
            using (SalesMonitoringDbContext context = _contextFactory.CreateDbContext())
            {
                List<Order> entities = await context.Set<Order>().Where(e => e.Date >= Start && e.Date <= End).ToListAsync();
                return entities;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (SalesMonitoringDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }
    }
}
