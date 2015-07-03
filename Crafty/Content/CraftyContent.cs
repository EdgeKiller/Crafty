using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Crafty.Utils.Statics;

namespace Crafty.Content
{
    public static class CraftyContent
    {

        private static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        /// <summary>
        /// Load all resources from resources folder
        /// </summary>
        /// <param name="device">GraphicsDevice</param>
        public static void Load(GraphicsDevice device)
        {
            if (!Directory.Exists(CraftySettings.TextureFolder.FullName))
                throw new DirectoryNotFoundException("Textures folder missing.");

            foreach (FileInfo file in CraftySettings.TextureFolder.GetFiles("*.png"))
            {
                Console.WriteLine(file.Name.Split('.')[0]);
                try
                {
                    using (FileStream fs = new FileStream(file.FullName, FileMode.Open))
                    {
                        if (!textures.ContainsKey(file.Name.Split('.')[0]))
                            textures.Add(file.Name.Split('.')[0], Texture2D.FromStream(device, fs));
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Get texture from dictionnary
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Texture2D</returns>
        public static Texture2D GetTexture(string key)
        {
            if (textures.ContainsKey(key))
                return textures[key];
            return null;
        }

    }
}
