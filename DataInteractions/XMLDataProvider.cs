using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using System.Xml.Linq;

namespace DataInteractions
{
    /// <summary>
    /// This is in its own project because of "Seperation of Concerns"
    /// </summary>
    public class XMLDataProvider : IXMLDataProvider
    {
        public string FilePath { get; set; }

        public IEnumerable<Book> GetBooks()
        {
            XDocument document = XDocument.Load(FilePath);
            //Attributes are inside the tag in XML, Elements are in the body of the Tag
            var results = from book in document.Root.Elements()
                          select new Book()
                          {
                              Id = book.Attribute("id").Value,
                              Author = book.Element("author").Value,
                              Title = book.Element("title").Value,
                              Genre = book.Element("genre").Value,
                              Price = Decimal.Parse(book.Element("price").Value),
                              PublishDate = DateTime.Parse(book.Element("publish_date").Value),
                              Description = book.Element("description").Value
                          };
            return results.ToList();
        }
        public IEnumerable<string> GetAuthors()
        {
            var document = XDocument.Load(FilePath);
            var authors = from book in document.Root.Elements()
                          from author in book.Elements("author")
                          where !string.IsNullOrWhiteSpace(author.Value)
                          select author.Value;
            return authors;
        }

    }
}
