using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FunnyWaterCarrier.ViewModel
{
    class AddEmployeeModel : BaseViewModel
    {
        public AddEmployeeModel(ServiceClient client, BaseViewModel parent = null) : base(client, parent)
        {
        }

        private string _employeeSurname;
        private string _employeeName;
        private string _employeePatronymic;
        private DateTime _employeeDate;

        public string EmployeeSurname
        {
            get => _employeeSurname;
            set
            {
                _employeeSurname = value;
                OnPropertyChanged("EmployeeSurname");
            }
        }
        public string EmployeeName
        {
            get => _employeeName;
            set
            {
                _employeeName = value;
                OnPropertyChanged("EmployeeName");
            }
        }
        public string EmployeePatronymic
        {
            get => _employeePatronymic;
            set
            {
                _employeePatronymic = value;
                OnPropertyChanged("EmployeePatronymic");
            }
        }

        public DateTime EmployeeDate
        {
            get => _employeeDate;
            set
            {
                _employeeDate = value;
                OnPropertyChanged("EmployeeDate");
            }
        }

        public ICommand Accept
        {
            get => new BaseCommand((sender) =>
            {
                ServiceClient.CreateEmployee(EmployeeSurname, EmployeeName, EmployeePatronymic, EmployeeDate);
                Back();
            });
        }

        public ICommand Decline
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
