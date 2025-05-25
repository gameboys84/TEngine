using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TEngine;
using TMPro;

namespace GameLogic
{
    [Window(UILayer.UI)]
    class LoginPanel : UIWindow
    {
        #region 脚本工具生成的代码
        private InputField _inputAccount;
        private InputField _inputPassword;
        private Button _btnLogin;
        private Button _btnRegion;
        private TextMeshProUGUI _tmpRegion;
        protected override void ScriptGenerator()
        {
            _inputAccount = FindChildComponent<InputField>("m_inputAccount");
            _inputPassword = FindChildComponent<InputField>("m_inputPassword");
            _btnLogin = FindChildComponent<Button>("m_btnLogin");
            _btnRegion = FindChildComponent<Button>("m_btnRegion");
            _tmpRegion = FindChildComponent<TextMeshProUGUI>("m_btnRegion/m_tmpRegion");
            _btnLogin.onClick.AddListener(OnClickLoginBtn);
            _btnRegion.onClick.AddListener(OnClickRegionBtn);
        }
        #endregion

        #region 事件
        private void OnClickLoginBtn()
        {
            GameModule.UI.ShowUIAsync<LoadingPanel>();
            Close();
        }

        private int idx = 0;
        private List<string> allLanguages;
        private void OnClickRegionBtn()
        {
            Log.Debug($"BEFORE LANG: {GameModule.Localization.Language}");

            GameModule.Localization.SetLanguage(allLanguages[idx], true);
            idx = (idx + 1) % allLanguages.Count;
            // GameModule.Localization.SetLanguage(Language.Arabic, true);

            Log.Debug($"AFTER LANG: {GameModule.Localization.Language}");
        }
        #endregion

        protected override void OnCreate()
        {
            base.OnCreate();

            var items = GameModule.ConfigSystem.Tables.TbItem;
            var item = items.Get(10000);
            Log.Debug(item.ToString());

            allLanguages = TEngine.Localization.LocalizationManager.GetAllLanguages();
        }
        
        
        protected override void RegisterEvent()
        {
            base.RegisterEvent();
            
            AddUIEvent(Event_UIEvent, OnUIEvent);
            GameEvent.AddEventListener(ILoginUI_Event.ShowLoginUI, OnShowLoginUI);
            GameEvent.AddEventListener<bool, string>("CustomEvent", OnCustomEvent);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            
            GameEvent.RemoveEventListener(ILoginUI_Event.ShowLoginUI, OnShowLoginUI);
            GameEvent.RemoveEventListener<bool, string>("CustomEvent", OnCustomEvent);
        }

        
        private readonly int Event_UIEvent = RuntimeId.ToRuntimeId("UIEvent");
        private void OnUIEvent()
        {
            Log.Debug("OnUIEvent call by event, 首先触发");
            
            GameEvent.Get<ILoginUI>().ShowLoginUI();
        }

        private void OnShowLoginUI()
        {
            Log.Debug("OnShowLoginUI call by event, 第二触发");
            
            GameEvent.Send("CustomEvent", true, "Hello World");
        }
        
        private void OnCustomEvent(bool ret, string data)
        {
            Log.Debug("OnCustomEvent, 第三触发, ret:{0}, data:{1}", ret, data);
        }

        public class LocalPlayerInfo : LocalSaveDataBase
        {
            public string uuid;
            public string overrideUuid;
            public long playerId;
            public string LinkedEmailAddress; // 仅用于显示
            public string LoginEmailAddress;
            public string LastTryEmailAddress;
            public string RefreshToken;
        }
        private LocalPlayerInfo localPlayerInfo = new LocalPlayerInfo()
        {
            uuid = "123456",
            overrideUuid = "123123",
            playerId = 567890,
            LinkedEmailAddress = "game@email.com",
            LoginEmailAddress = "gameboys@email.com",
            LastTryEmailAddress = "",
            RefreshToken = "U2FsdGVkX18qJY4EdGj+HkGP24CePEPhw8Sx6VIERHU="
        };

        protected override void OnUpdate()
        {
            base.OnUpdate();

            if (Input.GetKeyDown(KeyCode.A))
            {
                GameEvent.Send(Event_UIEvent);
            }
            else if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                // 测试 LocalSave
                GameModule.LocalSave.Save("TestKey.sav", localPlayerInfo, true);
                Log.Info("Save Success");
            }
            else if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                // 测试 Load
                var _localPlayerInfo = GameModule.LocalSave.Load<LocalPlayerInfo>("TestKey.sav", true);
                Log.Info(_localPlayerInfo == null ? "Load Fail" : "Load Success");
                
                if (_localPlayerInfo != null)
                {
                    Log.Debug($"Load: playerId={_localPlayerInfo.playerId}, uuid={_localPlayerInfo.uuid}, overrideUuid={_localPlayerInfo.overrideUuid}, " +
                              $"LinkedEmailAddress={_localPlayerInfo.LinkedEmailAddress}, LoginEmailAddress={_localPlayerInfo.LoginEmailAddress}, " +
                              $"LastTryEmailAddress={_localPlayerInfo.LastTryEmailAddress}, RefreshToken={_localPlayerInfo.RefreshToken} ");
                }
            }
        }
    }
}