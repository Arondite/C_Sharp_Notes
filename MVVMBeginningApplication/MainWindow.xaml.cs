using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
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

namespace MVVMBeginningApplication
{

    //For everytime an event is fired. It is going through everything that the event has subscribed to it and foreach-ing over them

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        //public IEnumerable<string> Items { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<string> Items { get; set; }
        private string _Greeting;

        public string Greeting
        {
            get { return _Greeting; }
            set { _Greeting = value; NotifyChanged(nameof(Greeting)); } //LINQ's use is NotifyChanged(() => Greeting); }
            //The setter is getting called everythime that the variable is getting called. Then the method is notifying the GUI that the variable got changed.
        }

        public MainWindow()
        {
            Items = new ObservableCollection<string>()
            {
                //"Item 1", "Item 2","Item 3","Item 4", "Item 5"
                "Red", "Green", "Blue", "Orange", "Purple"
            };

            Greeting = "Hello World";

            InitializeComponent();

            this.Loaded += (sender, args) =>
            {
                //This uses the extension with the Func to pass in
                //Items.ForEach(ItemsListBox.Items.Add);

                //This uses LINQ to conquer the use of creating new TextBlocks with the Text assigned to the string in the collection
                //var textBlocks = Items.Select((n) => new TextBlock { Text = n });

                //textBlocks.ForEach(ItemListBox.Items.Add);

                //foreach (var item in textBlocks)
                //{
                //    ItemsListBox.Items.Add(item);
                //}

                //foreach (var str in Items)
                //{
                //    ItemsListBox.Items.Add(str);
                //}

                //this reference the item's source to an IEnumerable
                //ItemsListBox.ItemsSource = Items;

                //Gives reference to where to look for your data
                this.DataContext = this;
            };
        }

        

        private void AddColor_Click(object sender, RoutedEventArgs e)
        {
            string color = NewColor.Text;
            if (!string.IsNullOrWhiteSpace(color))
            {
                Items.Add(color);
                //ItemsListBox.Items.Add(color);
            }

            Greeting = string.Format("There are {0} items on the list", Items.Count);
            NewColor.Text = string.Empty;
            //if(Items.Count % 3 == 0)
            //{
            //    Scramble();
            //}
        }
        private void Scramble()
        {
            var ran = new Random();
            var newList = new ObservableCollection<string>();

            while(Items.Count > 0)
            {
                var item = Items.ElementAt(ran.Next(Items.Count));
                Items.Remove(item);
                newList.Add(item);
            }

            Items = newList;
            //ItemsListBox.Items.Clear();
            //foreach (var str in Items)
            //{
            //    ItemsListBox.Items.Add(str);
            //}
        }

        //Creating this function is helping with the idea that it makes a temp that cannot be emptied
        protected void NotifyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //This is the LINQ's use
        //protected void NotifyChanged<T>(Expression<Func<T>> expression)
        //{
        //    var member = expression.Body as MemberExpression;
        //    NotifyChanged(member.Member.Name);
        //}
    }
    //public static class IEnumerableClassExtensions
    //{
    //    public static void ForEach<T>(this IEnumerable<T> self, Func<T, int> predicate)
    //    {
    //        foreach (var item in self)
    //        {
    //            predicate(item);
    //        }
    //    }
    //}//This allows you to loop through all the items in the IEnumerable listed above and add it to the ListBox in the XAML
    public static class IEnumerableClassExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> self, Action<T> predicate)
        {
            foreach (var item in self)
            {
                predicate(item);
            }
        }
    }
}
