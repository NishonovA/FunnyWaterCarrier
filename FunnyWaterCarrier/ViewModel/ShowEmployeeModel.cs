using EmployeeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FunnyWaterCarrier.ViewModel
{
    class ShowEmployeeModel : BaseViewModel
    {
        public ShowEmployeeModel(ServiceClient client, BaseViewModel parent = null) : base(client, parent)
        {
            this.Employees = client.GetEmployees().ToList();
        }

        private List<Employee> _employees;
        public List<Employee> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged("Employees");
            }
        }

        public ICommand Accept
        {
            get => new BaseCommand((sender) =>
            {
                Back();
            });
        }

        private void Back()
        {
            OnShowView(this, Parent);
        }
    }
}
