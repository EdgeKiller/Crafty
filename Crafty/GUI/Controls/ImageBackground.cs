using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Crafty.Utils.Statics;

namespace Crafty.GUI.Controls
{
    public class ImageBackground : IControl
    {
        public bool Hide { get; set; }
        private Texture2D texture;

        public ImageBackground(Texture2D texture)
        {
            this.texture = texture;
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(0, 0, CraftySettings.VirtualScreen.X, CraftySettings.VirtualScreen.Y), Color.White);
        }
    }
}
