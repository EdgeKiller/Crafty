using Crafty.Utils.Statics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crafty.GUI.Controls
{
    public class Label : IControl
    {
        private string text;
        private Point position;
        private SpriteFont font;
        private Color color;

        public Label(string text, Point pos, Color color, SpriteFont font)
        {
            this.font = font;
            this.text = text;
            this.color = color;
            position = pos;
            if (position.X == -1)
                position.X = (int)((CraftySettings.VirtualScreen.X / 2));
            if (position.Y == -1)
                position.Y = (int)((CraftySettings.VirtualScreen.Y / 2));
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, new Vector2(position.X, position.Y), color, 0,
                new Vector2(font.MeasureString(text).X / 2, font.MeasureString(text).Y / 2), 1.0f, SpriteEffects.None, 1);
        }
    }
}
