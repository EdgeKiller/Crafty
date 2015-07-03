using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace Crafty.Utils.Statics
{
    public static class CraftySettings
    {

        public static readonly string Name = "Crafty";
        public static readonly short Version = 0;
        public static readonly string Creator = "EdgeKiller";
        public static readonly string ConfigFile = "crafty.cfg";
        public static readonly DirectoryInfo TextureFolder = new DirectoryInfo("resources/textures");

        public static readonly Vector2 VirtualScreen = new Vector2(1920, 1080);
    }
}
