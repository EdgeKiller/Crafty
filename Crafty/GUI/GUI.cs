using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Crafty.GUI
{
    public class GUI
    {
        public List<Control> Controls = new List<Control>();

        public virtual void Init() { }

        public void Update(GameTime gameTime)
        {
            foreach(Control c in Controls)
            {
                c.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Control c in Controls)
            {
                c.Draw(spriteBatch);
            }
        }

    }
}