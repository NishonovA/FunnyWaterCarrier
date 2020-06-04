using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib
{
    public class Subdivision    //Подразделение
    {
        public int Id { get; set; } //Ключ
        public string Title { get; set; }   //Наименование
        public int? Leader { get; set; }    //Руководитель
    }
}
