using Caliburn.Micro;
using Caliburn.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Caliburn.ViewModels
{
    /// <summary>
    /// We have the conductor of the screens
    /// </summary>
    /// We used the PropertyChangedBase thanks to the namespace Caliburn.Micro
    public class MainViewModel : Conductor<Screen>.Collection.OneActive
    {
        private Screen _CurrentViewModel;

        public Screen CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { _CurrentViewModel = value; NotifyOfPropertyChange(() => CurrentViewModel); }
        }

        public MainViewModel()
        {
            //CurrentViewModel = new UsersViewModel();

            //This is Caliburn's code
            //IoC => Inversion of Control
            CurrentViewModel = IoC.Get<UsersViewModel>();
        }

        public void ShowOther()
        {
            var useless = IoC.Get<UselessViewModel>();
            //useless.Greeting = "Hello World";

            //CurrentViewModel = new UselessViewModel()
            //{
            //    Greeting = "Hello World"
            //};
            CurrentViewModel = useless;
        }
    }
}
