using Microsoft.EntityFrameworkCore;
using Models;

namespace Data_Access_Layer.Data
{
    public class EmployeeDBContext : DbContext
    {

        public EmployeeDBContext(DbContextOptions dbContextOptions, DbContextOptions<EmployeeDBContext> options) : base(options)
        {

        }

      
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("WebAPI");
            base.OnModelCreating(builder);

        }

        public DbSet<Employee> Employees { get; set; }


    }
}
