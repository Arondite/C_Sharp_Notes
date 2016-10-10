using Caliburn.Micro;
using DataInteractions;
using DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLandLinq.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        private ObservableCollection<Book> _Books;

        public ObservableCollection<Book> Books
        {
            get { return _Books; }
            set { _Books = value; NotifyOfPropertyChange(() => Books); }
        }

        protected IXMLDataProvider XmlProvider { get; set; }

        public MainViewModel(IXMLDataProvider xmlProvider)
        {
            XmlProvider = xmlProvider;
            OnActivate();
        }
        protected void OnActivate()
        {  
            XmlProvider.FilePath = "books.xml";
            Books = new ObservableCollection<Book>(XmlProvider.GetBooks());
        }
    }
}
