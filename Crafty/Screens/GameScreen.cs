using Crafty.Content;
using Crafty.CraftyGame.Map;
using Crafty.GUI;
using Crafty.GUI.Controls;
using Crafty.Utils.Statics;
using Crafty.CraftyGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Crafty.Screens
{
    public class GameScreen : IScreen
    {
        Player player;
        List<Player> players;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="worldName">World name</param>
        public GameScreen(string worldName)
        {
            World.Name = worldName;
        }

        /// <summary>
        /// Initialization
        /// </summary>
        public void Init()
        {
            GUIManager.SetGUI(new GameGUI());
            World.Create("world1");
            //World.Load(World.Name);
            player = new Player(0);
        }

        /// <summary>
        /// Update the screen
        /// </summary>
        /// <param name="gameTime">Gametime</param>
        public void Update(GameTime gameTime)
        {
            World.Update(gameTime);
            player.Update(gameTime);
        }

        /// <summary>
        /// Draw the screen
        /// </summary>
        /// <param name="batch">Spritebatch</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            World.Draw(spriteBatch);
            player.Draw(spriteBatch);
        }
    }
}
