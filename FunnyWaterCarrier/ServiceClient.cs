using EmployeeLib;
using EmployeeLib.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyWaterCarrier
{
    public class ServiceClient
    {
        public void CreateSubdivision(string title, Employee leader) //Создание нового подразделения
        {
            CreateSubdivision(new Subdivision()
            {
                Title = title,
                Leader = leader
            });
        }

        public void CreateSubdivision(Subdivision subdivision)  //Добавление подразделения в БД
        {
            using (var dbContext = new EmployeeContext())
            {
                if (subdivision.Leader != null)
                {
                    var lead = dbContext.Employees.Find(subdivision.Leader.Id); //Поиск соотв лидера в БД
                    subdivision.Leader = lead;
                }
                dbContext.Subdivisions.Add(subdivision);
                dbContext.SaveChanges();
            }
        }

        //Создание нового сотрудника
        public void CreateEmployee(string surname, string name, string patronymic, DateTime date, Genders gender, Subdivision division)
        { 
            CreateEmployee(new Employee()
            {
                Surname = surname,
                Name = name,
                Patronymic = patronymic,
                Birthday = date,
                Gender = gender,
                Division = division
            });
        }

        public void CreateEmployee(Employee employee)   //Добавление сотрудника в БД
        {
            using (var dbContext = new EmployeeContext())
            {
                var div = dbContext.Subdivisions.Find(employee.Division.Id);    //Поиск соотв подразделения в БД
                employee.Division = div;
                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();
            }
        }

        public void CreateOrder(int number, string product, Employee worker) //Создание нового заказа
        {
            CreateOrder(new Order()
            {
                Number = number,
                Product = product,
                Worker = worker
            });
        }

        public void CreateOrder(Order order)    //Добавление заказа в БД
        {
            using (var dbContext = new EmployeeContext())
            {
                var work = dbContext.Employees.Find(order.Worker.Id);   //Поиск соотв сотрудника в БД
                order.Worker = work;
                dbContext.Orders.Add(order);
                dbContext.SaveChanges();
            }
        }

        public void ChangeSubdivision (Subdivision division)    //Изменение подразделения в БД
        {
            using (var dbContext = new EmployeeContext())
            {
                var newDivision = dbContext.Subdivisions.Find(division.Id);
                newDivision.Title = division.Title;
                newDivision.Leader = dbContext.Employees.Find(division.Leader.Id);
                dbContext.SaveChanges();
            }
        }

        public void ChangeEmployee(Employee employee)   //Изменение сотрудника в БД
        {
            using (var dbContext = new EmployeeContext())
            {
                Employee newEmployee = dbContext.Employees.Find(employee.Id);
                newEmployee.Surname = employee.Surname;
                newEmployee.Name = employee.Name;
                newEmployee.Patronymic = employee.Patronymic;
                newEmployee.Birthday = employee.Birthday;
                newEmployee.Gender = employee.Gender;
                newEmployee.Division = dbContext.Subdivisions.Find(employee.Division.Id);
                dbContext.SaveChanges();
            }
        }

        public void ChangeOrder(Order order)    //Изменение заказа в БД
        {
            using (var dbContext = new EmployeeContext())
            {
                Order newOrder = dbContext.Orders.Find(order.Id);
                newOrder.Number = order.Number;
                newOrder.Product = order.Product;
                newOrder.Worker = dbContext.Employees.Find(order.Worker.Id);
                dbContext.SaveChanges();
            }
        }

        public List<Subdivision> GetDivisions() //Создание списка подразделений
        {
            using (var dbContext = new EmployeeContext())
            {
                return dbContext.Subdivisions.Include(x => x.Leader).ToList();
            }
        }
        public List<Employee> GetEmployees()    //Создание списка сотрудников
        {
            using (var dbContext = new EmployeeContext())
            {
                return dbContext.Employees.Include(x => x.Division).ToList();
            }
        }
        public List<Employee> GetEmployeesInDivision(Subdivision division)    //Создание списка сотрудников
        {
            using (var dbContext = new EmployeeContext())
            {
                return dbContext.Employees.Where(e => e.Division.Id == division.Id).Include(u => u.Division).ToList();
            }
        }
        public List<Order> GetOrders()  //Создание списка заказов
        {
            using (var dbContext = new EmployeeContext())
            {
                return dbContext.Orders.Include(x => x.Worker).ToList();
            }
        }
    }
}
