using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Crafty.Content;
using Crafty.Utils.Statics;
using Microsoft.Xna.Framework.Input;

namespace Crafty.GUI.Controls
{
    public class TextButton : IControl
    {
        private string text;
        private float scale = 1f;
        private Rectangle rectangle;
        private Point position;
        private SpriteFont font;

        private bool clicked = false;

        public delegate void OnClickHandler();
        public event OnClickHandler OnClick;
        public delegate void OnMouseOverHandler();
        public event OnMouseOverHandler OnMouseOver;

        public TextButton(string text, Point pos)
        {
            font = CraftyContent.GetFont("kraash24");
            this.text = text;
            position = pos;
            if (position.X == -1)
                position.X = (int)((CraftySettings.VirtualScreen.X / 2));
            if (position.Y == -1)
                position.Y = (int)((CraftySettings.VirtualScreen.Y / 2));
            this.rectangle = new Rectangle(position.X - (int)(font.MeasureString(text).X / 2), position.Y - (int)(font.MeasureString(text).Y / 2), (int)font.MeasureString(text).X, (int)font.MeasureString(text).Y);
        }


        public void Update(GameTime gameTime)
        {
            if (KMState.MouseRec.Intersects(rectangle))
            {               
                if(scale < 1.3f)
                    scale += 0.025f;
                if (scale + 0.025f > 1.3f)
                    scale = 1.3f;

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
                if (scale > 1f)
                    scale -= 0.025f;
                if (scale - 0.025f < 1f)
                    scale = 1f;
                clicked = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, new Vector2(position.X, position.Y), new Color((int)(52 * scale), (int)(73 * scale), (int)(94 * scale)), 0, 
                new Vector2(font.MeasureString(text).X/2, font.MeasureString(text).Y/2), scale, SpriteEffects.None, 1);
        }
    }
}
