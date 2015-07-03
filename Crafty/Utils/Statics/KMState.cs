using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Crafty.Utils.Statics
{
    public static class KMState
    {
        public static KeyboardState KeyboardState { get; set; }
        public static MouseState MouseState { get; set; }
        public static Rectangle MouseRec
        {
            get
            {
                return new Rectangle((int)(MouseState.X * (CraftySettings.VirtualScreen.X / CraftyConfig.Resolution.X))
                    , (int)(MouseState.Y * (CraftySettings.VirtualScreen.Y / CraftyConfig.Resolution.Y)), 1, 1);
            }
        }
        
        public static GamePadState GamePadState { get; set; }
    }
}
