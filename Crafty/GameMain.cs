using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Crafty.Utils.Statics;
using Crafty.GUI;
using System;
using Crafty.Content;
using Crafty.Screens;

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
            CraftySettings.Game = this;
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
            CraftyContent.Load(Content, GraphicsDevice);
            ScreenManager.SetScreen(new MainScreen());
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
            KMState.GamePadState = GamePad.GetState(PlayerIndex.One);
            KMState.KeyboardState = Keyboard.GetState();
            KMState.MouseState = Mouse.GetState();

            if (KMState.KeyboardState.IsKeyDown(Keys.Escape))
                Exit();

            ScreenManager.Update(gameTime);

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

            ScreenManager.Draw(spriteBatch);


            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
