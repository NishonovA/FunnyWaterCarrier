using EmployeeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FunnyWaterCarrier.ViewModel
{
    class AddOrderModel : BaseViewModel
    {
        private Order _inputOrder;
        public AddOrderModel(ServiceClient client, BaseViewModel parent = null, Order input = null) : base(client, parent)
        {
            this.Employees = client.GetEmployees();
            if (input != null)
            {
                _inputOrder = input;
                this.OrderNumber = _inputOrder.Number;
                this.OrderProduct = _inputOrder.Product;
                this.OrderWorker = _inputOrder.Worker;
            }
        }

        private int _orderNumber;
        private string _orderProduct;
        private Employee _orderWorker;

        private List<Employee> _employees;

        public List<Employee> Employees
        {
            get
            {
                if (_employees == null) _employees = ServiceClient.GetEmployees();
                return _employees;
            }
            set
            {
                _employees = value;
                OnPropertyChanged("Employees");
            }
        }

        public int OrderNumber
        {
            get => _orderNumber;
            set
            {
                _orderNumber = Convert.ToInt32(value);
                OnPropertyChanged("OrderNumber");
            }
        }
        public string OrderProduct
        {
            get => _orderProduct;
            set
            {
                _orderProduct = value;
                OnPropertyChanged("OrderProduct");
            }
        }

        public Employee OrderWorker
        {
            get => _orderWorker;
            set
            {
                _orderWorker = value;
                OnPropertyChanged("OrderWorker");
            }
        }

        public ICommand Accept
        {
            get => new BaseCommand((sender) =>
            {
                if (_inputOrder == null)
                {
                    ServiceClient.CreateOrder(OrderNumber, OrderProduct, OrderWorker);
                }
                else
                {
                    _inputOrder.Number = OrderNumber;
                    _inputOrder.Product = OrderProduct;
                    _inputOrder.Worker = OrderWorker;
                    ServiceClient.ChangeOrder(_inputOrder);
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
