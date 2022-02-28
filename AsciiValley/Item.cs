using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiValley
{
    class Item
    {
        protected int id;
        public int quantity = 0;
        public string name { get; set; }

        public Item(string name)
        {
            this.name = name;
        }
    }
}
