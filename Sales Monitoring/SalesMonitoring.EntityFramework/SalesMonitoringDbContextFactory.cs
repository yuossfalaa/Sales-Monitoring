using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Sales_Monitoring.SalesMonitoring.EntityFramework
{
    public class SalesMonitoringDbContextFactory : IDesignTimeDbContextFactory<SalesMonitoringDbContext>
    {
        public SalesMonitoringDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<SalesMonitoringDbContext>();
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SalesMonitoringDb;Trusted_Connection=True;");
            return new SalesMonitoringDbContext(options.Options);

        }
    }
}
