using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InheritanceAndPolymorphism.Interfaces;

namespace InheritanceAndPolymorphism
{
    //Interfaces allow the use of polymorphism. The polymorphism allows you to treat a group of objects in the same method. Liskov substitution principle 
    //Creating test classes can also capitalize from inhertance. If you declare the object itself protected the inherited class may have access to it
    public class Truck : IVehicle
    {
        //This is the C++ syntax
        //public bool operator ==(Truck t)
        //{

        //}
        //public static bool operator()()
        //{
        
        //}Func tor is a usefull action in C++. Theres a c# equivalent

        //The overloading the operator it must be static and one of the parameters has to be the class that you are using
        //It being a static member it has to have two parameters
        public static bool operator==(IVehicle t1, Truck t2)
        {
            return t1.NumberOfWheels == t2.NumberOfWheels;
        }
        public static bool operator!=(IVehicle t1, Truck t2)
        {
            return t2.NumberOfWheels != t1.NumberOfWheels;
        }

        public int NumberOfWheels
        {
            get
            {
                return NumberOfWheels;
            }
            protected set
            {
                NumberOfWheels = value;
            }
        }
        //Exemptions are implemented in the code to remind that you have not codes an item
        public void Move()
        {
            //throw new NotImplementedException();
        }
        //This method only callable by a method that IS A Truck
        public void HonkHorn()
        {

        }
    }
}
