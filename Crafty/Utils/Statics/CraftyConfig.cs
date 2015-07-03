using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crafty.Utils.Statics
{
    /// <summary>
    /// Static class for configuration
    /// </summary>
    public static class CraftyConfig
    {
        public static int Language { get; set; }
        public static Matrix Scale { get; set; }
        public static Vector2 Resolution { get; set; }
        public static bool Fullscreen { get; set; }

        /// <summary>
        /// Load config file
        /// </summary>
        public static void Load()
        {
            if (!File.Exists(CraftySettings.ConfigFile))
                CreateConfig();

            using (StreamReader sr = new StreamReader(CraftySettings.ConfigFile))
            {
                string line, name, value;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.StartsWith("//"))
                    {
                        try
                        {
                            name = line.Split('=')[0];
                            value = line.Split('=')[1];
                        }
                        catch (Exception ex) { throw ex; }
                        switch (name)
                        {
                            case "language":
                                Language = Convert.ToInt32(value);
                                CraftyLang.SetLanguage(Language);
                                break;
                            case "resolution":
                                int width = Convert.ToInt32(value.Split(';')[0]);
                                int height = Convert.ToInt32(value.Split(';')[1]);
                                Resolution = new Vector2(width, height);
                                Vector2 actualScreen = new Vector2(width, height);
                                float widthScale = (float)actualScreen.X / CraftySettings.VirtualScreen.X;
                                float heightScale = (float)actualScreen.Y / CraftySettings.VirtualScreen.Y;
                                Vector3 ScalingFactor = new Vector3(widthScale, heightScale, 1);
                                Scale = Matrix.CreateScale(ScalingFactor);
                                break;
                            case "fullscreen":
                                bool fs = Convert.ToBoolean(value);
                                Fullscreen = fs;
                                break;
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Save config file
        /// </summary>
        public static void SaveConfig()
        {
            using (StreamWriter sw = new StreamWriter(CraftySettings.ConfigFile))
            {
                sw.WriteLine("//Crafty Settings");
                sw.WriteLine("language=" + Language);
                sw.WriteLine("resolution=" + Resolution.X + ";" + Resolution.Y);
                sw.WriteLine("fullscreen=" + Fullscreen.ToString());
            }
        }

        /// <summary>
        /// Create default config file
        /// </summary>
        private static void CreateConfig()
        {
            using (StreamWriter sw = new StreamWriter(CraftySettings.ConfigFile))
            {
                sw.WriteLine("//Crafty Settings");
                sw.WriteLine("language=0");
                sw.WriteLine("resolution=800;600");
                sw.WriteLine("fullscreen=true");
            }
        }


    }
}
