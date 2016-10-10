using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InheritanceAndPolymorphism.Interfaces;

namespace InheritanceAndPolymorphism
{
    //You can inherit from a interface into an interface, but you must implemet fully on the class level
    //To have a method protected from the interface in the class, you have to explicity inherit it
    //      => only when you treat the object as the interface, you may use that method

    public class Car : IVehicle
    {
        public int NumberOfWheels
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}
//Collections
//int[] arr = null;
//LinkedList<int> ll = null;
//foreach(var item in collection)
//  Console.Writeline(item);
