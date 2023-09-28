using DungeonGame.tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.dungeon
{
    internal class Room
    {
        public int[,] fg_tiles = new int[16, 16];
        public int[,] fg_states = new int[16, 16];

        public int[,] bg_tiles = new int[16, 16];
        public int[,] bg_states = new int[16, 16];

        public RenderTarget2D foreground;
        public RenderTarget2D background;

        private bool needs_to_update = true;

        private int seed;
        public Room()
        {
            foreground = new RenderTarget2D(Game.INSTANCE.GraphicsDevice, 256, 256);
            background = new RenderTarget2D(Game.INSTANCE.GraphicsDevice, 256, 256);
            seed = new Random().Next();
        }

        public void UpdateImages()
        {

            if (!needs_to_update) return;
            needs_to_update = false;

            var batch = Game.INSTANCE.spriteBatch;

            Random random = new Random(seed);

            Game.INSTANCE.GraphicsDevice.SetRenderTarget(foreground);
            Game.INSTANCE.GraphicsDevice.Clear(Color.FromNonPremultiplied(Vector4.Zero));
            batch.Begin(samplerState: SamplerState.PointClamp);

            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    int id = fg_tiles[x, y];
                    Tile tile = TileLoader.tiles[id];

                    if (tile.visible)
                    {
                        int tile_x = 0;
                        int tile_y = 0;

                        if (tile.has_states)
                        {
                            tile_x = tile.states[fg_states[x, y]].x * 16;
                            tile_y = tile.states[fg_states[x, y]].y * 16;
                        }
                        else
                        {
                            int width = tile.texture.Width;
                            int height = tile.texture.Height;

                            int num_x = width / 16;
                            int num_y = height / 16;

                            tile_x = random.Next(num_x) * 16;
                            tile_y = random.Next(num_y) * 16;
                        }
                        batch.Draw(tile.texture, new Rectangle(x: x * 16, y: y * 16, width: 16, height: 16), new Rectangle(x: tile_x, y: tile_y, width: 16, height: 16), Color.White);
                    }

                }
            }

            batch.End();



            Game.INSTANCE.GraphicsDevice.SetRenderTarget(background);
            Game.INSTANCE.GraphicsDevice.Clear(Color.FromNonPremultiplied(Vector4.Zero));
            batch.Begin(samplerState: SamplerState.PointClamp);

            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    int id = bg_tiles[x, y];
                    Tile tile = TileLoader.tiles[id];

                    if (tile.visible)
                    {
                        int tile_x = 0;
                        int tile_y = 0;

                        if (tile.has_states)
                        {
                            tile_x = tile.states[bg_states[x, y]].x * 16;
                            tile_y = tile.states[bg_states[x, y]].y * 16;
                        }
                        else
                        {
                            int width = tile.texture.Width;
                            int height = tile.texture.Height;

                            int num_x = width / 16;
                            int num_y = height / 16;

                            tile_x = random.Next(num_x) * 16;
                            tile_y = random.Next(num_y) * 16;
                        }

                        batch.Draw(tile.texture, new Rectangle(x: x * 16, y: y * 16, width: 16, height: 16), new Rectangle(x: tile_x, y: tile_y, width: 16, height: 16), Color.White);
                    }

                }
            }

            batch.End();


            Game.INSTANCE.GraphicsDevice.SetRenderTarget(null);

        }

        public void SetWallTile(int x, int y, string name, string state = "")
        {
            Tile tile;
            for (int i = 0; i < TileLoader.tiles.Count; i++)
            {
                if (TileLoader.tiles[i].name == name)
                {
                    tile = TileLoader.tiles[i];

                    fg_tiles[x, y] = i;
                    for (int j = 0; j < tile.states.Count; j++)
                    {
                        if (tile.states[j].name == state)
                        {
                            fg_states[x, y] = j;
                            break;
                        }
                    }
                    break;
                }
            }
        }

        public void SetFloorTile(int x, int y, string name, string state = "")
        {
            Tile tile;
            for (int i = 0; i < TileLoader.tiles.Count; i++)
            {
                if (TileLoader.tiles[i].name == name)
                {
                    tile = TileLoader.tiles[i];

                    bg_tiles[x, y] = i;
                    for (int j = 0; j < tile.states.Count; j++)
                    {
                        if (tile.states[j].name == state)
                        {
                            bg_states[x, y] = j;
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }
}
