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
        Player player;
        World world;
        Interactions interactions;
        EventsManager eventsManager;

        public void Start()
        {
            Console.WriteLine("Adjust window size and press any key to continue..");
            Console.ReadKey(true);
            Console.Clear();

            string prompt = "ASCII-VALLEY";
            string[] options = {"PLAY","ABOUT","EXIT"};

            Menu mainMenu = new Menu(prompt, options);
            mainMenu.Run();

            player = new Player();
            world = new World();

            interactions = new Interactions(world, player);

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
            Console.Write(player.item.name+"\t"+player.item.quantity);
        }

        public void OnCellChanged(object source, EventArgs e)
        {
            Item veg = new Item("veggie");
            Console.SetCursorPosition(player.X + 1,player.Y);
            Console.BackgroundColor = Color.FromArgb(38, 38, 38);
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
