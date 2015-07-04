using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Crafty.Content;
using Crafty.Utils.Statics;

namespace Crafty.GUI.Controls
{
    public class ColoredBackground : IControl
    {
        public bool Hide { get; set; }

        private Color color;

        public ColoredBackground(Color color)
        {
            this.color = color;
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(CraftyContent.GetTexture("pixel"), new Rectangle(0, 0, CraftySettings.VirtualScreen.X, CraftySettings.VirtualScreen.Y), color);
        }
    }
}
