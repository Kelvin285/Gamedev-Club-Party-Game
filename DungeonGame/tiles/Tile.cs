using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.tiles
{
    internal class Tile
    {
        public Texture2D texture;
        public string name;
        public bool visible = true;

        public bool has_states = false;

        public List<TileState> states = new List<TileState>();

        public Tile()
        {
            name = "air";
            visible = false;
        }

        public Tile(string name)
        {
            texture = Game.INSTANCE.Content.Load<Texture2D>("tiles/" + name);
            this.name = name;
        }

        public Tile AddState(string name, int x, int y)
        {
            has_states = true;
            states.Add(new TileState(name, x, y, states.Count));
            return this;
        }
    }
}
