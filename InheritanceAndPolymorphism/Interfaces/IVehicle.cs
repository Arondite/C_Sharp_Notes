using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using statements, C++ #include<iostream>, is the same as using statements in C#
//The namespaces are for finding each other's objects, classes, methods, etc. . .
//

//This is the path of project.folder
//Things in the same namespace can find each other
namespace InheritanceAndPolymorphism.Interfaces
{
    //Best practices makes you start interfaces with the name I[name of interface]
    public interface IVehicle
    {
        //Only can specify the return type, name, and arguments(Signature)
        //access modifiers are not part of it
        //interfaces say what you MUST have. In example, the NumberOfWheels have a getter not a setter
        int NumberOfWheels { get; }
        void Move();
    }
}
