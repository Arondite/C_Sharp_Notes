using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInteractions
{
    public interface IXMLDataProvider
    {
        IEnumerable<Book> GetBooks();
        string FilePath { get; set;}
        IEnumerable<string> GetAuthors();

    }
}
