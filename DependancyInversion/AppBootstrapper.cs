using Caliburn.Micro;
using DependancyInversion.Implementation;
using DependancyInversion.Interfaces;
using DependancyInversion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DependancyInversion
{

    public class AppBootstrapper : BootstrapperBase
    {
        protected SimpleContainer container { get; set; }

        public AppBootstrapper()
        {
            Initialize();
        }
     
        protected override void Configure()
        {
            container = new SimpleContainer();

            container.Singleton<IEventAggregator, EventAggregator>();
            container.Singleton<IWindowManager, WindowManager>();

            container.Singleton<MainViewModel>();
            container.PerRequest<OneViewModel>();
            container.PerRequest<TwoViewModel>();
            container.Singleton<IResourceProvider, ResourceProvider>();
            //container.Singleton<IColor, Color>();
        }

        /// <summary>
        /// Type holds the information of what the object is. When caliburn is told that it needs something, it looks through the Type class that will return the Type the object is. 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        protected override object GetInstance(Type service, string key)
        {
            var instance = container.GetInstance(service, key);
            if (instance != null)
                return instance;
            throw new InvalidOperationException("Could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }
        

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
