using GameConfig;
using GameCore;
using TEngine;

namespace GameLogic
{
    public class StringManager : Singleton<StringManager> 
    {
        private Language language = Language.Unspecified;
        private LocLanguage locLanguage;
        private TbLocConfig tbLocConfig;
        private readonly string IDError = "lc_error:";

        protected override void OnInit()
        {
            language = GameModule.Localization.Language;
            locLanguage = LocalizationUtility.Language2LocLanguage(language);
            tbLocConfig = ConfigSystem.Instance.Tables.TbLocConfig;
            
            // TEngine.Localization.LocalizationManager.OnLocalizeEvent += OnLocalizationChanged;
            GameEvent.AddEventListener(EngineEvent.Event_OnLocalizationChanged, OnLocalizationChanged);
        }

        protected override void OnRelease()
        {
            // TEngine.Localization.LocalizationManager.OnLocalizeEvent -= OnLocalizationChanged;
            GameEvent.RemoveEventListener(EngineEvent.Event_OnLocalizationChanged, OnLocalizationChanged);
        }
        
        public LocConfig GetTextConfig(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                Log.Warning("Key is null or empty");
                return null;
            }
            return tbLocConfig.GetOrDefault(key);
        }

        /// <summary>
        /// 通过配置的excel文件读取文本
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetText(string key)
        {
            var locConfig = GetTextConfig(key);
            if (locConfig == null)
            {
                Log.Error($"LocConfig not found for key: {key}");
                return $"{IDError}{key}";
            }

            return locConfig.Content[(int)locLanguage];
        }
        
        public string GetText(string key, params object[] args)
        {
            var locConfig = GetTextConfig(key);
            if (locConfig == null)
            {
                Log.Error($"LocConfig not found for key: {key}");
                return $"{IDError}{key}";
            }

            return Utility.Text.Format(locConfig.Content[(int)locLanguage], args);
        }

        public static string LocFormat(string value, params object[] args)
        {
            if (string.IsNullOrEmpty(value))
            {
                Log.Warning("Value is null or empty");
                return value;
            }
            return Utility.Text.Format(value, args);
        }
        
        private void OnLocalizationChanged()
        {
            var curLanguage = GameModule.Localization.Language;
            if (language != curLanguage)
            {
                Log.Debug($"StringManager: OnLocalizationChanged: {language} -> {curLanguage}");
                language = curLanguage;
                locLanguage = LocalizationUtility.Language2LocLanguage(curLanguage);
                
                var languageName = LocalizationUtility.GetLanguageStr(language);
                if (GameModule.Localization.CheckLanguage(languageName))
                {
                    Utility.PlayerPrefs.SetString(Constant.Setting.Language, languageName);
                    Utility.PlayerPrefs.Save();
                    Log.Info($"StringManager: Language Saved: {languageName}");
                }
                else
                {
                    Log.Error($"StringManager: Language Not Found: {languageName}");
                }
                
                GameEvent.Get<ILocalizationChanged>()?.OnLocalizationChanged();
            }
            else
            {
                Log.Debug($"StringManager: OnLocalizationChanged: {language}");
            }
        }
    }
}