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
        public AddOrderModel(ServiceClient client, BaseViewModel parent = null) : base(client, parent)
        {
        }

        private int _orderNumber;
        private string _orderProduct;

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

        public ICommand Accept
        {
            get => new BaseCommand((sender) =>
            {
                ServiceClient.CreateOrder(OrderNumber, OrderProduct);
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
