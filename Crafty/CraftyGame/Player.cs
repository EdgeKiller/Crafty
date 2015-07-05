using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Crafty.Content;
using Crafty.Utils.Statics;
using Crafty.CraftyGame.Map;

namespace Crafty.CraftyGame
{
    public class Player
    {
        public int ID { get { return id; } }
        private int id;

        public Point Position { get { return position; } }
        private Point position, oldPosition;

        public int Speed { get { return speed; } }
        private int speed;

        private Rectangle hitbox;

        bool CollideBottom = false;
        float Gravity = 2.0f;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ID">ID, only useful in multiplayer mode</param>
        public Player(int id)
        {
            position = new Point(0, 0);
            this.id = id;
            hitbox = new Rectangle(position.X, position.Y, CraftySettings.PlayerSize.X, CraftySettings.PlayerSize.Y);
            speed = 4;

        }

        /// <summary>
        /// Translate the player
        /// </summary>
        /// <param name="x">X as int</param>
        /// <param name="y">Y as int</param>
        public void Translate(int x = 0, int y = 0)
        {
            position += new Point(x, y);
            Camera.SetPosition(position.X - (CraftySettings.VirtualScreen.X / 2),
                position.Y - (CraftySettings.VirtualScreen.Y / 2));
            hitbox.X = position.X - Camera.Position.X;
            hitbox.Y = position.Y - Camera.Position.Y;
        }

        /// <summary>
        /// Verify position to manage collision
        /// </summary>
        public void VerifyPosition()
        {
            foreach(Tile t in GetBottomTiles())
            {
                if(t.ID != 0 && t.Collide)
                {
                    if (t.Hitbox.Intersects(hitbox))
                    {
                        position.Y = oldPosition.Y;
                        hitbox.Y = position.Y - Camera.Position.Y;
                    }
                }
            }
        }

        /// <summary>
        /// Update the player
        /// </summary>
        /// <param name="gameTime">Gametime</param>
        public void Update(GameTime gameTime)
        {
            oldPosition = position;

            if (KMState.KeyboardState.IsKeyDown(CraftyControl.UpKey))
            {
                //Translate(0, -Speed);
            }
            if (KMState.KeyboardState.IsKeyDown(CraftyControl.DownKey))
            {
                //Translate(0, Speed);
            }
            if (KMState.KeyboardState.IsKeyDown(CraftyControl.LeftKey))
            {
                Translate(-speed, 0);
            }
            if (KMState.KeyboardState.IsKeyDown(CraftyControl.RightKey))
            {
                Translate(speed, 0);
            }

            if (!CollideBottom)
            {
                if (Gravity <= 3.0f)
                    Gravity += 0.01f; ;
                Translate(0, (int)((Gravity * gameTime.ElapsedGameTime.Milliseconds) / 6));
            }
            else
            {
                Gravity = 2.0f;
            }

            VerifyPosition();
            

        }

        /// <summary>
        /// Draw the player
        /// </summary>
        /// <param name="spriteBatch">Spritebatch</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, CraftyConfig.Scale);

            spriteBatch.Draw(CraftyContent.GetTexture("pixel"), hitbox, Color.Red);

            spriteBatch.End();
        }


        private List<Tile> GetBottomTiles()
        {
            List<Tile> tiles = new List<Tile>();

            int bottomTileY = (int)((position.Y + CraftySettings.PlayerSize.Y) / CraftySettings.TileSize);
            int bottomTileX = (int)((position.X + CraftySettings.PlayerSize.X / 2) / CraftySettings.TileSize);

            tiles.Add(World.Tiles[bottomTileX, bottomTileY]);

            if(bottomTileX + 1 <= CraftySettings.WorldSize.X)
                tiles.Add(World.Tiles[bottomTileX + 1, bottomTileY]);

            if(bottomTileX - 1 >= 0)
                tiles.Add(World.Tiles[bottomTileX - 1, bottomTileY]);

            return tiles;
        }

    }
}
