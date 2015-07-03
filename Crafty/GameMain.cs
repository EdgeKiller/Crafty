using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Crafty.Utils.Statics;
using Crafty.GUI;
using System;
using Crafty.Content;

namespace Crafty
{
    /// <summary>
    /// GameMain Class
    /// </summary>
    public class GameMain : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        /// <summary>
        /// Constructor
        /// </summary>
        public GameMain()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Initialization
        /// </summary>
        protected override void Initialize()
        {
            CraftyConfig.Load();
            graphics.PreferredBackBufferWidth = (int)CraftyConfig.Resolution.X;
            graphics.PreferredBackBufferHeight = (int)CraftyConfig.Resolution.Y;
            graphics.IsFullScreen = CraftyConfig.Fullscreen;
            graphics.ApplyChanges();
            this.Window.Title = CraftySettings.Name + " v" + CraftySettings.Version;
            this.IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// Load content (textures,sounds,fonts...)
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            CraftyContent.Load(GraphicsDevice);
        }

        /// <summary>
        /// Unload content (useful ?)
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime">GameTime</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="gameTime">GameTime</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, CraftyConfig.Scale);

            spriteBatch.Draw(CraftyContent.GetTexture("pixel"), new Rectangle(0, 0, 50, 50), Color.Red);

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
