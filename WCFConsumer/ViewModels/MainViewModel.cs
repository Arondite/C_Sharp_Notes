using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF;

namespace WCFConsumer.ViewModels
{
	//Goto reference and add service reference
	public class MainViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<User> _Users;

		public ObservableCollection<User> Users
		{
			get { return _Users; }
			set { _Users = value; NotifyOfChanged(nameof(Users)); }
		}

		public MainViewModel(IUserService userService)
		{
			UserService = userService;
			OnActivate();
		}
		public IUserService UserService { get; set; }
		protected virtual void OnActivate()
		{
			UserService.GetUser();
		}
		//protected virtual async void OnActivate()
		//{
		//	var user = await UserService.GetUserAsync();
		//	Users = new ObservableCollection<User>(users);
		//}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void NotifyOfChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
	}
	
}
