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
        private Employee _inputEmployee;
        public ShowEmployeeModel(ServiceClient client, BaseViewModel parent = null) : base(client, parent)
        {
            this.Employees = client.GetEmployees();
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

        public Employee Input
        {
            get => _inputEmployee;
            set
            {
                _inputEmployee = value;
                OnPropertyChanged("Input");
            }
        }

        public ICommand Change
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new AddEmployeeModel(ServiceClient, Parent, _inputEmployee));
            });
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
