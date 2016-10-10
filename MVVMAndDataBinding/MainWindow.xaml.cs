using MVVMAndDataBinding.Models;
using MVVMAndDataBinding.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMAndDataBinding
{
    /// <summary>
    /// Show UI and interact with user
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get; protected set; }
        public MainWindow()
        {//Responsibility is to hold the window and its controls

            var repo = new UserRepository();
            ViewModel = new MainWindowViewModel(repo);
            InitializeComponent();

            this.Loaded += (sender, args) =>
            {
                this.DataContext = ViewModel;

                //The base and all of its children should get its data from Names
                //SubGrid.DataContext = Names;

                //You do not want to put the function in this in the same class. It can fuck shit up.
                //The reason that lambdas are called anonymous is because they do not have a name; therefor, you cannot call it anywhere.

            };
        }
        protected void AddNameHandler(object sender, RoutedEventArgs e)
        {
            ViewModel.AddName(NewName.Text);   
        }
        protected void SelectedChangeHandler(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count > 0)
            {
                ViewModel.SelectedUser = e.AddedItems[0] as User;
                //If this isn't correctly a User it'll set the SelectedUser to null
            }
        }

        public void SaveUserInfo_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SaveSelectedUser();
        }
    }
}
