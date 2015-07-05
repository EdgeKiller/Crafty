using Microsoft.Xna.Framework.Input;

namespace Crafty.Utils.Statics
{
    public static class CraftyConverter
    {
        public static Keys StringToKeys(string key)
        {
            switch (key)
            {
                #region Letters
                case "A":
                    return Keys.A;
                case "B":
                    return Keys.B;
                case "C":
                    return Keys.C;
                case "D":
                    return Keys.D;
                case "E":
                    return Keys.E;
                case "F":
                    return Keys.F;
                case "G":
                    return Keys.G;
                case "H":
                    return Keys.H;
                case "I":
                    return Keys.I;
                case "J":
                    return Keys.J;
                case "K":
                    return Keys.K;
                case "L":
                    return Keys.L;
                case "M":
                    return Keys.M;
                case "N":
                    return Keys.N;
                case "O":
                    return Keys.O;
                case "P":
                    return Keys.P;
                case "Q":
                    return Keys.Q;
                case "R":
                    return Keys.R;
                case "S":
                    return Keys.S;
                case "T":
                    return Keys.T;
                case "U":
                    return Keys.U;
                case "V":
                    return Keys.V;
                case "W":
                    return Keys.W;
                case "X":
                    return Keys.X;
                case "Y":
                    return Keys.Y;
                case "Z":
                    return Keys.Z;
                #endregion

                #region Numbers
                case "NumPad0":
                    return Keys.NumPad0;
                case "NumPad1":
                    return Keys.NumPad1;
                case "NumPad2":
                    return Keys.NumPad2;
                case "NumPad3":
                    return Keys.NumPad3;
                case "NumPad4":
                    return Keys.NumPad4;
                case "NumPad5":
                    return Keys.NumPad5;
                case "NumPad6":
                    return Keys.NumPad6;
                case "NumPad7":
                    return Keys.NumPad7;
                case "NumPad8":
                    return Keys.NumPad8;
                case "NumPad9":
                    return Keys.NumPad9;
                case "D0":
                    return Keys.D0;
                case "D1":
                    return Keys.D1;
                case "D2":
                    return Keys.D2;
                case "D3":
                    return Keys.D3;
                case "D4":
                    return Keys.D4;
                case "D5":
                    return Keys.D5;
                case "D6":
                    return Keys.D6;
                case "D7":
                    return Keys.D7;
                case "D8":
                    return Keys.D8;
                case "D9":
                    return Keys.D9;
                #endregion

                #region Others
                case "Escape":
                    return Keys.Escape;
                case "Space":
                    return Keys.Space;
                case "Up":
                    return Keys.Up;
                case "Down":
                    return Keys.Down;
                case "Left":
                    return Keys.Left;
                case "Right":
                    return Keys.Right;
                case "LeftShift":
                    return Keys.LeftShift;
                case "RightShift":
                    return Keys.RightShift;
                #endregion

                default:
                    return Keys.Escape;
            }
        }

    }
}
