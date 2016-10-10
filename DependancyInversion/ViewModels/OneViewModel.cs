using Caliburn.Micro;
using DependancyInversion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInversion.ViewModels
{
    public class OneViewModel : Screen
    {
        public IResourceProvider ResourceProvider { get; set; }
        private string _CourseName;

        public string CourseName
        {
            get { return _CourseName; }
            set { _CourseName = value; NotifyOfPropertyChange(() => CourseName); }
        }

        private string _CourseNumber;

        public string CourseNumber
        {
            get { return _CourseNumber; }
            set { _CourseNumber = value; NotifyOfPropertyChange(() => CourseNumber); }
        }

        /// <summary>
        /// This Constructor demostrates the use of dependency injection
        /// </summary>
        /// <param name="resource"></param>
        public OneViewModel(IResourceProvider resource)
        {
            ResourceProvider = resource;
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            CourseName = ResourceProvider.Get<string>("CourseName");
            CourseNumber = ResourceProvider.Get<string>("CourseNumber");
        }
    }
}
