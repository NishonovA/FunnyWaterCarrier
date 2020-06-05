using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib
{
    public enum Genders  //Пол
    {
        [Description("Мужской")]
        Male,   //Мужской
        [Description("Женский")]
        Female  //Женский
    }

    public class Employee  //Сотрудник
    {
        [Key]
        public int Id { get; set; } //Ключ
        public string Surname { get; set; } //Фамилия
        public string Name { get; set; }    //Имя
        public string Patronymic { get; set; }  //Отчество
        public DateTime Birthday { get; set; }  //Дата рождения
        public Genders Gender { get; set; } //Пол
        public Subdivision Division { get; set; }   //Подразделение
        public List<Order> Orders { get; set; } // Заказы
    }
}
