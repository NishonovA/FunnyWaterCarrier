using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FunnyWaterCarrier.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        public ICommand AddDivision
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new AddDivisionModel());
            });
        }

        public ICommand AddEmployee
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new AddEmployeeModel());
            });
        }

        public ICommand AddOrder
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new AddOrderModel());
            });
        }

        public ICommand ChangeDivision
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new ChangeDivisionModel());
            });
        }
        public ICommand ChangeEmployee
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new ChangeEmployeeModel());
            });
        }
        public ICommand ChangeOrder
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new ChangeOrderModel());
            });
        }
        public ICommand ShowDivision
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new ShowDivisionModel());
            });
        }
        public ICommand ShowEmployee
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new ShowEmployeeModel());
            });
        }
        public ICommand ShowOrder
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new ShowOrderModel());
            });
        }
    }
}
