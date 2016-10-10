using FilesAndStreams.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
