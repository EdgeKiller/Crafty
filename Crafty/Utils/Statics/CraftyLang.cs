using System.Collections.Generic;

namespace Crafty.Utils.Statics
{
    public static class CraftyLang
    {
        private static Dictionary<string, string[]> lDic = new Dictionary<string, string[]>()
        {
            {"singleplayer", new string[]{"Singleplayer", "Solo"}},
            {"multiplayer", new string[]{"Multiplayer", "Multijoueur"}},
            {"settings", new string[]{"Settings", "Parametres"}},
            {"quit", new string[]{"Quit", "Quitter"}}
        };

        public static string GetData(string key)
        {
            if (lDic.ContainsKey(key))
            {
                try
                {
                    return lDic[key][CraftyConfig.Language];
                }
                catch { return null; }
            }
            else { return null; }
        }

        public static void SetLanguage(int langIndex)
        {
            if (langIndex >= 0 && langIndex <= 1)
            {
                CraftyConfig.Language = langIndex;
            }
            else
            {
                CraftyConfig.Language = 0;
            }
        }



    }
}
