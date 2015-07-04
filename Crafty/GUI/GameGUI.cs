using Crafty.GUI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crafty.GUI
{
    public class GameGUI : GUI
    {
        Cursor Cursor;

        /// <summary>
        /// Constructor
        /// </summary>
        public GameGUI()
        {
            Cursor = new Cursor("cursor");
        }

        /// <summary>
        /// Init
        /// </summary>
        public override void Init()
        {
            Controls.Add(Cursor);
        }
    }
}
