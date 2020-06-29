using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.JsonDataBase.Interfaces
{
    public interface IDataBase
    {
        Library.Models.Library library { get; set; }
        Library.Models.Library GetLibrary();
        List<Book> GetBooks();
        void RemoveBook(Book book);
        void AddBook(Book book);
        void Save();
    }
}
