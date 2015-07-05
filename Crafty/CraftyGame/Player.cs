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
        private Point position, futurPosition;

        public int Speed { get { return speed; } }
        private int speed;

        private Rectangle hitbox;

        bool collide = false;
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
            futurPosition += new Point(x, y);
            Camera.SetPosition(futurPosition.X, futurPosition.Y);
            hitbox.X = futurPosition.X - Camera.Position.X;
            hitbox.Y = futurPosition.Y - Camera.Position.Y;
        }

        /// <summary>
        /// Verify position to manage collision
        /// </summary>
        public void VerifyPosition()
        {
            collide = false;
            foreach (Tile t in GetNearTiles())
            {
                if (t.ID != 0 && t.Collide)
                {
                    if (t.Hitbox.Intersects(hitbox))
                    {
                        collide = true;
                        Gravity = 2.0f;
                        break;
                    }
                }
            }

            if (!collide)
                position = futurPosition;

            Camera.SetPosition(position.X, position.Y);
            hitbox.X = position.X - Camera.Position.X;
            hitbox.Y = position.Y - Camera.Position.Y;

        }

        /// <summary>
        /// Update the player
        /// </summary>
        /// <param name="gameTime">Gametime</param>
        public void Update(GameTime gameTime)
        {
            futurPosition = position;

            if (KMState.KeyboardState.IsKeyDown(CraftyControl.LeftKey))
            {
                Translate(-speed, 0);
            }
            if (KMState.KeyboardState.IsKeyDown(CraftyControl.RightKey))
            {
                Translate(speed, 0);
            }

            if (Gravity <= 3.0f)
                Gravity += 0.01f;
            Translate(0, (int)((Gravity * gameTime.ElapsedGameTime.Milliseconds) / 6));

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


        private List<Tile> GetNearTiles()
        {
            List<Tile> tiles = new List<Tile>();

            int bottomTileY = (int)((position.Y) / CraftySettings.TileSize);
            int bottomTileX = (int)((position.X) / CraftySettings.TileSize);

            tiles.Add(World.Tiles[bottomTileX, bottomTileY]);

            //Left tile column
            if (bottomTileX - 1 >= 0)
            {
                tiles.Add(World.Tiles[bottomTileX - 1, bottomTileY]);
                if (bottomTileY - 1 >= 0)
                    tiles.Add(World.Tiles[bottomTileX - 1, bottomTileY - 1]);
                if (bottomTileY + 1 >= 0)
                    tiles.Add(World.Tiles[bottomTileX - 1, bottomTileY + 1]);
                if (bottomTileY + 2 >= 0)
                    tiles.Add(World.Tiles[bottomTileX - 1, bottomTileY + 2]);
            }

            //Right tile column
            if (bottomTileX + 1 <= CraftySettings.WorldSize.X)
            {
                tiles.Add(World.Tiles[bottomTileX + 1, bottomTileY]);
                if (bottomTileY - 1 >= 0)
                    tiles.Add(World.Tiles[bottomTileX + 1, bottomTileY - 1]);
                if (bottomTileY + 1 >= 0)
                    tiles.Add(World.Tiles[bottomTileX + 1, bottomTileY + 1]);
                if (bottomTileY + 2 >= 0)
                    tiles.Add(World.Tiles[bottomTileX + 1, bottomTileY + 2]);
            }

            //Center tile column
            if (bottomTileY - 1 >= 0)
                tiles.Add(World.Tiles[bottomTileX, bottomTileY - 1]);
            if (bottomTileY + 2 >= 0)
                tiles.Add(World.Tiles[bottomTileX, bottomTileY + 2]);

            return tiles;
        }

    }
}
