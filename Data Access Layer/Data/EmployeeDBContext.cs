using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Data
{
    public class EmployeeDBContext : DbContext
    {

        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options)
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
