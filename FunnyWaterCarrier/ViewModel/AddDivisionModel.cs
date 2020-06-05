using EmployeeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FunnyWaterCarrier.ViewModel
{
    public class AddDivisionModel : BaseViewModel
    {
        private Subdivision _inputDivision;
        public AddDivisionModel(ServiceClient client, BaseViewModel parent = null, Subdivision input = null) : base(client, parent)
        {
            if (input != null)
            {
                _inputDivision = input;
                _employees = ServiceClient.GetEmployeesInDivision(_inputDivision);
                this.DivisionName = _inputDivision.Title;
                this.DivisionLeader = _inputDivision.Leader;
            }
        }

        private string _divisionName;
        private Employee _divisionLeader;

        private List<Employee> _employees;

        public List<Employee> Employees
        {
            get
            {
                if ((_employees == null)&&(_inputDivision != null)) _employees = ServiceClient.GetEmployeesInDivision(_inputDivision);
                return _employees;
            }
            set
            {
                _employees = value;
                OnPropertyChanged("Employees");
            }
        }

        public string DivisionName
        {
            get => _divisionName;
            set
            {
                _divisionName = value;
                OnPropertyChanged("DivisionName");
            }
        }

        public Employee DivisionLeader
        {
            get => _divisionLeader;
            set
            {
                _divisionLeader = value;
                OnPropertyChanged("DivisionLeader");
            }
        }

        public ICommand Accept
        {
            get => new BaseCommand((sender) =>
            {
                if (_inputDivision == null)
                {
                    ServiceClient.CreateSubdivision(DivisionName, DivisionLeader);
                }
                else
                {
                    _inputDivision.Title = DivisionName;
                    _inputDivision.Leader = DivisionLeader;
                    ServiceClient.ChangeSubdivision(_inputDivision);
                }
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
