using MVVMAndDataBinding.Interfaces;
using MVVMAndDataBinding.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAndDataBinding.ViewModels
{
    /// <summary>
    /// Tells the view what to show, and relays actions
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler _PropertyChanged;
        //public event PropertyChangedEventHandler PropertyChanged
        //{
        //    add
        //    {
        //        _PropertyChanged += value;
        //    }
        //    remove
        //    {
        //        _PropertyChanged -= value;
        //    }

        //}
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<string> _Names;

        public ObservableCollection<string> Names
        {
            get { return _Names; }
            protected set { _Names = value; }
        }
        private ObservableCollection<User> _Users;

        public IUserRepository UserRepo { get; protected set; }

        public ObservableCollection<User> Users
        {
            get { return _Users; }
            protected set { _Users = value; }
        }
        private User _SelectedUser;
        public User SelectedUser {
            get
            {
                return _SelectedUser;
            }
            set
            {
                _SelectedUser = value;
                NotifyOfChange(nameof(SelectedUser));
            }

        }


        public MainWindowViewModel(IUserRepository userRepo)
        {
            UserRepo = userRepo;

            //Names = new ObservableCollection<string>()
            //{
            //    "Rob", "David", "Jeffrey"
            //};
            Users = new ObservableCollection<User>(UserRepo.GetUser());
            Names = new ObservableCollection<string>(Users.Select((n) => n.Name));

        }

        public void AddName(string name)
        {
            Names.Add(name);

            if(SelectedUser != null)
            {
                SelectedUser = new User()
                {
                    Name = name,
                    ID = Users.Count + 1,
                    Phone = new string(Users.Count.ToString()[0], 10),
                    Grade = 'A'
                };
            }
        }
        public void SaveSelectedUser()
        {
            if (SelectedUser == null)
                return;
            UserRepo.SaveUser(SelectedUser);


        }
        protected void NotifyOfChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
