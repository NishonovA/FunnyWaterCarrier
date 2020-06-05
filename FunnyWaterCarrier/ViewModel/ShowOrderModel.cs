using EmployeeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FunnyWaterCarrier.ViewModel
{
    class ShowOrderModel : BaseViewModel
    {
        private Order _inputOrder;
        public ShowOrderModel(ServiceClient client, BaseViewModel parent = null) : base(client, parent)
        {
            this.Orders = client.GetOrders();
        }

        private List<Order> _orders;
        public List<Order> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                OnPropertyChanged("Orders");
            }
        }
        public Order Input
        {
            get => _inputOrder;
            set
            {
                _inputOrder = value;
                OnPropertyChanged("Input");
            }
        }

        public ICommand Change
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new AddOrderModel(ServiceClient, Parent, _inputOrder));
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
