using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DungeonGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D texture;
        private RenderTarget2D renderTarget;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            texture = Content.Load<Texture2D>("tiles/floor");

            renderTarget = new RenderTarget2D(GraphicsDevice, 1920 / 4, 1080 / 4);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            GraphicsDevice.SetRenderTarget(renderTarget);

            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            for (int x = 0; x < 16; x++)
            {
                _spriteBatch.Draw(texture, new Rectangle(x: x * 16, y: 16, width: 16, height: 16), new Rectangle(x: 0, y: 0, width: 16, height: 16), Color.White);
            }

            _spriteBatch.End();


            GraphicsDevice.SetRenderTarget(null);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(renderTarget, new Rectangle(0, 0, Window.ClientBounds.Width / 2, Window.ClientBounds.Height / 2), Color.White);

            _spriteBatch.Draw(renderTarget, new Rectangle(Window.ClientBounds.Width / 2, 0, Window.ClientBounds.Width / 2, Window.ClientBounds.Height / 2), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}