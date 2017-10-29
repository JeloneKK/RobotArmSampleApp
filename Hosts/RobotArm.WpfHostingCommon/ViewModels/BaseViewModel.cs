﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using PropertyChanged;

namespace RobotArm.WpfHostingCommon.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}