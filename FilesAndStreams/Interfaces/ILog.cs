using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndStreams.Interfaces
{
    public interface ILog
    {//Just a reminder, in an interface you have no access modifiers
        void Debug(string category, string message);
        void Write(string message);
    }
}
