using FilesAndStreams.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FilesAndStreams
{//When implementing the interface, explicit mean that the class cannot access it
 //Anything that you can put a task to, put an interface to it

    //MemoryStream is useful when you try to aggregate messages
    //MemoryStream ms = new MemoryStream();
    //Streams use buffers. They are not buffers

    public class FileLog : ILog
    {
        /// <summary>
        /// Path where you want to save the file
        /// </summary>
        private string _FilePath;

        public string FilePath
        {
            get { return _FilePath; }
            protected set { _FilePath = value; }
        }
        /// <summary>
        /// Creates a logger to a filePath file
        /// </summary>
        /// <param name="filePath">This class REQUIRES a path</param>
        public FileLog(string filePath)
        {
            FilePath = FilePath;
        }

        public void Debug(string category, string message)
        {
            /*FileStream requires a handler that access memory. Bad use in C#
            FileMode is an enum along with FileAccess and FileShare
            FileMode is how you are handling the file
            FileAccess is what you can do to the file
            FileShare is what classes that inherits from it can do to it

            FileStream fs = new FileStream(FilePath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("{0} {1} {0}", "*******", category);
            sw.WriteLine("{0} {1} {0}", "*******", message);
            
            Close in reverse order
            
            sw.Close();
            fs.Close();*/

            using (FileStream fs = new FileStream(FilePath, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("{0} {1} {0}", "*******", category);
                    sw.WriteLine("{0} {1} {0}", "*******", message);
                }
            }


        }

        //If you are not using the Task library you name BeginDebug
        public void BeginAsync(string category, string message)
        {
            //Thread - Set of instructions for the computer
            //Process - It is the application. It can have different threads running processes. One to many. Parent for threads
            //void(object) target => takes in a function that takes in object that returns void

            //var paramThread = new ParameterizedThreadStart(obj =>
            //{
            //    FileLog fl = obj as FileLog;
            //});

            //This function can access the methods inside this thread because it is in the same scope as the otheres. This is called closure.
            var start = new ThreadStart(() =>
            {
                Debug(category, message);
            });

            //This passes in the instructions that the thread needs to do
            Thread thread = new Thread(start);

            //Starting the instruction
            thread.Start();
            //With threads you have different states that you can look at such as suspend, abort, resume, and ThreadState to state what it is doing

            //*************************************************************************************************************************************************************************
            //Events work with events
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (sender, args) =>
            {
                Debug(category, message);
            };

            //This reports everytime the progress changes
            //bw.ProgressChanged 
            bw.RunWorkerCompleted += (sender, args) =>

            {
                //In here you can do whatever to say that you are finished
                //This runs after the background worker is complete
            };

            //Same as thread.start();
            bw.RunWorkerAsync();
            //*************************************************************************************************************************************************************************
        }

        //private void Bw_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        public Task<string> DebugAsync(string category, string message)
        {
            //Task class was created due to parallel programming. There is a physical limit on how fast you can push your CPU
            Task<string> t = new Task<string>(() =>
            {
                Debug(category, message);
                return "Success";
            });
            t.Start();
            return t;
        }

        //If you declare as async you MUST return a Task
        //The generic Task<int> => int is the return type
        //With async methods use await. If you try to access the result without task.Wait(1000), you'll get an exception
        public async Task SomeDumbMethod()
        {
            string category = "Device Failures";
            string message = "Could not connect";

            string result = await DebugAsync(category, message);
            //You'll see success
            //Console.WriteLine(result);

        }

        public void Write(string message)
        {
            //using (var sr = File.OpenText(FilePath))
            //{

            //}
            File.AppendAllText(FilePath, message);
            //File.ReadAllLines(FilePath);
        }
    }
}
