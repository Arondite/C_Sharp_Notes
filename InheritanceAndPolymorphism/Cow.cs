using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Inheritance playes with the open/close principle where inherited class can change a protected but cant with private
//Encapsulation plays with the open/close principle

namespace InheritanceAndPolymorphism
{
    public class Cow : Vertibrate // Inheritance is a 'IS A' relationship
    {
        //Why using an enum
        //interpreted boolean
        //Where something not exactly true or false but cheaper to use
        public Gender _Gender { get; set; }
        public enum Gender
        {
            Male,
            Female
        }
        public Cow(Gender gender)
        {
            _Gender = gender;
        }
        public override void Eat()
        {
            
        }
        //Created a seperate function that is not inherited causes the polymorphism not work
        //Polymorphism is treating a class as a class that it was inherited from 
        //What override does is move the address of the method and move it to another code
        public override bool Move()
        {
            return base.Move();
            //return false; This will return false because of the override. The original source returned true.
        }

        //This explicitly hides the move method
        //public new bool Move() { return true; }

        //public Cow() This doesn't make sense because someone reading your code cant make sense of it
        //{
        //    if(Gender == true)
        //    {

        //    }
        //}
    }
}
//public class 