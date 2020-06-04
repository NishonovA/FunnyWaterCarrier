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
        public ShowOrderModel(ServiceClient client, BaseViewModel parent = null) : base(client, parent)
        {
            this.Orders = client.GetOrders().ToList();
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
