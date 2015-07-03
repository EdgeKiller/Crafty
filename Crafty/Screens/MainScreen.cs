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
        public void Init()
        {
            GUIManager.SetGUI(new MainGUI());
        }

        public void Update(GameTime gameTime)
        {
            GUIManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            GUIManager.Draw(spriteBatch);
        }
    }
}
