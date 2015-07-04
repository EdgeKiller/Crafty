using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Crafty.GUI;

namespace Crafty.Screens
{
    public class MainScreen : IScreen
    {
        /// <summary>
        /// Init
        /// </summary>
        public void Init()
        {
            GUIManager.SetGUI(new MainGUI());
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime">Gametime</param>
        public void Update(GameTime gameTime)
        {
            
        }

        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="spriteBatch">Spritebatch</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
