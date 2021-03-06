﻿using EmployeeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FunnyWaterCarrier.ViewModel
{
    class AddEmployeeModel : BaseViewModel
    {
        private Employee _inputEmloyee;
        public AddEmployeeModel(ServiceClient client, BaseViewModel parent = null, Employee employee = null) : base(client, parent)
        {
            this.Subdivisions = client.GetDivisions();
            this.EmployeeDate = new DateTime(1994, 05, 20);

            if (employee != null)
            {
                _inputEmloyee = employee;
                this.EmployeeDate = _inputEmloyee.Birthday;
                this.EmployeeSurname = _inputEmloyee.Surname;
                this.EmployeePatronymic = _inputEmloyee.Patronymic;
                this.EmployeeName = _inputEmloyee.Name;
                this.EmployeeSubdivision = _inputEmloyee.Division;
                this.SelectedGender = _inputEmloyee.Gender;
            }
        }

        private string _employeeSurname;
        private string _employeeName;
        private string _employeePatronymic;
        private Genders _selectedGenders;
        private DateTime _employeeDate;
        private Subdivision _employeeDivision;

        private List<Subdivision> _subdivisions;

        public List<Subdivision> Subdivisions
        {
            get
            {
                if (_subdivisions == null) _subdivisions = ServiceClient.GetDivisions();
                return _subdivisions;
            }
            set
            {
                _subdivisions = value;
                OnPropertyChanged("Subdivisions");
            }
        }
        
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


        private Dictionary<Genders, string> _genders = new Dictionary<Genders, string>()
        {
            {Genders.Male, "Мужской"},
            {Genders.Female, "Женский" }
        };
        public Dictionary<Genders, string> GendersDictionary
        {
            get => _genders;
            set
            {
                _genders = value;
                OnPropertyChanged("GendersDictionary");
            }
        }

        public Genders SelectedGender
        {
            get => _selectedGenders;
            set
            {
                _selectedGenders = value;
                OnPropertyChanged("SelectedGender");
            }
        }
        public Subdivision EmployeeSubdivision
        {
            get => _employeeDivision;
            set
            {
                _employeeDivision = value;
                OnPropertyChanged("EmployeeSubdivision");
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
                if (_inputEmloyee == null)
                {
                    if ((EmployeeSurname == null) || (EmployeeName == null) || (EmployeePatronymic == null) ||
                    (EmployeeDate.Year < (DateTime.Now.Year - 100)) || (EmployeeDate.Year > DateTime.Now.Year) || (EmployeeSubdivision == null))
                    {
                        StringBuilder errormess = new StringBuilder();
                        if (EmployeeSurname == null) errormess.Append("Не задана фамилия!\n");
                        if (EmployeeName == null) errormess.Append("Не задано имя!\n");
                        if (EmployeePatronymic == null) errormess.Append("Не задано отчество!\n");
                        if ((EmployeeDate.Year < (DateTime.Now.Year - 100)) || (EmployeeDate.Year > DateTime.Now.Year)) errormess.Append("Некорректная дата!\n");
                        if (EmployeeSubdivision == null) errormess.Append("Не задано подразделение!\n");
                        MessageBox.Show(Convert.ToString(errormess));
                    }
                    else
                    {
                        ServiceClient.CreateEmployee(EmployeeSurname, EmployeeName, EmployeePatronymic, EmployeeDate, SelectedGender, EmployeeSubdivision);
                        Back();
                    }
                }
                else
                {
                    if ((EmployeeSurname == null) || (EmployeeName == null) || (EmployeePatronymic == null)||
                    (EmployeeDate.Year < (DateTime.Now.Year - 100)) ||(EmployeeDate.Year > DateTime.Now.Year) ||(EmployeeSubdivision == null))
                    {
                        StringBuilder errormess = new StringBuilder();
                        if (EmployeeSurname == null) errormess.Append("Не задана фамилия!\n");
                        if (EmployeeName == null) errormess.Append("Не задано имя!\n");
                        if (EmployeePatronymic == null) errormess.Append("Не задано отчество!\n");
                        if ((EmployeeDate.Year < (DateTime.Now.Year - 100)) || (EmployeeDate.Year > DateTime.Now.Year)) errormess.Append("Некорректная дата!\n");
                        if (EmployeeSubdivision == null) errormess.Append("Не задано подразделение!\n");
                        MessageBox.Show(Convert.ToString(errormess));
                    }
                    else
                    {
                        if (_inputEmloyee.Division.Leader.Id != _inputEmloyee.Id)
                        {
                            _inputEmloyee.Surname = EmployeeSurname;
                            _inputEmloyee.Name = EmployeeName;
                            _inputEmloyee.Patronymic = EmployeePatronymic;
                            _inputEmloyee.Birthday = EmployeeDate;
                            _inputEmloyee.Gender = SelectedGender;
                            _inputEmloyee.Division = EmployeeSubdivision;
                            ServiceClient.ChangeEmployee(_inputEmloyee);
                            Back();
                        }
                        else
                        {
                            MessageBox.Show($"Сотрудник является руководителем.\nСмените руководителя \"{_inputEmloyee.Division.Title}\"");
                        }
                    }
                }
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
