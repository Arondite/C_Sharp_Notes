using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInversion.Interfaces
{
	/// <summary>
	/// Interface to capitalize on Dependancy Inversion
	/// </summary>
    public interface ILog
    {
        string Logname { get; set; }
        void Log(string message);
    }
}
