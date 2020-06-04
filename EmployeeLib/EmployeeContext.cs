using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EmployeeLib.Model
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("DbConnection")
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Subdivision> Subdivisions { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
