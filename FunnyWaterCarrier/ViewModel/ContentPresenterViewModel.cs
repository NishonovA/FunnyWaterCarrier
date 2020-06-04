using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyWaterCarrier.ViewModel
{
    public class ContentPresenterViewModel : BaseViewModel
    {
        private BaseViewModel _view;
        private String _title;

        public String Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public BaseViewModel ViewModel
        {
            get => _view;
            set
            {
                _view = value;
                OnPropertyChanged("ViewModel");
            }
        }

        public ContentPresenterViewModel() : base(new ServiceClient(), null)
        {
            Title = "Менеджер";
            ShowView(this, new MainViewModel(ServiceClient));
        }

        public void ShowView(object sender, BaseViewModel viewModel)
        {
            ViewModel = viewModel;
            ViewModel.ShowViewEvent += ShowView;
        }
    }
}
