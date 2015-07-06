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

        private Vector2 Position, Velocity;
        private Rectangle Hitbox;

        private bool HasJumped;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ID">ID, only useful in multiplayer mode</param>
        public Player(int id, Vector2 pos)
        {
            this.id = id;
            Position = pos;
            Velocity = Vector2.Zero;
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, CraftySettings.PlayerSize.X, CraftySettings.PlayerSize.Y);
            HasJumped = true;
        }

        /// <summary>
        /// Update the player
        /// </summary>
        /// <param name="gameTime">Gametime</param>
        public void Update(GameTime gameTime)
        {
            HasJumped = true ;

            List<Tile> fTiles = GetNearTiles();

            foreach (Tile t in fTiles)
            {
                if ((Hitbox.Bottom + (int)Velocity.Y) >= t.Hitbox.Top && t.Collide 
                    && (Hitbox.Left <= t.Hitbox.Right) && (Hitbox.Right >= t.Hitbox.Left))
                {
                    Velocity.Y = t.Hitbox.Top - Hitbox.Bottom;
                    HasJumped = false;
                    break;
                }
            }

            Position += Velocity;
            Hitbox.X = (int)Position.X;
            Hitbox.Y = (int)Position.Y;

            if (KMState.KeyboardState.IsKeyDown(CraftyControl.LeftKey))
            {
                Velocity.X = -3f;
            }
            else if (KMState.KeyboardState.IsKeyDown(CraftyControl.RightKey))
            {
                Velocity.X = 3f;
            }
            else
            {
                Velocity.X = 0f;
            }

            if(KMState.KeyboardState.IsKeyDown(CraftyControl.JumpKey) && !HasJumped)
            {
                Position.Y -= 10f;
                Velocity.Y = -15f;
                HasJumped = true;
            }

            Velocity.Y += 0.25f;

        }

        /// <summary>
        /// Draw the player
        /// </summary>
        /// <param name="spriteBatch">Spritebatch</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, CraftyConfig.Scale);

            spriteBatch.Draw(CraftyContent.GetTexture("pixel"), Hitbox, Color.Red);

            spriteBatch.End();
        }

        private List<Tile> GetNearTiles()
        {
            List<Tile> tiles = new List<Tile>();

            int bottomTileY = (int)((Position.Y) / CraftySettings.TileSize);
            int bottomTileX = (int)((Position.X) / CraftySettings.TileSize);

            if (bottomTileY >= 0)
            {

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
                    if (bottomTileY + 3 >= 0)
                        tiles.Add(World.Tiles[bottomTileX - 1, bottomTileY + 3]);
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
                    if (bottomTileY + 3 >= 0)
                        tiles.Add(World.Tiles[bottomTileX + 1, bottomTileY + 3]);
                }

                //Center tile column
                if (bottomTileY - 1 >= 0)
                    tiles.Add(World.Tiles[bottomTileX, bottomTileY - 1]);
                if (bottomTileY + 2 >= 0)
                    tiles.Add(World.Tiles[bottomTileX, bottomTileY + 2]);
                if (bottomTileY + 3 >= 0)
                    tiles.Add(World.Tiles[bottomTileX, bottomTileY + 3]);
            }
            return tiles;
        }

    }
}
