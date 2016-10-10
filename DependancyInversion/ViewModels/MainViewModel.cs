using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInversion.ViewModels
{
    /// <summary>
    /// The purpose of this class is to conduct the screens. The Type class is what is known as reflection. The reflection is around the language itself. I.e. you can get all the constructors 
    /// of the object you can get all the members. You ar literally working with the Metadata.
    /// </summary>
    public class MainViewModel : Conductor<Screen>.Collection.OneActive
    {
        protected override void OnActivate()
        {
            base.OnActivate();
            ActivateItem(IoC.Get<OneViewModel>());
        }
        public void ShowViewModel1()
        {
            ActivateItem(IoC.Get<OneViewModel>());
        }
        public void ShowViewModel2()
        {
            ActivateItem(IoC.Get<TwoViewModel>());
        }
    }
}
