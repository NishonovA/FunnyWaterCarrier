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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subdivision>()
                .HasMany(d => d.Employees)
                .WithRequired(us => us.Division);

            modelBuilder.Entity<Subdivision>()
                .HasOptional(d => d.Leader);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Orders)
                .WithRequired(o => o.Worker);

            base.OnModelCreating(modelBuilder);
        }
    }
}
