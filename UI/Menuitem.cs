using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI
{
    public abstract class MenuItem
    {
        public Menu LinkMenu { get; set; }
        public string Text { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public Action Action { get; set; }
        public int Index { get; set; }
        public bool IsHover;

        public virtual void Draw() { }

    }
}
