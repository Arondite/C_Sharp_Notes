using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilesAndStreams.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace FilesAndStreams.Test
{
    [TestClass]
    public class FileLogTest
    {
        [TestMethod]
        public void FileLog_Debug()
        {
            //You do this because you only want to test the ILog in this tests
            //By treating it as the interface, you prevent them from using any code that you have encapsulated
            //Always limit it to the functionality that you are testing 
            //@ symbol treats it as a literal

            string path = @".\UnitTestFile.txt";
            ILog log = new FileLog(path);

            //The .\ is for Mac and Linux system because they have a hard time knowing where they are

            log.Debug("Testing", "This is just a test\nThis is only a test." + Environment.NewLine); // Window you have to \r\n
            string[] lines = File.ReadAllLines(path);
            
            //IEnumerable<string> lines = File.ReadAllLines(path);
            //If there is a way without using the linq method, use it

            Assert.AreEqual(4, lines.Length);
        }
    }
}
