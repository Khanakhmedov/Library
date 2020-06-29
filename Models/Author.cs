using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Author
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }

        public override string ToString()
        {
            return ($"{FirstName} {SurName}");
        }
    }
}
