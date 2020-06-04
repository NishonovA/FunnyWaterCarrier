﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Configuration;
using EmployeeLib;
using System.Windows.Input;


namespace FunnyWaterCarrier.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public object Sender;
        public delegate void ViewModelHandler(object sender, BaseViewModel viewModel);

        public event ViewModelHandler ShowViewEvent;

        protected virtual void OnShowView(object sender, BaseViewModel viewmodel)
        {
            ShowViewEvent?.Invoke(sender, viewmodel);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
