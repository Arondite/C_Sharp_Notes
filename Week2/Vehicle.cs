using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    //Software Engineering Lifecycle
    //Analysis => Design => Implementation


    //Encapsulation: grouping data and functionality
    //The only way to get to the data of this class is through the class itself
    //We only allow functionality that we want people to have through encapsulation
    public class Vehicle
    {
        //Variables
        //      fields
        //      properties
        //Methods
        //      constructors
        //      worker methods

        //Field
        // type, name/identifier
        
        //Static you do not need to initilize the object to use the field
        protected static int Counter;

        //Readonly only allows you to set it in the constructor 
        public readonly double SerialNumber;
        
        
        //private int _CarryingCapacity;
        protected int _CarryingCapacity;
        //99% of the time make it protected
        
        
        //We want to hide this data

        //Access Modifiers
        //Control who can access members
        //      members => fields properties
        //public, protected, private, internal
        //      internal => public to the same project, private to everything else
        //defaults to private

        //Property
        //type, name/identifier, getter and setters
        public int CarryingCapacity
        {
            get; //set; by getting rid of the setter, we make this a read-only
        }

        //Be

        public int CarryingCapicity_Manual
        {
            get { return _CarryingCapacity; }//We can modify this because it is a function that we can change what we wish to get
            //Computer property is when we can change this function to do math
            protected set { _CarryingCapacity = value; }// this only allows the class to modify the setter
        }
        //By doing the getter and setters you are assigning the work to the compiler
        public double RevLimit
        {
            get;
            set;
        }

        //Constructors
        //Initialize the object

        public Vehicle()
        {
            CarryingCapicity_Manual = 4;
            RevLimit = 60;
        }
        public Vehicle(int carryingCapacity)
        {
            CarryingCapicity_Manual = carryingCapacity;
            RevLimit = 60;
        }
        public Vehicle(int carryingCapacity, double revLimit = 0)
        {
            CarryingCapicity_Manual = carryingCapacity;
        }

        //void DummyFunction()
        //{
        //    CarryingCapacity = 0;  This is not modifyable because the set is gone
        //}
        public override string ToString()
        {
            return string.Format("{0} is the carrying capacity. {1} is the rev Limit.", CarryingCapicity_Manual, RevLimit);
        }
        
        //This is wrong because we do not know if this class is going to be ran in a console application
        //public void Print()
        //{
         //   Console.WriteLine("This is the wrong way to do this");
        //}
    }
}
