using Crafty.Content;
using Crafty.GUI;
using Crafty.GUI.Controls;
using Crafty.Utils.Statics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crafty.Screens
{
    public class GameScreen : IScreen
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="worldName">World name</param>
        public GameScreen(string worldName)
        {

        }

        /// <summary>
        /// Initialization
        /// </summary>
        public void Init()
        {
            GUIManager.SetGUI(new GameGUI());
        }

        /// <summary>
        /// Update the screen
        /// </summary>
        /// <param name="gameTime">Gametime</param>
        public void Update(GameTime gameTime)
        {
            
        }

        /// <summary>
        /// Draw the screen
        /// </summary>
        /// <param name="batch">Spritebatch</param>
        public void Draw(SpriteBatch batch)
        {
            
        }
    }
}
