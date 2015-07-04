using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crafty.GUI.Controls;
using Microsoft.Xna.Framework;
using Crafty.Utils.Statics;
using Crafty.Content;

namespace Crafty.GUI
{
    public class MainGUI : GUI
    {
        private TextButton SingleplayerButton, MultiplayerButton, SettingsButton, ExitButton;
        private ColoredBackground ColoredBackground;
        private Cursor Cursor;
        private RotateLabel Title;

        public MainGUI()
        {
            SingleplayerButton = new TextButton(CraftyLang.GetData("singleplayer"), new Point(-1,400));
            MultiplayerButton = new TextButton(CraftyLang.GetData("multiplayer"), new Point(-1, 500));
            SettingsButton = new TextButton(CraftyLang.GetData("settings"), new Point(-1, 600));
            ExitButton = new TextButton(CraftyLang.GetData("quit"), new Point(-1, 700));
            ExitButton.OnClick += ExitButton_OnClick;
            ColoredBackground = new ColoredBackground(new Color(127, 140, 141));
            Cursor = new Cursor("cursor");
            Title = new RotateLabel(CraftySettings.Name, new Point(-1, 150), new Color(243, 156, 18), CraftyContent.GetFont("kraash64"));
        }

        void ExitButton_OnClick()
        {
            CraftySettings.Game.Exit();
        }

        public override void Init()
        {
            Controls.Add(ColoredBackground);
            Controls.Add(SingleplayerButton);
            Controls.Add(MultiplayerButton);
            Controls.Add(SettingsButton);
            Controls.Add(ExitButton);
            Controls.Add(Title);
            Controls.Add(Cursor);
        }
        

    }
}
