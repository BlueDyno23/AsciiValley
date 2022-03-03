using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiValley
{

    class Interactions
    {
        private World world;
        private Player player;

        public Interactions(World world, Player player)
        {
            this.world = world;
            this.player = player;
        }

        public bool Inputs()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (world.isNonCollidable(player.X, player.Y - 1))
                    {
                        player.lastY = player.Y;
                        player.lastX = player.X;
                        player.Y -= 1;
                        return true;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (world.isNonCollidable(player.X, player.Y + 1))
                    {
                        player.lastY = player.Y;
                        player.lastX = player.X;
                        player.Y += 1;
                        return true;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (world.isNonCollidable(player.X + 1, player.Y))
                    {
                        player.lastY = player.Y;
                        player.lastX = player.X;
                        player.X += 1;
                        return true;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (world.isNonCollidable(player.X - 1, player.Y))
                    {
                        player.lastY = player.Y;
                        player.lastX = player.X;
                        player.X -= 1;
                        return true;
                    }
                    break;
                case ConsoleKey.Enter:
                    Planting();
                    break;

                default:
                    return false;
                    break;
            }
            return false;
        }

        public delegate void CellChangedEventHandler(object source, EventArgs args);
        public event CellChangedEventHandler CellChanged;

        private void Planting()
        {

            if (world.GetElement(player.X+1, player.Y) == " " || world.isNonCollidable(player.X+1, player.Y))
            {
                world.SetElement(player.X+1, player.Y, '#');
                OnCellChanged();
            }

        }

        protected virtual void OnCellChanged()
        {
            if(CellChanged!= null)
            {
                CellChanged(this, EventArgs.Empty);
            }
        }
    }
}
