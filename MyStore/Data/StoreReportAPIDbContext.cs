using Microsoft.EntityFrameworkCore;
using MyStore.Models;

namespace MyStore.Data
{
    public class StoreReportAPIDbContext : DbContext
    {
        public StoreReportAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<StoreReport> StoreReports { get; set; }
    }
}
