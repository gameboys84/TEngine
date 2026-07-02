using System.Collections.Generic;
using UnityEngine;

namespace TEngine
{
    /// <summary>
    /// 默认本地化辅助器。
    /// </summary>
    public class LocalizationUtility
    {
#if UNITY_EDITOR
        public const string I2GlobalSourcesEditorPath = "Assets/Editor/I2Localization/I2Languages.asset";
#endif

        public const string I2ResAssetNamePrefix = "I2_";

        /// <summary>
        /// 获取系统语言。
        /// </summary>
        public static Language SystemLanguage
        {
            get
            {
                switch (Application.systemLanguage)
                {
                    case UnityEngine.SystemLanguage.Afrikaans: return Language.Afrikaans;
                    case UnityEngine.SystemLanguage.Arabic: return Language.Arabic;
                    case UnityEngine.SystemLanguage.Basque: return Language.Basque;
                    case UnityEngine.SystemLanguage.Belarusian: return Language.Belarusian;
                    case UnityEngine.SystemLanguage.Bulgarian: return Language.Bulgarian;
                    case UnityEngine.SystemLanguage.Catalan: return Language.Catalan;
                    case UnityEngine.SystemLanguage.Chinese: return Language.ChineseSimplified;
                    case UnityEngine.SystemLanguage.ChineseSimplified: return Language.ChineseSimplified;
                    case UnityEngine.SystemLanguage.ChineseTraditional: return Language.ChineseTraditional;
                    case UnityEngine.SystemLanguage.Czech: return Language.Czech;
                    case UnityEngine.SystemLanguage.Danish: return Language.Danish;
                    case UnityEngine.SystemLanguage.Dutch: return Language.Dutch;
                    case UnityEngine.SystemLanguage.English: return Language.English;
                    case UnityEngine.SystemLanguage.Estonian: return Language.Estonian;
                    case UnityEngine.SystemLanguage.Faroese: return Language.Faroese;
                    case UnityEngine.SystemLanguage.Finnish: return Language.Finnish;
                    case UnityEngine.SystemLanguage.French: return Language.French;
                    case UnityEngine.SystemLanguage.German: return Language.German;
                    case UnityEngine.SystemLanguage.Greek: return Language.Greek;
                    case UnityEngine.SystemLanguage.Hebrew: return Language.Hebrew;
                    case UnityEngine.SystemLanguage.Hungarian: return Language.Hungarian;
                    case UnityEngine.SystemLanguage.Icelandic: return Language.Icelandic;
                    case UnityEngine.SystemLanguage.Indonesian: return Language.Indonesian;
                    case UnityEngine.SystemLanguage.Italian: return Language.Italian;
                    case UnityEngine.SystemLanguage.Japanese: return Language.Japanese;
                    case UnityEngine.SystemLanguage.Korean: return Language.Korean;
                    case UnityEngine.SystemLanguage.Latvian: return Language.Latvian;
                    case UnityEngine.SystemLanguage.Lithuanian: return Language.Lithuanian;
                    case UnityEngine.SystemLanguage.Norwegian: return Language.Norwegian;
                    case UnityEngine.SystemLanguage.Polish: return Language.Polish;
                    case UnityEngine.SystemLanguage.Portuguese: return Language.PortuguesePortugal;
                    case UnityEngine.SystemLanguage.Romanian: return Language.Romanian;
                    case UnityEngine.SystemLanguage.Russian: return Language.Russian;
                    case UnityEngine.SystemLanguage.SerboCroatian: return Language.SerboCroatian;
                    case UnityEngine.SystemLanguage.Slovak: return Language.Slovak;
                    case UnityEngine.SystemLanguage.Slovenian: return Language.Slovenian;
                    case UnityEngine.SystemLanguage.Spanish: return Language.Spanish;
                    case UnityEngine.SystemLanguage.Swedish: return Language.Swedish;
                    case UnityEngine.SystemLanguage.Thai: return Language.Thai;
                    case UnityEngine.SystemLanguage.Turkish: return Language.Turkish;
                    case UnityEngine.SystemLanguage.Ukrainian: return Language.Ukrainian;
                    case UnityEngine.SystemLanguage.Unknown: return Language.Unspecified;
                    case UnityEngine.SystemLanguage.Vietnamese: return Language.Vietnamese;
                    default: return Language.Unspecified;
                }
            }
        }

        public static Language LocLanguage2Language(LocLanguage locLanguage)
        {
            switch (locLanguage)
            {
                case LocLanguage.en: return Language.English;
                case LocLanguage.cn: return Language.ChineseSimplified;
                case LocLanguage.zh: return Language.ChineseTraditional;
                case LocLanguage.kr: return Language.Korean;
                case LocLanguage.jp: return Language.Japanese;
                case LocLanguage.fr: return Language.French;
                case LocLanguage.de: return Language.German;
                case LocLanguage.ru: return Language.Russian;
                case LocLanguage.sp: return Language.Spanish;
                case LocLanguage.po: return Language.PortuguesePortugal;
                case LocLanguage.it: return Language.Italian;
                case LocLanguage.nl: return Language.Dutch;
                case LocLanguage.tr: return Language.Turkish;
                case LocLanguage.id: return Language.Indonesian;
                case LocLanguage.pls: return Language.Polish;
                case LocLanguage.thai: return Language.Thai;
                case LocLanguage.ro: return Language.Romanian;
                case LocLanguage.ar: return Language.Arabic;
                case LocLanguage.vi: return Language.Vietnamese;
                case LocLanguage.uk: return Language.Ukrainian;
                default: return Language.Unspecified;
            }
        }
        public static LocLanguage Language2LocLanguage(Language language)
        {
            switch (language)
            {
                case Language.English: return LocLanguage.en;
                case Language.ChineseSimplified: return LocLanguage.cn;
                case Language.ChineseTraditional: return LocLanguage.zh;
                case Language.Korean: return LocLanguage.kr;
                case Language.Japanese: return LocLanguage.jp;
                case Language.French: return LocLanguage.fr;
                case Language.German: return LocLanguage.de;
                case Language.Russian: return LocLanguage.ru;
                case Language.Spanish: return LocLanguage.sp;
                case Language.PortuguesePortugal: return LocLanguage.po;
                case Language.Italian: return LocLanguage.it;
                case Language.Dutch: return LocLanguage.nl;
                case Language.Turkish: return LocLanguage.tr;
                case Language.Indonesian: return LocLanguage.id;
                case Language.Polish: return LocLanguage.pls;
                case Language.Thai: return LocLanguage.thai;
                case Language.Romanian: return LocLanguage.ro;
                case Language.Arabic: return LocLanguage.ar;
                case Language.Vietnamese: return LocLanguage.vi;
                case Language.Ukrainian: return LocLanguage.uk;
                default: return LocLanguage.en;
            }
        }

        private static readonly Dictionary<Language, string> _languageMap = new Dictionary<Language, string>();
        private static readonly Dictionary<string, Language> _languageStrMap = new Dictionary<string, Language>();

        static LocalizationUtility()
        {
            for (var i = 0; i < (int)LocLanguage.Count; i++)
            {
                var locLanguage = (LocLanguage)i;
                var language = LocLanguage2Language(locLanguage);
                RegisterLanguageMap(language, locLanguage.ToString());
            }
        }

        private static void RegisterLanguageMap(Language language, string str = "")
        {
            if (string.IsNullOrEmpty(str))
            {
                str = language.ToString();
            }

            _languageMap[language] = str;
            _languageStrMap[str] = language;
        }

        /// <summary>
        /// 根据语言字符串获取语言枚举。
        /// </summary>
        /// <param name="str">语言字符串。</param>
        /// <returns>语言枚举。</returns>
        public static Language GetLanguage(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return Language.Unspecified;
            }

            if (_languageStrMap.TryGetValue(str, out var language))
            {
                return language;
            }

            language = Language.English;
            return language;
        }

        /// <summary>
        /// 根据语言枚举获取语言字符串。
        /// </summary>
        /// <param name="language">语言枚举。</param>
        /// <returns>语言字符串。</returns>
        public static string GetLanguageStr(Language language)
        {
            if (_languageMap.TryGetValue(language, out var ret))
            {
                return ret;
            }

            ret = "English";
            return ret;
        }
    }
}