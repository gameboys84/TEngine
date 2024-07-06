using TEngine;
using TMPro;
using UnityEngine.UI;

namespace GameLogic
{
    [Window(UILayer.UI)]
    class UIMainWindow : UIWindow
    {
        #region 脚本工具生成的代码
        private Button m_btnSettings;
        private TextMeshProUGUI m_tmpTitle;
        private Button m_btnTest;
        private TextMeshProUGUI m_tmpButtonText;
        private Button m_btnExit;
        protected override void ScriptGenerator()
        {
            m_btnSettings = FindChildComponent<Button>("UITopRight/m_btnSettings");
            m_tmpTitle = FindChildComponent<TextMeshProUGUI>("UIPanel/m_tmpTitle");
            m_btnTest = FindChildComponent<Button>("UIPanel/m_btnTest");
            m_tmpButtonText = FindChildComponent<TextMeshProUGUI>("UIPanel/m_btnTest/m_tmpButtonText");
            m_btnExit = FindChildComponent<Button>("UIPanel/m_btnExit");
            m_btnSettings.onClick.AddListener(OnClickSettingsBtn);
            m_btnTest.onClick.AddListener(OnClickTestBtn);
            m_btnExit.onClick.AddListener(OnClickExitBtn);
        }
        #endregion

        #region 事件

        private int count;
        private void OnClickSettingsBtn()
        {
            count++;
            Log.Debug("OnClickSettingsBtn, count = {0}", count);
            m_tmpTitle.text = Utility.Text.Format("Settings Title : {0}", count);
        }
        private void OnClickTestBtn()
        {
            // box operation : $"OnClickTestBtn:{count}";
            m_tmpButtonText.text = Utility.Text.Format("OnClickTestBtn:{0}", count); 
        }
        private void OnClickExitBtn()
        {
            ModuleSystem.Shutdown(ShutdownType.Quit);
        }
        #endregion

    }
}