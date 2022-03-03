using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colorful;
using Console = Colorful.Console;
using System.Drawing;

namespace AsciiValley
{
    class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int lastX;
        public int lastY;

        private string marker = "O";
        public Color color = Color.FromArgb(255, 221, 153);
        public Color bgColor = Color.FromArgb(38, 38, 38);

        public string name { get; set; }

        public Player()
        {
            
        }
        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }


        public void Draw(int x, int y)
        {
            X = x;
            Y = y;
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = bgColor;
            Console.Write(marker, color);
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.BackgroundColor = bgColor;
            Console.Write(marker,color);
        }
    }
}
