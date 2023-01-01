using Microsoft.EntityFrameworkCore;
using Sales_Monitoring.SalesMonitoring.Domain.Models;

namespace Sales_Monitoring.SalesMonitoring.EntityFramework
{
    public class SalesMonitoringDbContext : DbContext
    {

        public DbSet<Items> Items { get;set;}
        public DbSet<ItemSales> ItemSales { get;set;}
        public DbSet<Order> Orders { get;set;}
        public DbSet<RecordExpenses> RecordExpenses { get;set;}
        public SalesMonitoringDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderCollection>().HasMany(a => a.orders).WithMany();
            base.OnModelCreating(modelBuilder);
        }

    }
}
