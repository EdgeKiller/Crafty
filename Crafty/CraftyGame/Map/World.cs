using Crafty.Utils.Statics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Crafty.CraftyGame.Map
{
    public static class World
    {
        public static Tile[,] Tiles = new Tile[CraftySettings.WorldSize.X, CraftySettings.WorldSize.Y];

        public static string Name { get; set; }

        /// <summary>
        /// Create new world
        /// </summary>
        /// <param name="worldName">World's name</param>
        /// <param name="seed">Seed</param>
        public static void Create(string worldName, int seed = -1)
        {
            if (!Directory.Exists("world/" + worldName))
                Directory.CreateDirectory("world/" + worldName);
            if (seed == -1)
            {
                Random rand = new Random();
                seed = rand.Next(0, 147483647);
            }

            Generate(worldName, seed);
        }

        /// <summary>
        /// Generate a random map with perlin noise
        /// </summary>
        /// <param name="worldName">World's name</param>
        /// <param name="seed">Seed</param>
        private static void Generate(string worldName, int seed)
        {
            for (int x = 0; x < Tiles.GetLength(0); x++)
            {
                for (int y = 0; y < Tiles.GetLength(1); y++)
                {
                    Tiles[x, y] = new Tile(0, new Point(x,y));
                }
            }

            Tiles[0, 5] = new Tile(2, new Point(0, 5));
            Tiles[1, 5] = new Tile(2, new Point(1,5));

            Save(worldName);
        }

        /// <summary>
        /// Save the world as .cw file
        /// </summary>
        /// <param name="worldName">World's name</param>
        public static void Save(string worldName)
        {
            byte[] buffer = new byte[CraftySettings.WorldSize.X * CraftySettings.WorldSize.Y];

            for (int y = 0; y < Tiles.GetLength(1); y++)
            {
                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    using (BinaryWriter bw = new BinaryWriter(ms))
                    {
                        for (int x = 0; x < Tiles.GetLength(0); x++)
                        {
                            bw.Write(Tiles[x, y].ID);
                        }
                    }
                }
            }
            try
            {
                File.WriteAllBytes("world/" + worldName + "/" + worldName + ".cw", buffer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Load all information
        /// </summary>
        public static void Load(string worldName)
        {
            // Load all tiles
            byte[] buffer;
            try
            {
                buffer = File.ReadAllBytes("world/" + worldName + "/" + worldName + ".cw");
            }
            catch(Exception ex)
            {
                throw ex;
            }
            for (int y = 0; y < Tiles.GetLength(1); y++)
            {
                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    using (BinaryReader br = new BinaryReader(ms))
                    {
                        for (int x = 0; x < Tiles.GetLength(0); x++)
                        {
                            Tiles[x, y] = new Tile(br.ReadInt32(), new Point(x, y));
                        }
                    }
                }
            }

            // Init variables
            Camera.SetPosition(0, 0);
        }

        private static int minX, minY, maxX, maxY;

        /// <summary>
        /// Update the world
        /// </summary>
        /// <param name="gameTime">Gametime</param>
        public static void Update(GameTime gameTime)
        {
            minX = (Camera.Position.X / CraftySettings.TileSize) - 2;
            if (minX < 0)
                minX = 0;
            maxX = minX + 2 + (int)(CraftySettings.VirtualScreen.X / CraftySettings.TileSize) + 2;
            if (maxX > Tiles.GetLength(0))
                maxX = Tiles.GetLength(0);

            minY = (Camera.Position.Y / CraftySettings.TileSize) - 2;
            if (minY < 0)
                minY = 0;
            maxY = minY + 2 + (int)(CraftySettings.VirtualScreen.Y / CraftySettings.TileSize) + 2;
            if (maxY > Tiles.GetLength(1))
                maxY = Tiles.GetLength(1);

            for (int x = minX; x < maxX; x++)
            {
                for (int y = minY; y < maxY; y++)
                {
                    Tiles[x, y].Update(gameTime);
                }
            }
        }

        /// <summary>
        /// Draw the world
        /// </summary>
        /// <param name="spriteBatch">Spritebatch</param>
        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, CraftyConfig.Scale);
            for (int x = minX; x < maxX; x++)
            {
                for (int y = minY; y < maxY; y++)
                {
                    Tiles[x, y].Draw(spriteBatch, new Point(x, y));
                }
            }
            spriteBatch.End();
        }
    }
}
