using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib
{
    public class Order  //Заказ
    {
        [Key]
        public int Id { get; set; } //Ключ
        public int Number { get; set; } //Номер заказа
        public string Product { get; set; } //Товар
        public Employee Worker { get; set; }    //Сотрудник
    }
}
