using Crafty.Content;
using Crafty.GUI.Controls;
using Crafty.Utils.Statics;
using Microsoft.Xna.Framework;


namespace Crafty.GUI
{
    public class MainSettingsGUI : GUI
    {
        private TextButton ReturnButton, FullScreenButton, AntiAliasingbutton;
        private ColoredBackground ColoredBackground;
        private Cursor Cursor;
        private RotateLabel Title;

        public MainSettingsGUI()
        {
            FullScreenButton = new TextButton(CraftyLang.GetData("fullscreen") + " : " + CraftyLang.GetData(CraftyConfig.Fullscreen.ToYesNoString()), new Point(-1, 400));
            FullScreenButton.OnClick += FullscreenButton_OnClick;

            AntiAliasingbutton = new TextButton(CraftyLang.GetData("antialiasing") + " : " + CraftyLang.GetData(CraftyConfig.AntiAlisaing.ToYesNoString()), new Point(-1, 500));
            AntiAliasingbutton.OnClick += AntiAliasingbutton_OnClick;

            ReturnButton = new TextButton(CraftyLang.GetData("back"), new Point(-1, 700));
            ReturnButton.OnClick += ReturnButton_OnClick;
            ColoredBackground = new ColoredBackground(new Color(127, 140, 141));
            Cursor = new Cursor("cursor");
            Title = new RotateLabel(CraftySettings.Name, new Point(-1, 150), new Color(243, 156, 18), CraftyContent.GetFont("gdc128"));
        }

        void AntiAliasingbutton_OnClick()
        {
            if (CraftyConfig.AntiAlisaing)
                CraftyConfig.AntiAlisaing = false;
            else
                CraftyConfig.AntiAlisaing = true;
            AntiAliasingbutton.SetText(CraftyLang.GetData("antialiasing") + " : " + CraftyLang.GetData(CraftyConfig.AntiAlisaing.ToYesNoString()));
        }

        void FullscreenButton_OnClick()
        {
            if(CraftyConfig.Fullscreen)
                CraftyConfig.Fullscreen = false;
            else
                CraftyConfig.Fullscreen = true;
            FullScreenButton.SetText(CraftyLang.GetData("fullscreen") + " : " + CraftyLang.GetData(CraftyConfig.Fullscreen.ToYesNoString()));
        }

        void ReturnButton_OnClick()
        {
            CraftyConfig.SaveConfig();
            GUIManager.SetGUI(new MainGUI());
        }


        public override void Init()
        {
            Controls.Add(ColoredBackground);

            Controls.Add(FullScreenButton);
            Controls.Add(AntiAliasingbutton);
            Controls.Add(ReturnButton);

            Controls.Add(Title);
            Controls.Add(Cursor);
        }

    }
}
