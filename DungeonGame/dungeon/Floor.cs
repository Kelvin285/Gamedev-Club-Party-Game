using DungeonGame.tiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.dungeon
{
    internal class Floor
    {
        public Room[] rooms;

        public Room current;

        public Floor(int num_rooms)
        {
            rooms = new Room[num_rooms];

            for (int i = 0; i < num_rooms; i++)
            {
                rooms[i] = new Room();

                for (int x = 0; x < 16; x++)
                {
                    for (int y = 0; y < 16; y++)
                    {
                        rooms[i].SetFloorTile(x, y, "floor");
                    }
                }

            }

            current = rooms[0];
        }

        public void UpdateImages()
        {
            current.UpdateImages();
        }

        public void RenderForeground()
        {
            Game.INSTANCE.spriteBatch.Draw(current.foreground, new Rectangle(0, 0, 256, 256), Color.White);
        }

        public void RenderBackground()
        {
            Game.INSTANCE.spriteBatch.Draw(current.background, new Rectangle(0, 0, 256, 256), Color.White);
        }
    }
}
