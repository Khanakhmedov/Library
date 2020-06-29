using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI
{
    public class MenuSeparator : MenuItem
    {
        public MenuSeparator()
        {
            Height = 3;
            Width = 30;
        }

        public override void Draw()
        {
            if (IsHover)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            for (int j = 0; j < Height; ++j)
            {
                for (int i = 0; i < Width; ++i)
                {
                    Console.SetCursorPosition(X + i + 1, Y + j);
                    if (i == 0 && j == 0)
                    {
                        Console.Write('╭');   
                    }
                    else if (i == 0 && j == Height - 1)
                    {
                        Console.Write('╰');
                    }
                    else if (i == Width - 1 && j == 0)
                    {
                        Console.Write('╮');
                    }
                    else if (i == Width - 1 && j == Height - 1)
                    {
                        Console.Write('╯');
                    }
                    else if (i == 0 || i == Width - 1)
                    {
                        Console.Write('│');
                    }
                    else if (j == 0 || j == Height - 1)
                    {
                        Console.Write('─');
                    }
                    else if (i == 1 || i >= Text.Length + 2)
                    {
                        Console.Write(' ');
                    }
                    else if (i == 1 || i < Text.Length + 2)
                    {
                        Console.Write(Text[i - 2]);
                    }
                }
                Console.WriteLine("");

            }
            Console.ResetColor();

        }
    }
}
