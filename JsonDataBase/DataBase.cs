using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Library.Models;
using Library.JsonDataBase.Interfaces;

namespace LibraryApp.XmlDataBase
{
    public class DataBase : IDataBase
    {
        public Library.Models.Library library { get; set; }

        public DataBase()
        {
            if (!File.Exists("lib.json"))
            {
                library = new Library.Models.Library()
                {
                    Name = "Test",
                    Address = "Test",
                    Phone = "Test",
                    Books = new List<Library.Models.Book>()

                };
                var obj = JsonConvert.SerializeObject(library);
                File.WriteAllText("lib.json", obj);
            }
            else
            {
                string readText = File.ReadAllText("lib.json");
                library = JsonConvert.DeserializeObject<Library.Models.Library>(readText);
            }
        }


        public Library.Models.Library GetLibrary()
        {
            return library;
        }

        public List<Book> GetBooks()
        {
            return library.Books;
        }

        public void AddBook(Book book)
        {
            library.Books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            library.Books.Remove(book);
        }

        public void Save()
        {
            var obj = JsonConvert.SerializeObject(library);
            File.WriteAllText("lib.json", obj);
        }
    }
}
