using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Library
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<Book> Books { get; set; }

        public override string ToString()
        {
            return ($"   Имя: \t{Name}\n" +
                    $"   Адрес: \t{Address}\n" +
                    $"   Телефон: \t{Phone}\n");
        }
    }
}
