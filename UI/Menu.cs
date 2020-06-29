using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.UI
{
    public class Menu
    {
        public List<MenuItem> MenuItems { get; set; }
        public string Title { get; set; }
        public virtual void Run()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(ItemPosition.X + 2, 2);
            Console.WriteLine(Title);
            
            foreach (MenuItem item in MenuItems)
            {
                item.Y = ItemPosition.Y;
                ItemPosition.Y += 3;
                item.X = ItemPosition.X;
            }
        }
    }
}
