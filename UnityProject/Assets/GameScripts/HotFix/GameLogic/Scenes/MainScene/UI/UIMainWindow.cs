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
        private TextMeshProUGUI m_tmpTxtTitle;
        private TextMeshProUGUI m_tmpTxtDesc;
        private Button m_btnTest;
        private Button m_btnOpenWindow;
        private Button m_btnExit;
        protected override void ScriptGenerator()
        {
            m_btnSettings = FindChildComponent<Button>("UITopRight/m_btnSettings");
            m_tmpTxtTitle = FindChildComponent<TextMeshProUGUI>("UIPanel/m_tmpTxtTitle");
            m_tmpTxtDesc = FindChildComponent<TextMeshProUGUI>("UIPanel/m_tmpTxtDesc");
            m_btnTest = FindChildComponent<Button>("UIPanel/m_btnTest");
            m_btnOpenWindow = FindChildComponent<Button>("UIPanel/m_btnOpenWindow");
            m_btnExit = FindChildComponent<Button>("UIPanel/m_btnExit");
            m_btnSettings.onClick.AddListener(OnClickSettingsBtn);
            m_btnTest.onClick.AddListener(OnClickTestBtn);
            m_btnOpenWindow.onClick.AddListener(OnClickOpenWindowBtn);
            m_btnExit.onClick.AddListener(OnClickExitBtn);
        }
        #endregion

        #region 事件

        private int count;
        private void OnClickSettingsBtn()
        {
            count++;
            Log.Debug("OnClickSettingsBtn, count = {0}", count);
            m_tmpTxtTitle.text = Utility.Text.Format("Settings Title : {0}", count);
        }
        private void OnClickTestBtn()
        {
            // box operation : $"OnClickTestBtn:{count}";
            m_tmpTxtDesc.text = Utility.Text.Format("OnClickTestBtn:{0}", count); 
        }
        private void OnClickOpenWindowBtn()
        {
            GameModule.UI.ShowUIAsync<UIMainDefaultWindow>();
        }
        private void OnClickExitBtn()
        {
            ModuleSystem.Shutdown();
        }
        #endregion

    }
}