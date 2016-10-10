using System;
using System.Collections.Generic;
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

namespace Wpf
{
    //Partial - Defined (potentially) in multiple files
    //Partial means it CAN be
    //The partial keyword makes the compiler go look for another file with the same named class

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        protected delegate double ParseDelegate(string str);
        //An event takes an event. The event must be the same type as the event.
        protected event ParseDelegate NewStringEvent;
        
        //Like properties have getter and setters, events have add and remove
        //protected event ParseDelegate NewStringEnumerable
        //{
        //    add
        //    {

        //    }
        //    remove
        //    {

        //    }
        //}

        public MainWindow()
        {//Only one constructor
            //Don't do this because the controller is not initialize
            //this.UserText.Text = "Don't do this because the controller is not initialize";

            InitializeComponent();


            //InitializeComponent will go through the controls and set them up. The XAML code.

            //this.UserText.Text 
            //This is accessing the textbox by its name and the Text property

            //TextBlock input4 = new TextBlock();
            //input.Text4 = "input 4";                    Some example of how you can code from XAML


            ParseDelegate pd = DoWork;
            //Or you can add up multiple references to the functions
            List<ParseDelegate> ListParseDelegates = new List<ParseDelegate>() {(s) =>
                5.5, (s) => 6.0, (s) => 9.6
            };

            //This is literally what you did above. The Event holds multiple references of the functions.
            NewStringEvent += (s) => 5.5;
            NewStringEvent += DoWork;
        }

        protected double DoWork(string str)
        {
            double output;
            Double.TryParse(str, out output);
            return output;
        }

        //This is an event. Events work off of delegates. 
        //Action and Func are delegates. Delegates are Functions
        //public void Worthless()
        //{
        //    Action a = Worthless;                     The () at the end of functions is LITERALLY calling the function
        //}
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string input = UserText.Text;
            MessageBox.Show(input, "You've entered this");

            //*************************************************************************************************************************************
            //This is an example how to access the children from the parent node
            //List<TextBox> gridBoxes = new List<TextBox>();
            //foreach(var item in QuadGrid.Children)
            //{
            //    if(item is TextBox)
            //    {
            //        gridBoxes.Add(item as TextBox);
            //    }
            //}
            //gridBoxes.ForEach((n) => Console.WriteLine(n.Text));

            //Another example on how to access the children
            var textBoxes = QuadGrid.Children.Cast<TextBox>();
            //var textBoxes2 = QuadGrid.Children.Cast<object>().Where((n) => n is TextBox).Cast<TextBox>();
            foreach(var item in textBoxes)
            {
                Console.WriteLine(item.Text);
            }
            //******************************************************************************************************************************************

            NewStringEvent(input);
        }

    }
}
