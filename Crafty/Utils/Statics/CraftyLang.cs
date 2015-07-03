using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crafty.Utils.Statics
{
    public static class CraftyLang
    {
        private static Dictionary<string, string[]> lDic = new Dictionary<string, string[]>()
        {
            
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
