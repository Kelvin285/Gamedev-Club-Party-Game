using DungeonGame.dungeon;
using DungeonGame.tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DungeonGame
{
    internal class Game : Microsoft.Xna.Framework.Game
    {

        public static Game INSTANCE;


        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        public Vector2 camera;

        public Floor floor;

        public RenderTarget2D target;

        public int s_width, s_height;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Window.AllowUserResizing = true;


            INSTANCE = this;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            TileLoader.tiles.Add(new Tile());
            TileLoader.LoadTile("floor");
            target = new RenderTarget2D(GraphicsDevice, 256 + 32, 256 + 32);

            floor = new Floor(4);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }



        protected override void Draw(GameTime gameTime)
        {
            Viewport viewport = GraphicsDevice.Viewport;
            viewport.X = (int)-camera.X;
            viewport.Y = (int)camera.Y;
            GraphicsDevice.Viewport = viewport;

            camera.Y += 1;

            floor.UpdateImages();

            GraphicsDevice.SetRenderTarget(target);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            //_spriteBatch.Draw(renderTarget, new Rectangle(0, 0, Window.ClientBounds.Width / 2, Window.ClientBounds.Height / 2), Color.White);

            floor.RenderBackground();

            // render players

            floor.RenderForeground();

            spriteBatch.End();
            GraphicsDevice.SetRenderTarget(null);

            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(target, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}