using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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
        public static bool AntiAlisaing { get; set; }
        public static bool VSync { get; set; }

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
                                Fullscreen = Convert.ToBoolean(value);
                                break;
                            case "antialiasing":
                                AntiAlisaing = Convert.ToBoolean(value);
                                break;
                            case "vsync":
                                VSync = Convert.ToBoolean(value);
                                break;
                            case "key_up":
                                CraftyControl.UpKey = CraftyConverter.StringToKeys(value);
                                break;
                            case "key_down":
                                CraftyControl.DownKey = CraftyConverter.StringToKeys(value);
                                break;
                            case "key_left":
                                CraftyControl.LeftKey = CraftyConverter.StringToKeys(value);
                                break;
                            case "key_right":
                                CraftyControl.RightKey = CraftyConverter.StringToKeys(value);
                                break;
                            case "key_jump":
                                CraftyControl.JumpKey = CraftyConverter.StringToKeys(value);
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
                sw.WriteLine("fullscreen=" + Fullscreen.ToString().ToLower());
                sw.WriteLine("antialiasing=" + AntiAlisaing.ToString().ToLower());
                sw.WriteLine("vsync=" + VSync.ToString().ToLower());
                sw.WriteLine("key_up=" + CraftyControl.UpKey.ToString());
                sw.WriteLine("key_down=" + CraftyControl.DownKey.ToString());
                sw.WriteLine("key_left=" + CraftyControl.LeftKey.ToString());
                sw.WriteLine("key_right=" + CraftyControl.RightKey.ToString());
                sw.WriteLine("key_jump=" + CraftyControl.JumpKey.ToString());
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
                sw.WriteLine("antialiasing=true");
                sw.WriteLine("vsync=true");
                sw.WriteLine("key_up=W");
                sw.WriteLine("key_down=S");
                sw.WriteLine("key_left=A");
                sw.WriteLine("key_right=D");
                sw.WriteLine("key_jump=Space");
            }
        }


    }

    public static class CraftyControl
    {
        public static Keys UpKey { get; set; }
        public static Keys DownKey { get; set; }
        public static Keys LeftKey { get; set; }
        public static Keys RightKey { get; set; }
        public static Keys JumpKey { get; set; }
    }
}
