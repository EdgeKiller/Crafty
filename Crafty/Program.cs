using System;

namespace Crafty
{
#if WINDOWS || LINUX
    /// <summary>
    /// Static class to launch the game
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the game
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new GameMain())
                game.Run();
        }
    }
#endif
}