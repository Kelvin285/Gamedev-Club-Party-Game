using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.tiles
{
    internal class TileLoader
    {
        public static List<Tile> tiles = new List<Tile>();

        public static void LoadTile(string tile)
        {
            tiles.Add(new Tile(tile));
        }
    }
}
