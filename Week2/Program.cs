using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    public class Program
    {
        //Methods vs Functions
        //Methods are functions, but functions are not necessarily methods
        //Function signatures -> return type, name, arguments/parameters


        //value types -> passed by value => all structs
        //reference types -> passed by reference => all objects

        
        static void Main(string[] args)
        {
            User Joe = new User();
            Joe.Name = "Joe";
            Joe.Id = 23;

            User Mufasa = new User();
            Mufasa.Name = "Mufasa";

            User Rick = new User();
            Rick.Name = "Rick";

            int id = 0;

            Console.WriteLine("{0} {1} named Mufasa. His/Her name is {0}.", Mufasa.Name, IsMufasa(Mufasa, out id) ? "is" : "not");
            Console.WriteLine("{0} {1} named Mufasa. His/Her name is {0}.", Rick.Name, IsMufasa(Rick, out id) ? "is" : "not");

            int i = 42;
            
            //Function1(Joe);
            //Console.WriteLine(i);

            Console.WriteLine(Function1(Joe));
            Console.WriteLine(Joe.Id);
            
            //This will not change the original object that we passed into the function
            //Console.Read();

            Function2(ref i);

            //The reason behind this is that the code in C++ was written where people did not know when they were passing items by reference

            Function1(ref Joe);

            //string str = "124";
            //int tempVal = 0;
            //if(int.TryParse(str, out tempVal))
            //{
            //    Console.WriteLine("Hooray");
            //}
            Vehicle v = new Vehicle();
            Vehicle u = new Vehicle(6);
            u.RevLimit = 60;

            //Object Initializer Syntax
            Vehicle y = new Vehicle()
            {
                //CarryingCapicity_Manual = 4, cant because of it being protected
                RevLimit = 20
            };
            //v.CarryingCapicity_Manual = 10; This is inaccessable because the setter is protected

            Console.WriteLine(y.ToString());


            Console.WriteLine(i);
            Console.Read();
        }

        //Why we had to make the functions static. The main class is static and static classes can only access static items.
        //To be static, the value or object only has one place. There is only ONE. No more, no less. 

        //Conversation on strings
        //string str = "This" //This is what is called a string literal
        //anytime you use a variable, it is a variable
        //string str2 = new string(new char[] {'f','o','o'})
        //str.Replace("Hello", "Goodbye");
        //strings are only readonly
        //strings cannot be manipulated. They are known as immutable


        static double Function1(User user)
        {
            user = new User(); // when passing by reference you can ultimately create a whole new class initialization
            //As soon as you write "new User" the memory address that was originally assigned to the object now points to a new user
            user.Id = 73;
            return user.Id;
        }
        static double Function1(ref User user)
        {
            user = new User();
            user.Id = 55;
            return user.Id;
        }
        //static double Function1(int i)
        //{
          //  return i * i;
        //}
        static int Function2(ref int s)
        {
            s = s * s;
            return s;
        }

        //out vs ref
        //out param, must be assigned before leaving the function
        //out params, are typically used for multiple return values
        //ref params, are typically for passing value types as references or reassigning ref types.

        /// <summary>
        /// Checks if the user is Mufasa
        /// </summary>
        /// <param name="user">The user and its attributes</param>
        /// <param name="id">The id is assigned from the user</param>
        /// <returns></returns>
        static bool IsMufasa(User user, out int id)
        {
            //Magic String. Dont ever use this. Is should be a variable not a string interpretation.
            id = user.Id;
            return user.Name == "Mufasa";
        }

    }

    public class User
    {
        private string _Name;
        private int _Id;


        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }



    }
}
