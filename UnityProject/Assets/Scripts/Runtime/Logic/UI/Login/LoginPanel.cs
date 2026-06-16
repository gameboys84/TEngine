using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using TEngine;
using LocalizationManager = TEngine.Localization.LocalizationManager;

namespace GameLogic
{
	[Window(UILayer.UI, location : "LoginPanel")]
	public partial class LoginPanel
	{
		#region UI事件

		private partial async UniTaskVoid OnClickLoginBtn()
		{
			if (!GameModule.Network.IsConnected())
			{
				GameModule.Network.Connect(ip, port, 3000);
				return;
			}
            
			var result = await GameModule.Network.Call<Fantasy.C2G_TestRequest, Fantasy.G2C_TestResponse>(new Fantasy.C2G_TestRequest()
			{
				Tag = "Test from LoginPanel"
			});

			if (result == null)
			{
				Debug.LogError($"C2G_TestRequest 还没建立连接");
				return;
			}
			
			GameEvent.Send(GameEventLogic.Event_UIEvent);
            
			if (result is not { ErrorCode: 0 })
			{
				Debug.LogError($"G2C_TestResponse return Error: {result.Tag}, {result.ErrorCode}");
				return;
			}

			m_btnLogin.interactable = false;
			Debug.Log($"G2C_TestResponse return Success: {result.Tag}");
			GameModule.Timer.AddTimer(_ =>
			{
				m_btnLogin.interactable = true;
				GameModule.UI.ShowUIAsync<LoadingPanel>();
				Close();
			}, 3f, false);
		}

		
		private int idx = 0;
		private List<string> allLanguages;
		private partial void OnClickRegionBtn()
		{
			Log.Debug($"BEFORE LANG: {GameModule.Localization.Language}");

			GameModule.Localization.SetLanguage(allLanguages[idx], true);
			idx = (idx + 1) % allLanguages.Count;
			// GameModule.Localization.SetLanguage(Language.Arabic, true);

			Log.Debug($"AFTER LANG: {GameModule.Localization.Language}");
		}
		
		private partial void OnClickSayHiBtn()
		{
			if (!GameModule.Network.IsConnected())
			{
				GameModule.Network.Connect(ip, port, 3000);
				return;
			}
	        
			Debug.Log("Send Message: Hello World");
			GameModule.Network.Send(new Fantasy.C2G_TestMessage()
			{
				Tag = "OnClickSendButtonBtn"
			});
		}

		private partial void OnClickConnectBtn()
		{
			var connected = GameModule.Network.IsConnected();
			Debug.Log($"IsConnected: {connected}");
			if (connected)
			{
				GameModule.Network.Disconnect();
			}
			else
			{
				GameModule.Network.Connect(ip, port, 3000);
			}
		}
		#endregion
		
		#region Override

		[SerializeField] private string ip = "172.20.213.191";
		[SerializeField] private int port = 20000;
		private bool isConnected = false;
		protected override void OnCreate()
		{
			base.OnCreate();

			var items = GameModule.ConfigSystem.Tables.TbItem;
			var item = items.Get(10000);
            
			Log.Debug((string)item.ToString());
			Log.Debug($"OnCreate, {WindowName}");

			allLanguages = LocalizationManager.GetAllLanguages();
            
			GameModule.LocalSave.Load<LocalPlayerInfo>("PlayerInfo.dat");
            
			RefreshNetWorkStatus();

			if (!GameModule.Network.IsConnected())
			{
				GameModule.Network.Connect(ip, port, 3000);
			}
		}

		protected override void OnSetVisible(bool visible)
		{
			base.OnSetVisible(visible);
            
			Log.Debug($"OnSetVisible, visible:{visible}, {WindowName}");
			// if (visible)
			// {
			//     if (!GameModule.Network.IsConnected())
			//     {
			//         GameModule.Network.Connect(ip, port, 3000);
			//     }
			// }
		}

		protected override void RegisterEvent()
		{
			base.RegisterEvent();
            
			// 可以参考 事件模块.md 中的示例
			// 添加监听事件 : bool GameEvent.AddEventListener(int eventType, Action handler);
			// 取消监听事件 : bool GameEvent.RemoveEventListener(int eventType, Action handler);
			// 如果是UI内，推荐使用自动取消监听的UI事件 : AddUIEvent(Event_UIEvent, OnUIEvent);
            
			// 触发事件 :
			// GameEvent.Get<T>().DoSomething();
			// bool GameEvent.Send(int eventType, params object[] args);
            
            
			AddUIEvent(GameEventLogic.Event_UIEvent, OnUIEvent);
			GameEvent.AddEventListener(ILoginUI_Event.ShowLoginUI, OnShowLoginUI);
			GameEvent.AddEventListener<bool, string>("CustomEvent", OnCustomEvent);

			GameEvent.AddEventListener((int)GameEventCoreId.NETWORK_CONNECTED, OnNetworkConnected);
			GameEvent.AddEventListener((int)GameEventCoreId.NETWORK_DISCONNECTED, OnNetworkDisconnected);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
            
			GameEvent.RemoveEventListener(ILoginUI_Event.ShowLoginUI, OnShowLoginUI);
			GameEvent.RemoveEventListener<bool, string>("CustomEvent", OnCustomEvent);
            
			GameEvent.RemoveEventListener((int)GameEventCoreId.NETWORK_CONNECTED, OnNetworkConnected);
			GameEvent.RemoveEventListener((int)GameEventCoreId.NETWORK_DISCONNECTED, OnNetworkDisconnected);
		}

		#endregion

        #region 自定义事件

        private void OnUIEvent()
        {
	        Log.Debug("OnUIEvent call by event, 首先触发");
            
	        GameEvent.Get<ILoginUI>()?.ShowLoginUI();
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

        private void OnNetworkDisconnected()
        {
	        isConnected = false;
	        RefreshNetWorkStatus();
        }

        private void OnNetworkConnected()
        {
	        isConnected = true;
	        RefreshNetWorkStatus();
        }

        private void RefreshNetWorkStatus()
        {
	        Debug.Log($"RefreshNetWorkStatus, isConnected:{isConnected}");
	        
	        // m_btnConnect.interactable = !isConnected;
	        m_textNetStatus.text = isConnected ? "Disconnect" : "Connect";
	        
	        m_btnSayHi.interactable = isConnected;
        }

        #endregion
	}
}
