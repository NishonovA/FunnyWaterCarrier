using EmployeeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FunnyWaterCarrier.ViewModel
{
    class ShowDivisionModel : BaseViewModel
    {
        public ShowDivisionModel(ServiceClient client, BaseViewModel parent) : base (client, parent)
        {
            this.Subdivisions = client.GetDivisions().ToList();
        }

        private List<Subdivision> _subDivisions;
        public List<Subdivision> Subdivisions
        {
            get => _subDivisions;
            set
            {
                _subDivisions = value;
                OnPropertyChanged("Subdivisions");
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
