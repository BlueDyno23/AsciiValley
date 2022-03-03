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
    class Game
    {
        // instantiate classes and variables

        Player player;
        World world;
        Interactions interactions;
        EventsManager eventsManager;
        Color backgroundColor = Color.FromArgb(38, 38, 38);

        // public method that executes the entire class
        public void Start()
        {
            // execute player and world constructors and give them values
            player = new Player(4,4);
            world = new World();


            // to avoid buffer and window size bugs caused by Console.SetCursorPosition
            Console.CursorVisible = false;
            Console.WriteLine("Adjust window size and press any key to continue..");
            Console.ReadKey(true);
            Console.Clear();


            // start the main menu
            // TODO: make the buttons do stuff instead of just ignoring them
            string prompt = "ASCII-VALLEY";
            string[] options = {"PLAY","ABOUT","EXIT"};
            Menu mainMenu = new Menu(prompt, options);
            int selectedOption = mainMenu.Run();
            switch (selectedOption)
            {
                case 0:

                    break;
                case 1:
                    Console.Clear();
                    string aboutText = @"\hi,
\this game was made by me and\was inspired by stardew valley
\i know its not a lot but i consider
\it to be an achievement
\ 
\thx, eyal";
                    int height = 1;
                    Console.SetCursorPosition((Console.WindowWidth / 2), 0);
                    Console.WriteLine("ABOUT: ");
                    for (int i = 0; i < aboutText.Length; i++)
                    {
                        if(aboutText[i] == '\\')
                        {
                            Console.SetCursorPosition((Console.WindowWidth / 2), height+=1);
                            Console.Write(aboutText[i+1]);
                            i += 1;
                        }
                        else
                        {
                            Console.Write(aboutText[i]);
                        }
                    }
                    System.Console.WriteLine();
                    Console.ReadKey(true);
                    Environment.Exit(1);
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }

            //instantiate the interactions class
            interactions = new Interactions(world, player);


            // load the world, and draw it for the first time, also hard coded player location
            World.LoadMap();
            world.DrawMap();
            player.Draw(4,4);

            eventsManager = new EventsManager(world, player, this, interactions);
            RunGameLoop();
        }

        private void PlayerDraw()
        {
            for (int y = 0; y < World.sizeY; y++)
            {
                for (int x = 0; x < World.sizeX; x++)
                {
                    if(y == player.Y && x == player.X)
                    {
                        Console.SetCursorPosition(x, y);
                        player.Draw();

                        //resetting player's trail
                        Console.SetCursorPosition(player.lastX, player.lastY);
                        Console.Write(world.GetElement(player.lastX,player.lastY)); 
                    }
                }
            }
        }

        private void MenuDraw()
        {
            string title = "ASCII-VALLEY";
            Console.ResetColor();
            Console.SetCursorPosition(World.sizeX+15,2);
            for (int i = 0; i < title.Length; i++)
            {
                Console.Write(title[i] + "  ");
            }
            Console.SetCursorPosition(World.sizeX + 15, 4);
            
        }

        public void OnCellChanged(object source, EventArgs e)
        {
            Console.SetCursorPosition(player.X + 1,player.Y);
            Console.BackgroundColor = backgroundColor;
            Console.Write("#");
        }

        private void RunGameLoop()
        {
            // TODO: render changes to the map
            world.DrawMap();
            MenuDraw();
            while (true)
            {
                MenuDraw();
                eventsManager.EventsListener();
                Console.CursorVisible = false;
                if (interactions.Inputs())
                {
                    PlayerDraw();
                }
            }

        }
    }
}
