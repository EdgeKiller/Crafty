using Crafty.Content;
using Crafty.Utils.Statics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Crafty.GUI.Controls
{
    public class TextButton : IControl
    {
        public bool Hide { get; set; }

        private string text;
        private float scale = 0.8f;
        private Rectangle rectangle;
        private Point position;
        private SpriteFont font;

        public bool clicked = true;

        public delegate void OnClickHandler();
        public event OnClickHandler OnClick;
        public delegate void OnMouseOverHandler();
        public event OnMouseOverHandler OnMouseOver;

        private float maxScale = 1.1f, minScale = 0.8f, addScale = 0.025f;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="pos">Position (-1 to center)</param>
        public TextButton(string text, Point pos)
        {
            font = CraftyContent.GetFont("gdc64");
            this.text = text;
            position = pos;
            if (position.X == -1)
                position.X = (int)((CraftySettings.VirtualScreen.X / 2));
            if (position.Y == -1)
                position.Y = (int)((CraftySettings.VirtualScreen.Y / 2));
            this.rectangle = new Rectangle(position.X - (int)(font.MeasureString(text).X / 2), position.Y - (int)(font.MeasureString(text).Y / 2), (int)font.MeasureString(text).X, (int)font.MeasureString(text).Y);
        }
        
        /// <summary>
        /// Set the current text
        /// </summary>
        /// <param name="text">Text</param>
        public void SetText(string text)
        {
            this.text = text;
        }

        /// <summary>
        /// Update the button
        /// </summary>
        /// <param name="gameTime">Gametime</param>
        public void Update(GameTime gameTime)
        {
            if (KMState.MouseRec.Intersects(rectangle))
            {
                if (scale + addScale < maxScale)
                    scale += addScale;
                if (scale + addScale > maxScale)
                    scale = maxScale;

                if (OnMouseOver != null)
                    OnMouseOver.Invoke();

                if (KMState.MouseState.LeftButton == ButtonState.Pressed)
                {
                    if (!clicked)
                    {
                        if (OnClick != null)
                            OnClick.Invoke();
                        clicked = true;
                    }
                }
                else
                {
                    clicked = false;
                }
            }
            else
            {
                if (scale - addScale > minScale)
                    scale -= addScale;
                if (scale - addScale < minScale)
                    scale = minScale;
                clicked = false;
            }
        }

        /// <summary>
        /// Draw the button
        /// </summary>
        /// <param name="spriteBatch">Spritebatch</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, new Vector2(position.X, position.Y), new Color((int)(52 * scale), (int)(73 * scale), (int)(94 * scale)), 0, 
                new Vector2(font.MeasureString(text).X/2, font.MeasureString(text).Y/2), scale, SpriteEffects.None, 1);
        }

    }
}
