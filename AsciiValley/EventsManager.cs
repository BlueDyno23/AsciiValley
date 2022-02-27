using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiValley
{
    class EventsManager
    {
        private World world;
        private Player player;
        private Game game;
        private Interactions interactions;

        public EventsManager(World world, Player player,Game game,Interactions interactions)
        {
            this.world = world;
            this.player = player;
            this.game = game;
            this.interactions = interactions;
        }

        public void FireEvents()
        {
            interactions.CellChanged += game.OnCellChanged;
        }
    }
}
