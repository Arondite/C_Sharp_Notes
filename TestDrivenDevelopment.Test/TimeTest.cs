using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//The compiler is smart enough to see the namespace and combine it with the other project

//The software development cycle idea is to analyze the system requirements, design how you will design the code, write the test driven tests, 
//write the code, test, write the code, test, etc. . .

namespace TestDrivenDevelopment.Test
{
    //TestClass is called Data Annotations, Data Attribute
    //This Annotation tells the compiler that it tests the specific tag
    [TestClass]
    public class TimeTest
    {
        protected Time Time { get; set; }
        //We do it this way because it initializes the object the same for all tests
        [TestInitialize]
        public void Init()
        {
            //Time t = new Time(); This code is called without the [TestInitialize]
            Time = new Time();
        }

        [TestMethod]
        public void Time_AddSeconds_SecondsDoesntCarryOver()
        {
            //Prevents from fat fingering an unexpected error in the tests class
            int ExpectedOne = 42, ExpectedTwo = 52;
            int UpdateOne = 42, UpdateTwo = 10;
            ExpectedTwo = ExpectedOne + UpdateTwo;

            Time t = new Time();
            //Time.AddSeconds(42);
            Time.AddSeconds(UpdateOne);
            Assert.AreEqual(42, Time.Seconds);
            Assert.AreEqual(ExpectedOne, Time.Seconds);
            Assert.AreEqual(0, Time.Minutes);
            Assert.AreEqual(0, Time.Hours);

            //Double delta parameter(third argument) is for the precision of the test. This holds true with floats and doubles
            //Assert.AreEqual(42, Time.Seconds, 2);

            //Also has the ability to add a message
            //Assert.AreEqual(42, Time.Seconds, "This failed because you suck");

            //Time.AddSeconds(10);
            Time.AddSeconds(UpdateTwo);
            Assert.AreEqual(52, Time.Seconds);
            Assert.AreEqual(ExpectedTwo, Time.Seconds);
            Assert.AreEqual(0, Time.Minutes);
            Assert.AreEqual(0, Time.Hours);
        }
        [TestMethod]
        public void Time_AddSeconds_SecondsCarryOver()
        {
            int expectedOne = 42, updateTwo = 30;
            int expectedTwo = (expectedOne + updateTwo) % 60;
            int minExpectTwo = (expectedOne + updateTwo) / 60;
            int updateThree = 300, expectedThree = (expectedTwo + updateThree) % 60;

            Time.AddSeconds(expectedOne);
            Assert.AreEqual(expectedOne, Time.Seconds);
            Assert.AreEqual(0, Time.Minutes);
            Assert.AreEqual(0, Time.Hours);

            Time.AddSeconds(updateTwo);
            Assert.AreEqual(expectedTwo, Time.Seconds);
            Assert.AreEqual(minExpectTwo, Time.Minutes);
            Assert.AreEqual(0, Time.Hours);

            Time.AddSeconds(updateThree);
            Assert.AreEqual(expectedThree, Time.Seconds);
        }
    }
}
