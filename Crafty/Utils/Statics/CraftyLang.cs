using System.Collections.Generic;

namespace Crafty.Utils.Statics
{
    public static class CraftyLang
    {
        private static Dictionary<string, string[]> lDic = new Dictionary<string, string[]>()
        {
            // GUI
            {"singleplayer", new string[]{"Singleplayer", "Solo"}},
            {"multiplayer", new string[]{"Multiplayer", "Multijoueur"}},
            {"settings", new string[]{"Settings", "Paramètres"}},
            {"quit", new string[]{"Quit", "Quitter"}},
            {"back", new string[]{"Back", "Retour"}},
            {"yes", new string[]{"Yes", "Oui"}},
            {"no", new string[]{"No", "Non"}},
            {"fullscreen", new string[]{"Fullscreen", "Plein écran"}},
            {"antialiasing", new string[]{"Anti-Aliasing","Anticrénelage"}},

            // BLOCK
            {"block_dirt", new string[]{"Dirt bloc", "Bloc de terre"}}
        };

        /// <summary>
        /// Get data from dictionnary
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>String value</returns>
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

        /// <summary>
        /// Set the current language
        /// </summary>
        /// <param name="langIndex">Language index</param>
        public static void SetLanguage(int langIndex)
        {
            if (langIndex >= 0 && langIndex <= 1)
                CraftyConfig.Language = langIndex;
            else
                CraftyConfig.Language = 0;
        }

    }
}
