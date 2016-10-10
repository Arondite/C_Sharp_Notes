using DependancyInversion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInversion.Implementation
{
	/// <summary>
	/// This is a class that I have implemented the interface IResourceProvider, so I can pass it into the constructor in my OneViewModel
	/// It contains dummy data
	/// </summary>
    public class ResourceProvider : IResourceProvider
    {
        protected Dictionary<string, object> Settings = new Dictionary<string, object>(){
            {"ApplicationName", "Development Application" },
            {"CourseName","In Development" },
            {"CourseNumber","0000000000" }
        };
        public T Get<T>(string name)
        {
            if (Settings.ContainsKey(name))
                return (T)Settings[name];

            throw new KeyNotFoundException("Cound not find setting");
        }
    }
}
