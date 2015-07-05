using Crafty.GUI.Controls;
using Crafty.Utils.Statics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crafty.GUI
{
    /// <summary>
    /// GUI Manager
    /// </summary>
    public static class GUIManager
    {

        private static GUI actualGUI;

        /// <summary>
        /// Init the GUI
        /// </summary>
        public static void Init()
        {
            if (actualGUI != null)
                actualGUI.Init();
        }

        /// <summary>
        /// Update the GUI
        /// </summary>
        /// <param name="gameTime">Gametime</param>
        public static void Update(GameTime gameTime)
        {
            if (actualGUI != null)
                actualGUI.Update(gameTime);
        }

        /// <summary>
        /// Draw the GUI
        /// </summary>
        /// <param name="spriteBatch">Spritebatch</param>
        public static void Draw(SpriteBatch spriteBatch)
        {
            if (actualGUI != null)
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, CraftyConfig.Scale);
                actualGUI.Draw(spriteBatch);
                spriteBatch.End();
            }
        }

        /// <summary>
        /// Set the GUI
        /// </summary>
        /// <param name="gui">Gui</param>
        public static void SetGUI(GUI gui)
        {
            actualGUI = gui;
            if(actualGUI != null)
                Init();
        }

        /// <summary>
        /// Clear the GUI
        /// </summary>
        public static void Clear()
        {
            actualGUI = null;
        }

    }
}
