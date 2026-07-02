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

            GameEvent.AddEventListener(EngineEvent.Event_OnLocalizationChanged, OnLocalizationChanged);
        }

        protected override void OnRelease()
        {
            GameEvent.RemoveEventListener(EngineEvent.Event_OnLocalizationChanged, OnLocalizationChanged);
        }
        
        public string GetText(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                Log.Warning("Key is null or empty");
                return string.Empty;
            }

            var locConfig = tbLocConfig.GetOrDefault(key);
            if (locConfig == null)
            {
                Log.Error($"LocConfig not found for key: {key}");
                return $"{IDError}{key}";
            }

            return locConfig.Content[(int)locLanguage];
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
                
                GameEvent.Get<IUIRefresh>()?.RefreshUI();
            }
        }
    }
}