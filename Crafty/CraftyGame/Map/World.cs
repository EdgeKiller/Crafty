using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crafty.CraftyGame.Map
{
    public class World
    {
        private Tile[,] Tiles = new Tile[500,100];

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="worldName">World name</param>
        public World(string worldName)
        {

        }

        /// <summary>
        /// Load all information
        /// </summary>
        private void Load()
        {
            
        }

        /// <summary>
        /// Update the world
        /// </summary>
        /// <param name="gameTime">Gametime</param>
        public void Update(GameTime gameTime)
        {
            for (int x = 0; x < Tiles.GetLength(0); x++)
            {
                for (int y = 0; y < Tiles.GetLength(1); y++)
                {
                    Tiles[x, y].Update(gameTime);
                }
            }
        }

        /// <summary>
        /// Draw the world
        /// </summary>
        /// <param name="spriteBatch">Spritebatch</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < Tiles.GetLength(0); x++)
            {
                for (int y = 0; y < Tiles.GetLength(1); y++)
                {
                    Tiles[x, y].Draw(spriteBatch);
                }
            }
        }
    }
}
