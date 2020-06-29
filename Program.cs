using Library.JsonDataBase.Interfaces;
using Library.UI;
using LibraryApp.XmlDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            IDataBase data = new DataBase();
            Manager manager = new Manager(data);
            manager.Start();
        }
    }
}
