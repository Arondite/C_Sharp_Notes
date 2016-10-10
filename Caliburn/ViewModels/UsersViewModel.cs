using Caliburn.Micro;
using Caliburn.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Caliburn.ViewModels
{
    public class UsersViewModel : Screen
    {
        private string _Message;

        public string Message
        {
            get { return _Message; }
            //Multiple ways to change. C# 6 nameof(Message). For educational purposes we used Linq and Caliburns NotifyOfPropertyChange
            set
            {
                _Message = value;
                NotifyOfPropertyChange(() => Message);
            }
        }

        private string _MessageCopy;

        public string MessageCopy
        {
            get { return _MessageCopy; }
            set { _MessageCopy = value; NotifyOfPropertyChange(() => MessageCopy); }
        }

        private ObservableCollection<User> _Users;

        public ObservableCollection<User> Users
        {
            get { return _Users; }
            set { _Users = value; NotifyOfPropertyChange(() => Users); }
        }

        private User _SelectedUser;

        public User SelectedUser
        {
            get { return _SelectedUser; }
            set { _SelectedUser = value; NotifyOfPropertyChange(() => SelectedUser); }
        }

        public UsersViewModel()
        {
            Users = new ObservableCollection<User>();
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


        /// <summary>
        /// The name matches the button on the UI and caliburn bound them together
        /// </summary>
        public void ShowMessage()
        {
            MessageBox.Show(Message);
        }

        public void TextKeyUp(string text)
        {
            MessageCopy = text;
        }



    }
}
