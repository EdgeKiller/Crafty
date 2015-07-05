using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crafty.Utils.Statics;
using Crafty.Content;

namespace Crafty.CraftyGame.Map
{
    public class Tile
    {
        public int ID {get;set;}
        public int Life { get; set; }
        public string Name { get; set; }
        public Texture2D Texture { get; set; }
        public bool Collide { get; set; }
        public Rectangle Hitbox { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ID">Tile ID</param>
        public Tile(int ID, Point position)
        {
            this.ID = ID;
            Hitbox = new Rectangle(position.X * CraftySettings.TileSize, position.Y * CraftySettings.TileSize,
                CraftySettings.TileSize, CraftySettings.TileSize);
            Load();
        }

        /// <summary>
        /// Load all information
        /// </summary>
        private void Load()
        {
            switch (ID)
            {
                case 0:
                    Life = 0;
                    Collide = false;
                    break;
                case 1:
                    Name = CraftyLang.GetData("block_dirt");
                    Life = 50;
                    Texture = CraftyContent.GetTexture("block_dirt");
                    Collide = true;
                    break;
                case 2:
                    Name = CraftyLang.GetData("block_grass");
                    Life = 50;
                    Texture = CraftyContent.GetTexture("block_grass");
                    Collide = true;
                    break;


            }
        }

        /// <summary>
        /// Update tile
        /// </summary>
        /// <param name="gameTime">Gametime</param>
        public void Update(GameTime gameTime)
        {
            if (Life <= 0 && ID != 0)
            {
                ID = 0;
                Load();
            }
        }

        /// <summary>
        /// Draw tile
        /// </summary>
        /// <param name="spriteBatch">Spritebatch</param>
        public void Draw(SpriteBatch spriteBatch, Point pos)
        {
            pos.X *= CraftySettings.TileSize;
            pos.Y *= CraftySettings.TileSize;
            pos.X -= Camera.Position.X;
            pos.Y -= Camera.Position.Y;
            if (ID != 0)
                spriteBatch.Draw(Texture, new Rectangle(pos.X, pos.Y, CraftySettings.TileSize, CraftySettings.TileSize), Color.White);
        }

    }
}
