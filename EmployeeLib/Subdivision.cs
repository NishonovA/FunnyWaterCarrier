using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib
{
    public class Subdivision    //Подразделение
    {
        [Key]
        public int Id { get; set; } //Ключ
        public string Title { get; set; }   //Наименование
        public Employee Leader { get; set; }    //Руководитель
        public List<Employee> Employees { get; set; }
    }
}
