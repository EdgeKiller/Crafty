using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crafty.Screens
{
    public static class ScreenManager
    {

        private static IScreen actualScreen;

        /// <summary>
        /// Init the actual screen
        /// </summary>
        public static void Init()
        {
            if(actualScreen != null)
                actualScreen.Init();
        }
        
        /// <summary>
        /// Update the actual screen
        /// </summary>
        /// <param name="gameTime">Gametime</param>
        public static void Update(GameTime gameTime)
        {
            if (actualScreen != null)
                actualScreen.Update(gameTime);
        }

        /// <summary>
        /// Draw the actual screen
        /// </summary>
        /// <param name="spriteBatch">Spritebatch</param>
        public static void Draw(SpriteBatch spriteBatch)
        {
            if (actualScreen != null)
                actualScreen.Draw(spriteBatch);
        }

        /// <summary>
        /// Set the actual screen
        /// </summary>
        /// <param name="screen">IScreen</param>
        public static void SetScreen(IScreen screen)
        {
            actualScreen = screen;
            if(actualScreen != null)
            {
                actualScreen.Init();
            }
        }

    }
}
