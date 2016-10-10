using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    //Description of class
    //Generic, 
    //The class is abstract due to compilation error
    public abstract class Animal
    {
        private bool _IsAlive;

        public bool IsAlive
        {//You want to set as little of logic as possible in the setter. Single responsibility principle. It should only be
            //responsible for setting the property 
            get { return _IsAlive; }
            protected set { _IsAlive = value; }
        }


        public Animal()
        {
            IsAlive = true;
        }

        //To make it abstract and overridable you have to have it point to zero. When you make something abstract you are saying that an inherited class
        //has to override the method
        public abstract void Eat();

        //Virtual allows you to override the function in later inheritance      
        public virtual bool Move()
        {
            return true;
        }
        public void Kill()
        {
            IsAlive = false;
        }
    }
}
