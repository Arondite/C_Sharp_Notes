using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndLINQ
{
    //Object initializer syntax is where you initialize the object in one line of code. You know what I am talking about dummy. Think harder. 
    
    public class LinkedList<T>
    {
        protected T[] BackingStoreArray { get; set; }
        protected List<T> BackingStoreList { get; set; }
        protected Stack<T> BackingStoreStack { get; set; }
        public Queue<T> BackingStoreQueue { get; set; }
        //In the dictionary when you assign two values to the same key, the second one overrides the first one
        protected Dictionary<T, T> BackingStoreDictionary { get; set; }


        public LinkedList()
        {//You can pass an IEnumberable into a colleciton's constructor
            BackingStoreArray = new T[10];
            BackingStoreList = new List<T>();
            //In the tests you are choosing which type of generic you are working with to initialize the object
            BackingStoreStack = new Stack<T>();
            BackingStoreQueue = new Queue<T>();
            BackingStoreDictionary = new Dictionary<T, T>();

            
        }
        //Linq adds extension functions to the collections
        public void LinqCode()
        {
            List<int> intList = new List<int>() {
               5,6,7,8,9,10
            };
            //The reason that Stack<int> did not work is because the Linq returned an IEnumerable
            var aboveFiveIEnumerable = from i in intList
                                  where i > 5
                                  select i;
            List<int> aboveFiveList = (from i in intList
                                       where i > 5
                                       select i).ToList();

            //Func<int, bool> comparesToFive = (i) => i > 5;
            //Lambda or Anonymous Method
            Func<int, bool> comparesToFive = (i) =>
            {
                return i > 5;
            };
            var aboveFiveTwo = intList.Where(ComparesToFive).ToList();
            //*******************************************************************************************************
            foreach (int item in new int[] { 3, 5, 7 })
            {
                Func<int, bool> comparesToIntArray = (i) =>
                {
                    return i > item;
                };
                var comparisonCollection = intList.Where(comparesToIntArray).ToList();
            }
            //*******************************************************************************************************
            //Passing in the Lambda directly into the Func that the Where asks for
            //=> the "=" means parameters on the left and ">" means method body on the right
            var comparisonCollection2 = intList.Where((i) =>
            {
                return i > 5;
            }).ToList();
            //The Where method knows that it returns a bool. The compiler knows that the statement wants to return a bool and that's what they want throw in
            //If you only have on paramter (i) == i
            var comparisonCollection3 = intList.Where((i) => i > 5).ToList();

            var doubles = intList.Select(i => i * i).ToList();
            var doublesAlso = (from i in intList
                               orderby i descending
                               select i * i).ToList();
            //This next argument creates a new list of Users that match the given parameters of intList and descends according to the id
            //****************************************************************************************************************************************
            //var users = intList.Select(i => new User(){ Id = i}).OrderByDecending(u => u.Id).ToList();
            //****************************************************************************************************************************************
        }
       
        public bool ComparesToFive(int i)
        {
            return i > 5;
        }
        

    }

    //With extensions you have to make the methods generic not the class
    public static class StackExtensions
    {
        //The beautiful syntax that is associated with the extension methods
        //The explanation of the argument is that you want to treat "Peek" as a method of "this" of the "Stack<T>"
        public static T Peek<T>(this Stack<T> self)
        {
            T topItem = self.Pop();
            self.Push(topItem);
            return topItem;

        }
        //By making it only accept a "Stack<int>" you limit its use
        //This multiplies the collection with the number
        //synatx would be collection.Multiple(5);
        //public static Stack<int> Multiple(this Stack<int> self, int multiple)
        //{


        //}
        //This generic delegate with allow you to pass in a function that will take an in and pass a Stack<int>
        public static Stack<int> Multiple(this Stack<int> self, Func<int, Stack<int>> act)
        {
            return new Stack<int>();
        }
        //Action and Func is generic versions of delegates
        public static Stack<int> Multiple(this Stack<int> self, Action<int> act)
        {
            int i = self.Peek();
            act(i);

            return self;
        }

    }

}
