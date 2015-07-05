using Crafty.Content;
using Crafty.Screens;
using Crafty.GUI.Controls;
using Crafty.Utils.Statics;
using Microsoft.Xna.Framework;

namespace Crafty.GUI
{
    public class MainGUI : GUI
    {
        private TextButton SingleplayerButton, MultiplayerButton, SettingsButton, ExitButton;
        //private ColoredBackground ColoredBackground;
        private ImageBackground Background;
        private Cursor Cursor;
        private RotateLabel Title;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainGUI()
        {
            SingleplayerButton = new TextButton(CraftyLang.GetData("singleplayer"), new Point(-1,400));
            SingleplayerButton.OnClick += SingleplayerButton_OnClick;
            MultiplayerButton = new TextButton(CraftyLang.GetData("multiplayer"), new Point(-1, 500));
            SettingsButton = new TextButton(CraftyLang.GetData("settings"), new Point(-1, 600));
            SettingsButton.OnClick += SettingsButton_OnClick;
            ExitButton = new TextButton(CraftyLang.GetData("quit"), new Point(-1, 700));
            ExitButton.OnClick += ExitButton_OnClick;
            //ColoredBackground = new ColoredBackground(new Color(127, 140, 141));
            Background = new ImageBackground(CraftyContent.GetTexture("background"));
            Cursor = new Cursor("cursor");
            Title = new RotateLabel(CraftySettings.Name, new Point(-1, 150), new Color(243, 156, 18), CraftyContent.GetFont("gdc128"));
        }

        /// <summary>
        /// Singleplayer button clicked
        /// </summary>
        void SingleplayerButton_OnClick()
        {
            ScreenManager.SetScreen(new GameScreen("world1"));
        }

        /// <summary>
        /// Settings button clicked
        /// </summary>
        void SettingsButton_OnClick()
        {
            GUIManager.SetGUI(new MainSettingsGUI());
        }

        /// <summary>
        /// Exit button clicked
        /// </summary>
        void ExitButton_OnClick()
        {
            CraftySettings.Game.Exit();
        }

        /// <summary>
        /// Init
        /// </summary>
        public override void Init()
        {
            //Controls.Add(ColoredBackground);
            Controls.Add(Background);
            Controls.Add(SingleplayerButton);
            Controls.Add(MultiplayerButton);
            Controls.Add(SettingsButton);
            Controls.Add(ExitButton);
            Controls.Add(Title);
            Controls.Add(Cursor);
        }
        

    }
}
