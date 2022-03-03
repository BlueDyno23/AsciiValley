using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiValley
{
    class Menu
    {
        private string prompt;
        private string[] options;
        private int selectedIndex = 0;

        public Menu(string prompt, string[] options)
        {
            this.prompt = prompt;
            this.options = options;
        }

        private void DisplayOptions()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition((Console.WindowWidth/2),0);
            Console.WriteLine(prompt+"\n");
            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.SetCursorPosition((Console.WindowWidth / 2), i+2);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine($"<< {options[i]} >>");
                }
                else
                {
                    Console.SetCursorPosition((Console.WindowWidth / 2), i+2);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine($"<< {options[i]} >>");
                }
                Console.ResetColor();
            }
        }

        /*private void DisplayParameters()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition((Console.WindowWidth / 2), 0);
            Console.WriteLine(prompt + "\n");
            for (int i = 0; i < length; i++)
            {

            }
        }*/

        public int Run()
        {
            ConsoleKey key;
            do
            {
                Console.Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex++;
                    }
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex >= options.Length)
                    {
                        selectedIndex--;
                    }
                }
                else if (key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    return selectedIndex;
                }
            }
            while (key != ConsoleKey.Escape);

            Environment.Exit(0);
            return 0;
        }
    }
}
