using System.Collections.Generic;
using GameLogic;
using UnityEngine;
using UnityEngine.UI;
using TEngine;

class TempData
{
    public string text;
}

class TempItem : UILoopItemWidget, IListDataItem<TempData>
{
    public void SetItemData(TempData d)
    {
        gameObject.transform.Find("txtItem").GetComponent<Text>().text = d.text;
    }
}

[Window(UILayer.UI)]
class NetWorkDemoUI : UIWindow
{
    protected UILoopListWidget<TempItem, TempData> m_loopList;
    List<TempData> datas = new List<TempData>();
    
    #region 脚本工具生成的代码
    private Button m_btnExit;
    private GameObject m_goConnect;
    private Button m_btnConnect;
    private Button m_btnDisConnect;
    private GameObject m_goLogin;
    private InputField m_inputPassWord;
    private InputField m_inputName;
    private Button m_btnLogin;
    private Button m_btnRegister;
    private ScrollRect m_scrollRect;
    private Transform m_tfContent;
    private GameObject m_itemTemp;
    public override void ScriptGenerator()
    {
        m_btnExit = FindChildComponent<Button>("Panel/m_btnExit");
        m_goConnect = FindChild("Panel/m_goConnect").gameObject;
        m_btnConnect = FindChildComponent<Button>("Panel/m_goConnect/m_btnConnect");
        m_btnDisConnect = FindChildComponent<Button>("Panel/m_goConnect/m_btnDisConnect");
        m_goLogin = FindChild("Panel/m_goLogin").gameObject;
        m_inputPassWord = FindChildComponent<InputField>("Panel/m_goLogin/m_inputPassWord");
        m_inputName = FindChildComponent<InputField>("Panel/m_goLogin/m_inputName");
        m_btnLogin = FindChildComponent<Button>("Panel/m_goLogin/m_btnLogin");
        m_btnRegister = FindChildComponent<Button>("Panel/m_goLogin/m_btnRegister");
        m_scrollRect = FindChildComponent<ScrollRect>("Panel/m_scrollRect");
        m_tfContent = FindChild("Panel/m_scrollRect/Viewport/m_tfContent");
        m_itemTemp = FindChild("Panel/m_scrollRect/Viewport/m_tfContent/m_itemTemp").gameObject;
        m_btnExit.onClick.AddListener(OnClickExitBtn);
        m_btnConnect.onClick.AddListener(OnClickConnectBtn);
        m_btnDisConnect.onClick.AddListener(OnClickDisConnectBtn);
        m_btnLogin.onClick.AddListener(OnClickLoginBtn);
        m_btnRegister.onClick.AddListener(OnClickRegisterBtn);
    }
    #endregion

    public override void BindMemberProperty()
    {
        base.BindMemberProperty();
        
        m_loopList = CreateWidget<UILoopListWidget<TempItem, TempData>>(m_scrollRect.gameObject);
        m_loopList.itemBase = m_itemTemp;
        
        Application.logMessageReceived += AddLog;
    }

    public override void OnDestroy()
    {
        Application.logMessageReceived -= AddLog;
        GameObject.Destroy(m_loopList.gameObject);
        base.OnDestroy();
    }

    public override void OnRefresh()
    {
        m_loopList.SetDatas(datas);
        base.OnRefresh();
    }

    // public override void OnRefresh()
    // {
    //     m_loopList = CreateWidget<UILoopListWidget<TempItem, TempData>>(m_scrollRect.gameObject);
    //     m_loopList.itemBase = m_itemTemp;
    //     List<TempData> datas = new List<TempData>();
    //     for (int i = 0; i < 100; i++)
    //     {
    //         datas.Add(new TempData());
    //     }
    //     m_loopList.SetDatas(datas);
    //     base.OnRefresh();
    // }

    #region 事件
    private void OnClickExitBtn()
    {
        GameModule.UI.CloseWindow<NetWorkDemoUI>();
        GameModule.UI.ShowUI<UIEntry>();
    }
    private void OnClickConnectBtn()
    {
        // GameClient.Instance.Connect("127.0.0.1:20000");
        GameClient.Instance.Connect("172.20.213.191:20000");
    }

    private void OnClickDisConnectBtn()
    {
        // GameClient.Instance.Connect("127.0.0.1:20000");
        GameClient.Instance.Disconnect();
        // GameClient.Instance.Reconnect();
    }

    private void OnClickLoginBtn()
    {
        if (!GameClient.Instance.IsConnect)
        {
            Log.Info("没有连接到服务器、请先点击连接到服务器按钮在进行此操作");
            return;
        }

        if (string.IsNullOrEmpty(m_inputName.text) || string.IsNullOrEmpty(m_inputPassWord.text))
        {
            Log.Info("请输入账号和密码");
            return;
        }
        PlayerNetSys.Instance.DoLoginReq(m_inputName.text,m_inputPassWord.text);
    }

    private void OnClickRegisterBtn()
    {
        if (!GameClient.Instance.IsConnect)
        {
            Log.Info("没有连接到服务器、请先点击连接到服务器按钮在进行此操作");
            return;
        }

        if (string.IsNullOrEmpty(m_inputName.text) || string.IsNullOrEmpty(m_inputPassWord.text))
        {
            Log.Info("请输入账号和密码");
            return;
        }
        PlayerNetSys.Instance.DoRegisterReq(m_inputName.text,m_inputPassWord.text);
    }

    #endregion
    
    private void AddLog(string condition, string stacktrace, LogType type)
    {
        // Log.Info(condition);
        datas.Add(new TempData() {text = condition});
        OnRefresh();
    }
}

namespace GameLogic
{
    [Window(UILayer.UI)]
    class NetWorkDemoLog : UIWindow
    {
        #region 脚本工具生成的代码

        private Text m_textInfo;

        public override void ScriptGenerator()
        {
            m_textInfo = FindChildComponent<Text>("m_textInfo");
        }

        #endregion

        public void SetText(string value)
        {
            m_textInfo.text = value;
        }
    }
}