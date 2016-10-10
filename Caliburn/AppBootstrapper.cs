using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Collections;
using System.Windows;
using Caliburn.ViewModels;

/// <summary>
/// Caliburn works off of naming convention.
/// Caliburn Notes:
/// 1. Views must have "Views" as the last piece of the namespace
/// 2. ViewModels must have "ViewModels" as the last piece of the namespace
/// 3. Views and ViewModels must have the same name, except ViewModels appends "Model"
/// 4. All Views must end in either "View" or "Page"
/// </summary>
namespace Caliburn
{
    /// <summary>
    /// This class is initilized in app.xaml
    /// </summary>
    public class AppBootstrapper : BootstrapperBase
    {
        SimpleContainer container;

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new SimpleContainer();

            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();
            
            
            //Adding the class to the container
            container.Singleton<MainViewModel>();
            container.Singleton<UsersViewModel>();
            container.PerRequest<UselessViewModel>();
        }

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
            //On startup display this
            DisplayRootViewFor<MainViewModel>();
        }

    }
}
