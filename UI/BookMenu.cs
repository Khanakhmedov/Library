using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI
{
    public class BookMenu : Menu
    {
        public Book book { get; set; }
        public override void Run()
        {
            Console.SetCursorPosition(ItemPosition.X + 2, 2);
            Console.WriteLine(Title);
            Console.WriteLine();
            Console.WriteLine(book.ToString());
            ItemPosition.Y = 7;
            foreach (MenuItem item in MenuItems)
            {
                item.Y = ItemPosition.Y;
                ItemPosition.Y += 3;
                item.X = ItemPosition.X;
            }
        }
    }
}
