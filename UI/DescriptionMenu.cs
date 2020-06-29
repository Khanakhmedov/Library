using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.UI
{
    public class DescriptionMenu : Menu
    {
        public Models.Library Library { get; set; }
        public override void Run()
        {
            Console.SetCursorPosition(ItemPosition.X + 2, 2);
            Console.WriteLine(Title);
            Console.WriteLine();
            Console.WriteLine(Library.ToString());
            ItemPosition.Y = 7;
            foreach (MenuItem item in MenuItems)
            {
                item.Y = ItemPosition.Y;
                item.X = ItemPosition.X;
            }
        }
    }
}
