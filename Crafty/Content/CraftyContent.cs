using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Crafty.Utils.Statics;
using Microsoft.Xna.Framework.Content;

namespace Crafty.Content
{
    public static class CraftyContent
    {

        private static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        private static Dictionary<string, SpriteFont> fonts = new Dictionary<string, SpriteFont>();

        /// <summary>
        /// Load all resources from resources folder
        /// </summary>
        /// <param name="device">GraphicsDevice</param>
        public static void Load(ContentManager content, GraphicsDevice device)
        {
            LoadAllTextures(device);
            LoadAllFonts(content);
        }


        /// <summary>
        /// Load all textures from textures folder
        /// </summary>
        /// <param name="device"></param>
        private static void LoadAllTextures(GraphicsDevice device)
        {
            if (!Directory.Exists(CraftySettings.TextureFolder.FullName))
                throw new DirectoryNotFoundException("Textures folder missing.");
            foreach (FileInfo file in CraftySettings.TextureFolder.GetFiles("*.png"))
            {
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
        /// Load all fonts from content folder
        /// </summary>
        /// <param name="content">ContentManager</param>
        private static void LoadAllFonts(ContentManager content)
        {
            if (!Directory.Exists(content.RootDirectory))
                throw new DirectoryNotFoundException("Content folder missing.");
            foreach (FileInfo file in new DirectoryInfo(content.RootDirectory).GetFiles("*.xnb"))
            {
                try
                {
                    if (!fonts.ContainsKey(file.Name.Split('.')[0]))
                        fonts.Add(file.Name.Split('.')[0], content.Load<SpriteFont>(file.Name.Split('.')[0]));
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

        /// <summary>
        /// Get font from dictionnary
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Spritefont</returns>
        public static SpriteFont GetFont(string key)
        {
            if (fonts.ContainsKey("font_" + key))
                return fonts["font_" + key];
            return null;
        }

    }
}
