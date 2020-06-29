using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI
{
    public static class ItemPosition
    {
        public static int X { get; set; } = 1;
        public static int Y { get; set; } = 4;
        public static int LastIndexPosition { get; set; } = 0;

        static public void Reset()
        {
            X = 1;
            Y = 4;
        }
    }
}
