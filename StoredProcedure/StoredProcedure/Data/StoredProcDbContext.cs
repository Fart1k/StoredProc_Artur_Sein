using Microsoft.EntityFrameworkCore;
using StoredProcedure.Models;

namespace StoredProcedure.Data
{
    public class StoredProcDbContext : DbContext 
    {
        public StoredProcDbContext(DbContextOptions<StoredProcDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
