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
        public AddDivisionModel(ServiceClient client, BaseViewModel parent = null) : base(client, parent)
        {
        }

        private string _divisionName;

        public string DivisionName
        {
            get => _divisionName;
            set
            {
                _divisionName = value;
                OnPropertyChanged("DivisionName");
            }
        }

        public ICommand Accept
        {
            get => new BaseCommand((sender) =>
            {
                ServiceClient.CreateSubdivision(DivisionName);
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
