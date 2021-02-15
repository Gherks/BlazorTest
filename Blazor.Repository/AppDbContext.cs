using Blazor.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
