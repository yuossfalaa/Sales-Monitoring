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

        public T Create(T entity)
        {

            using (SalesMonitoringDbContext context = _contextFactory.CreateDbContext())
            {
                    EntityEntry<T> createdResult = context.Set<T>().Add(entity);
                    context.SaveChanges();
                    return createdResult.Entity;
            }

        }

        public bool Delete(T entity)
        {
            using (SalesMonitoringDbContext context = _contextFactory.CreateDbContext())
            {
                T ToBeDeletedEntity = context.Set<T>().FirstOrDefault((e) => e.Id == entity.Id);
                context.Set<T>().Remove(ToBeDeletedEntity);
                context.SaveChanges();
                return true;
            }
        }

        public T Get(int id)
        {
            using (SalesMonitoringDbContext context = _contextFactory.CreateDbContext())
            {
                T entity =  context.Set<T>().FirstOrDefault((e) => e.Id == id);
                return entity;
            }
        }

        public Items Get(string name)
        {
            using (SalesMonitoringDbContext context = _contextFactory.CreateDbContext())
            {
                Items entity = context.Set<Items>().FirstOrDefault((e) => e.ItemName == name);
                return entity;
            }
        }

        public List<T> GetAll()
        {

            using (SalesMonitoringDbContext context = _contextFactory.CreateDbContext())
            {
                List<T> entities = context.Set<T>().ToList();
                return entities;
            }
        }

        public List<RecordExpenses> GetAllExpensesBetweenDates(DateTime Start, DateTime End)
        {
            using (SalesMonitoringDbContext context = _contextFactory.CreateDbContext())
            {
                List<RecordExpenses> entities = context.Set<RecordExpenses>().Where(e => e.Date >= Start && e.Date <= End.AddDays(1)).ToList();
                return entities;
            }
        }

        public  List<OrderCollection> GetAllOrdersBetweenDates(DateTime Start, DateTime End)
        {
            using (SalesMonitoringDbContext context = _contextFactory.CreateDbContext())
            {
                List<OrderCollection> entities = context.Set<OrderCollection>().Where(e => e.Date >= Start && e.Date <= End.AddDays(1)).ToList();
                return entities;
            }
        }

        public ItemSales GetItemSales(int Itemid)
        {
            using (SalesMonitoringDbContext context = _contextFactory.CreateDbContext())
            {
                ItemSales entity = context.Set<ItemSales>().FirstOrDefault((e) => e.ItemID == Itemid);
                return entity;
            }
        }

        public ItemSales GetItemSalesByName(string name)
        {
            using (SalesMonitoringDbContext context = _contextFactory.CreateDbContext())
            {
                ItemSales entity = context.Set<ItemSales>().FirstOrDefault((e) => e.ItemName == name);
                return entity;
            }
        }

        public ItemSales ItemsSalesUpdateByName(string name, ItemSales entity)
        {
            using (SalesMonitoringDbContext context = _contextFactory.CreateDbContext())
            {
                entity.ItemName = name;
                context.Set<ItemSales>().Update(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public T Update(int id, T entity)
        {
            using (SalesMonitoringDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                context.SaveChanges();
                return entity;
            }
        }

       
    }
}
