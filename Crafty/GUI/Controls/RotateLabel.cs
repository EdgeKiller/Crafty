using Crafty.Utils.Statics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crafty.GUI.Controls
{
    public class RotateLabel : IControl
    {
        public bool Hide { get; set; }

        private string text;
        private Point position;
        private SpriteFont font;
        private Color color;

        private float rotation = 0f, maxRotate, addRotate;
        private bool direction = true;

        public RotateLabel(string text, Point pos, Color color, SpriteFont font, float maxRotate = 0.1f, float addRotate = 0.002f)
        {
            this.maxRotate = maxRotate;
            this.addRotate = addRotate;
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
            
            if(direction)
            {
                rotation += addRotate;
                if (rotation > maxRotate)
                    direction = false;
            }
            else
            {
                rotation -= addRotate;
                if (rotation < -maxRotate)
                    direction = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, new Vector2(position.X, position.Y), color, rotation,
                new Vector2(font.MeasureString(text).X / 2, font.MeasureString(text).Y / 2), 1.0f, SpriteEffects.None, 1);
        }
    }
}
