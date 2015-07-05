using Microsoft.Xna.Framework;
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

        public static readonly int TileSize = 32;
        public static readonly Point WorldSize = new Point(1000, 300);
        public static readonly Point PlayerSize = new Point(32, 64);

        public static Game Game { get; set; }

        public static readonly Point VirtualScreen = new Point(1920, 1080);
    }
}
