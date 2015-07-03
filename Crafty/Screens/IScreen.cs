using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Crafty.Screens
{
    public interface IScreen
    {
        void Init();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch batch);
    }
}
