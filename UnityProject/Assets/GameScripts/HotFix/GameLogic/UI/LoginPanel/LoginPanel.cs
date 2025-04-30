using UnityEngine;
using UnityEngine.UI;
using TEngine;
using TMPro;
using LocalizationManager = TEngine.Localization.LocalizationManager;

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
        }
        private void OnClickRegionBtn()
        {
            Log.Debug($"BEFORE LANG: {LocalizationManager.CurrentLanguage}, {LocalizationManager.GetTranslation(ScriptLocalization.Language)}");
            
            GameModule.Localization.SetLanguage(Language.Arabic, true);

            Log.Debug($"AFTER LANG: {LocalizationManager.CurrentLanguage}, {LocalizationManager.GetTranslation(ScriptLocalization.Language)}");
        }
        #endregion

        protected override void OnCreate()
        {
            base.OnCreate();
            
            LocalizationManager.CurrentLanguage = "Chinese";
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

        protected override void OnUpdate()
        {
            base.OnUpdate();

            if (Input.GetKeyDown(KeyCode.A))
            {
                GameEvent.Send(Event_UIEvent);
            }
        }
    }
}