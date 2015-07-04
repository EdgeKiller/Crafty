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
        public int ID, Life;
        public string Name;
        public Texture2D Texture { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ID">Tile ID</param>
        public Tile(int ID)
        {
            this.ID = ID;
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
                    Name = CraftyLang.GetData("block_dirt");
                    Life = 50;
                    Texture = CraftyContent.GetTexture("block_dirt");
                    break;


            }
        }

        /// <summary>
        /// Update tile
        /// </summary>
        /// <param name="gameTime">Gametime</param>
        public void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Draw tile
        /// </summary>
        /// <param name="spriteBatch">Spritebatch</param>
        public void Draw(SpriteBatch spriteBatch)
        {

        }

    }
}
