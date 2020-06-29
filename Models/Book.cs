using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public Author Author { get; set; }

        public override string ToString()
        {
            return ($"   Название: \t{Title}\n" +
                    $"   Автор: \t{Author.ToString()}\n" +
                    $"   Релиз: \t{ReleaseDate}\n");
        }
    }
}
