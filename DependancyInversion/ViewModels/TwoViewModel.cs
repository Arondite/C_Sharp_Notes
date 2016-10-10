using Caliburn.Micro;
using DependancyInversion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInversion.ViewModels
{
    public class TwoViewModel : Screen
    {
        private IColor _Color;

        public IColor Color 
        {
            get { return _Color; }
            set { _Color = value; NotifyOfPropertyChange(() => Color); }
        }

        public string HexColor()
        {
            return string.Format("#{0}{1}{2}", Color.R.ToString(), Color.B.ToString(), Color.G.ToString()); 
        }

        public TwoViewModel(IColor color)
        {
            Color = color;
        }
    }
}
