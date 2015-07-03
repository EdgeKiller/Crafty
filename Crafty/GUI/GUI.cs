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
            foreach(IControl c in Controls)
            {
                c.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(IControl c in Controls)
            {
                c.Draw(spriteBatch);
            }
        }

    }
}