using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crafty.GUI.Controls
{
    public interface IControl
    {
        bool Hide { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
