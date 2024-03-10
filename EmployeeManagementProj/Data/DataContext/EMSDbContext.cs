using EmployeeEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataContext
{
    public class EMSDbContext : DbContext
    {
        //This constructor is typically used to inject database connection information
        //into the context. When the context is created, the dependency injection system
        //provides an instance of which contains configuration information such as the
        //connection string.
        public EMSDbContext(DbContextOptions<EMSDbContext> options) : base(options) { }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<GradeMaster> GradeMaster { get; set; }
        public DbSet<UserMaster> UserMaster { get; set; }
    }
}
