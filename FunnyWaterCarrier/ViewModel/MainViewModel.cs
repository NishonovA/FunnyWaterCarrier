using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FunnyWaterCarrier.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(ServiceClient client, BaseViewModel parent = null) : base(client, parent)
        {
        }

        public ICommand AddDivision
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new AddDivisionModel(ServiceClient, this));
            });
        }

        public ICommand AddEmployee
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new AddEmployeeModel(ServiceClient, this));
            });
        }

        public ICommand AddOrder
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new AddOrderModel(ServiceClient, this));
            });
        }

        public ICommand ChangeDivision
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new ChangeDivisionModel(ServiceClient, this));
            });
        }
        public ICommand ChangeEmployee
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new ChangeEmployeeModel(ServiceClient, this));
            });
        }
        public ICommand ChangeOrder
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new ChangeOrderModel(ServiceClient, this));
            });
        }
        public ICommand ShowDivision
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new ShowDivisionModel(ServiceClient, this));
            });
        }
        public ICommand ShowEmployee
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new ShowEmployeeModel(ServiceClient, this));
            });
        }
        public ICommand ShowOrder
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new ShowOrderModel(ServiceClient, this));
            });
        }
    }
}
