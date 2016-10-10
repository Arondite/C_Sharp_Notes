using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAndExceptions
{
    /// <summary>
    /// Data structure that uses a Last-in-First-Out ordering
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Stack<T>
    {
        //You don't want anyone to change the class but allow them access to it. O open/close principle
        //ArrayStartSize is protected because no one needs to know what we are using inside the class
        protected const int ArrayStartSize = 10;
        protected T[] BackingStore { get; set; }
        protected int Head { get; set;}
        private int _Count;

        public int Count
        {
            //get { return BackingStore.Length; }
            get { return Head; }
            //set { _Count = value; }
        }

        //private T[] _BackingStore;

        ////The ?? initialized the object if it has not been initialized yet
        //public T[] BackingStore
        //{
        //    get { return _BackingStore ?? (_BackingStore = new T[ArrayStartSize]); }
        //    set { _BackingStore = value; }
        //}


        public Stack()
        {
            BackingStore = new T[ArrayStartSize];
            Head = 0;
        }
        //public Stack<T> Push(T data)
        //{
          //  return this;
        //}
        //This allows you to use
        //this.Push(default(T)).Push(default(T))... etc
        public void push(T data)
        {
            if(Head < ArrayStartSize)
                BackingStore[Head++] = data;
            else
                throw new InvalidOperationException("Trying to add too much data in this stack");
            
        }
        //Make sure that you delete the object in the array after you pop it
        //Exceptions are exemptional 
        /// <summary>
        /// Remove the top item from this stack and return it
        /// </summary>
        /// <returns>The top item of this stack</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when no elements exist in this in this stack</exception>
        public T Pop()
        {
            if (Count > 0)
                return BackingStore[--Head];
            //throw new IndexOutOfRangeException("You are accessing no items in this stack");
            throw new InvalidOperationException("You are accessing not items in this stack");
        }
    }
}
