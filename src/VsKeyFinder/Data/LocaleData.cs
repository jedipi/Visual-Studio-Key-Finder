using System.Collections.Generic;

namespace VsKeyFinder.Data
{
    internal static class LocaleData
    {
        internal static List<Locale> GetLocales()
        {
            var Locales = new List<Locale>()
            {
                new Locale()
                {
                    Name = "English",
                    Code = "en"
                },
                new Locale()
                {
                    Name = "简体中文",
                    Code = "zh-CN"
                },
                new Locale()
                {
                    Name = "繁體中文",
                    Code = "zh-Hant"
                }
            };

            return Locales;
        }
    }
}
