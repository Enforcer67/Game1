using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RheinwerkAdventure.Model
{
    class Area
    {
        public int Height { get; private set; }
        public int Width { get; private set; }

        public Tile[,] Tiles
        {
            get;
            private set;
        }

        public List<Item> Items
        {
            get;
            private set;
        }

        public Area(int width, int height)
        {
            Width = width;
            Height = height;

            Tiles = new Tile[width, height];
            Items = new List<Item>();
        }


    }
}
