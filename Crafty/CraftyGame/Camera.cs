using Crafty.Utils.Statics;
using Microsoft.Xna.Framework;

namespace Crafty.CraftyGame
{
    public static class Camera
    {
        public static Point Position;

        /// <summary>
        /// Set the position of the camera
        /// </summary>
        /// <param name="x">X as int</param>
        /// <param name="y">Y as int</param>
        public static void SetPosition(int x, int y)
        {
            Position = new Point(x - (CraftySettings.VirtualScreen.X / 2),
                y - (CraftySettings.VirtualScreen.Y / 2));
            if (Position.X < 0)
                Position.X = 0;
            if (Position.Y < 0)
                Position.Y = 0;
        }

        /// <summary>
        /// Translate the camera
        /// </summary>
        /// <param name="x">X as int</param>
        /// <param name="y">Y as int</param>
        public static void Translate(int x = 0, int y = 0)
        {
            Position += new Point(x, y);
            if (Position.X < 0)
                Position.X = 0;
            if (Position.Y < 0)
                Position.Y = 0;
        }

        /// <summary>
        /// Get Y position
        /// </summary>
        /// <returns>Y as int</returns>
        public static int GetX()
        {
            return Position.X;
        }

        /// <summary>
        /// Get X position
        /// </summary>
        /// <returns>X as int</returns>
        public static int GetY()
        {
            return Position.Y;
        }
    }
}
