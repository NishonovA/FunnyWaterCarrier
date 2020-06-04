using EmployeeLib;
using EmployeeLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyWaterCarrier
{
    public class ServiceClient
    {
        public void CreateSubdivision(string department)
        {
            CreateSubdivision(new Subdivision()
            {
                Title = department
            });
        }

        public void CreateSubdivision(Subdivision subdivision)
        {
            using (var dbContext = new EmployeeContext())
            {
                dbContext.Subdivisions.Add(subdivision);
                dbContext.SaveChanges();
            }
        }

        public void CreateEmployee(string surname, string name, string patronymic, DateTime date)
        {
            CreateEmployee(new Employee()
            {
                Surname = surname,
                Name = name,
                Patronymic = patronymic,
                Birthday = date
            });
        }

        public void CreateEmployee(Employee employee)
        {
            using (var dbContext = new EmployeeContext())
            {
                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();
            }
        }

        public void CreateOrder(int number, string product)
        {
            CreateOrder(new Order()
            {
                Number = number,
                Product = product
            });
        }

        public void CreateOrder(Order order)
        {
            using (var dbContext = new EmployeeContext())
            {
                dbContext.Orders.Add(order);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<Subdivision> GetDivisions()
        {
            using (var dbContext = new EmployeeContext())
            {
                return dbContext.Subdivisions.ToList();
            }
        }
        public IEnumerable<Employee> GetEmployees()
        {
            using (var dbContext = new EmployeeContext())
            {
                return dbContext.Employees.ToList();
            }
        }
        public IEnumerable<Order> GetOrders()
        {
            using (var dbContext = new EmployeeContext())
            {
                return dbContext.Orders.ToList();
            }
        }
    }
}
