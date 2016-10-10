using Caliburn.Micro;
using Caliburn.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.ViewModels
{
    public class UselessViewModel : Screen
    {
        private string _Greeting;

        public string Greeting
        {
            get { return _Greeting; }
            set { _Greeting = value; NotifyOfPropertyChange(() => Greeting); }
        }
        private ObservableCollection<User> _Users;

        public ObservableCollection<User> Users
        {
            get { return _Users; }
            set { _Users = value; NotifyOfPropertyChange(() => Users); }
        }
        private ObservableCollection<int> _ComboBoxItems ;

        public ObservableCollection<int> ComboBoxItems
        {
            get { return _ComboBoxItems; }
            set { _ComboBoxItems = value; NotifyOfPropertyChange(() => ComboBoxItems); }
        }


        public UselessViewModel()
        {
            Users = new ObservableCollection<User>();
            ComboBoxItems = new ObservableCollection<int>()
            {
                1,2,3,5,5,6,8,7,9
            };


            for (int i = 0; i < 10; i++)
            {
                Users.Add(new User()
                {
                    Name = "User" + (i + 1),
                    ID = i + 1,
                    Phone = new string(i.ToString()[0], 10),
                    Grade = 'A'
                });
            }
        }

    }
}
