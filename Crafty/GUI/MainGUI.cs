using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crafty.GUI.Controls;
using Microsoft.Xna.Framework;
using Crafty.Utils.Statics;

namespace Crafty.GUI
{
    public class MainGUI : GUI
    {
        private TextButton SingleplayerButton, MultiplayerButton, SettingsButton, ExitButton;
        private Background Background;

        public MainGUI()
        {
            SingleplayerButton = new TextButton(CraftyLang.GetData("singleplayer"), new Point(-1,400));
            MultiplayerButton = new TextButton(CraftyLang.GetData("multiplayer"), new Point(-1, 500));
            SettingsButton = new TextButton(CraftyLang.GetData("settings"), new Point(-1, 600));
            ExitButton = new TextButton(CraftyLang.GetData("quit"), new Point(-1, 700));
            ExitButton.OnClick += ExitButton_OnClick;
            Background = new Background(new Color(127, 140, 141));
        }

        void ExitButton_OnClick()
        {
            CraftySettings.Game.Exit();
        }

        public override void Init()
        {
            Controls.Add(Background);
            Controls.Add(SingleplayerButton);
            Controls.Add(MultiplayerButton);
            Controls.Add(SettingsButton);
            Controls.Add(ExitButton);
        }
        

    }
}
