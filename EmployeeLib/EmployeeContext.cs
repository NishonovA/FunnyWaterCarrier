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

        public DbSet<Employee> Employee { get; set; }
    }
}
