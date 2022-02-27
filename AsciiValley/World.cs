using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colorful;
using Console = Colorful.Console;
using System.Drawing;
using System.IO;

namespace AsciiValley
{
    class World
    {
        private static string[,] Grid;
        private static string[,,] Grids;
        public static int sizeY;
        public static int sizeX;

        public World()
        {

        }
        public World(string[,] grid)
        {
            Grid = grid;
        }
        public World(string[,,] grids)
        {
            Grids = grids;
        }

        public static void LoadMap()
        {
            string path = $"{Directory.GetCurrentDirectory()}\\Maps";
            string fpath = Directory.GetFiles(path)[0];
            string first = File.ReadAllLines(fpath)[0];

            int rows = File.ReadAllLines(fpath).Length;
            int cols = first.Length;

            sizeY = rows;
            sizeX = cols;

            Grid = new string[rows, cols];

            for (int y = 0; y < rows; y++)
            {
                string line = File.ReadAllLines(fpath)[y];
                for (int x = 0; x < cols; x++)
                {
                    Grid[y, x] = line[x].ToString();
                }
            }
        }

        public void DrawMap()
        {
            Console.CursorVisible = false;
            for (int y = 0; y < Grid.GetLength(0); y++)
            {
                for (int x = 0; x < Grid.GetLength(1); x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.BackgroundColor = Color.FromArgb(38, 38, 38);
                    Console.Write(Grid[y,x]);
                    Console.ResetColor();
                }
            }
            Console.ResetColor();
        }

        public bool isNonCollidable(int x, int y)
        {
            if (y < 0 || x < 0 || y >= Grid.GetLength(0) || x >= Grid.GetLength(1))
            {
                return false;
            }

            return Grid[y, x] == " " || Grid[y,x] == "#";
        }

        public string GetElement(int x, int y)
        {
            return Grid[y, x];
        }

        public void SetElement(int x,int y, char element)
        {
            Grid[y, x] = element.ToString();
            
        }
    }
}
