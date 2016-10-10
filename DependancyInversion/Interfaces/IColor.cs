using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInversion.Interfaces
{
	/// <summary>
	/// /// Interface to capitalize on Dependancy Inversion
	/// </summary>
	public interface IColor
    {
        byte R { get; }
        byte G { get; }
        byte B { get; }
        byte A { get; }

        IColor New(byte r, byte g, byte b, byte a = 1);
        IColor FromHtml(string color);
    }
}
