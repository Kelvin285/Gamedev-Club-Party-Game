using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.tiles
{
    internal class TileState
    {
        public int x;
        public int y;
        public string name;
        public int id;

        public TileState(string name, int x, int y, int id)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.id = id;
        }
    }
}
