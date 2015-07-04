using Crafty.GUI.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Crafty.GUI
{
    public class GUI
    {
        public List<IControl> Controls = new List<IControl>();

        public virtual void Init() { }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] != null)
                    if (!Controls[i].Hide)
                        Controls[i].Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] != null)
                    if (!Controls[i].Hide)
                        Controls[i].Draw(spriteBatch);
            }
        }

    }
}