using Crafty.Content;
using Crafty.Utils.Statics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crafty.GUI.Controls
{
    public class Cursor : IControl
    {
        private Point position;
        private Texture2D texture, resetTexture;

        public Cursor(string texture)
        {
            this.texture = CraftyContent.GetTexture(texture);
            resetTexture = this.texture;
            position = KMState.MousePos;
        }

        public void Update(GameTime gameTime)
        {
            position = KMState.MousePos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(position.X, position.Y), Color.White);
        }

        public void SetTexture(string texture)
        {
            this.texture = CraftyContent.GetTexture(texture);
        }

        public void ResetTexture()
        {
            texture = resetTexture;
        }
    }
}
