#define USING_FANTASY_RUNTIME

using Cysharp.Threading.Tasks;
using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;

namespace TEngine
{
    
    public class NetworkFantasyModule : Module, INetworkFantasyModule
    {
        #region Module

        private Fantasy.Scene _scene;
        private Session _session;

        private string ip;
        private int port;
        private int timeout;
        
        public override void OnInit()
        {
            Initialize().Coroutine();
        }

        public override void Shutdown()
        {
            _scene.Dispose();
            _scene = null;
            
#if USING_FANTASY_RUNTIME
            Runtime.OnDestroy();
#else
            _session.Dispose();
            _session = null;
#endif            
        }

        private async FTask Initialize()
        {
#if !USING_FANTASY_RUNTIME            
            // 初始化框架
            await Fantasy.Platform.Unity.Entry.Initialize();
            
            // 创建用一个客户端的Scene没如果有个别同学不需要使用框架的Scene
            // 那就把Scene当网络接口使用。
            _scene = await Fantasy.Platform.Unity.Entry.CreateScene();
#endif
            if (!isConnected && !string.IsNullOrEmpty(ip) && port > 0 && timeout > 0)
            {
                Connect(ip, port, timeout);
            }
        }

        #endregion

        
        #region NetworkModule Interface
        
        private bool isConnected = false;
        private bool isReconnecting = false;

        private bool IsSessionValid()
        {
            return _session is { IsDisposed: false };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_ip"></param>
        /// <param name="_port"></param>
        /// <param name="_timeout"></param>
        public void Connect(string _ip, int _port, int _timeout)
        {
            ip = _ip;
            port = _port;
            timeout = _timeout;

            if (_session != null)
            {
                Log.Warning("Disconnect old session");
                _session.Dispose();
                _session = null;
                
                // 可选 延迟一段时间再重连
                // await UniTask.Delay(1000);
            }
            
            Log.Debug($"Connect, ip:{ip}:{port}, timeout:{timeout}, scene:{_scene}");
            
#if USING_FANTASY_RUNTIME            
            Runtime.Connect(ip, port, FantasyRuntime.NetworkProtocolType.KCP, false, timeout, true, 2000, 30000, 5000, 4,
                    OnConnectComplete, OnConnectFail, OnConnectDisconnect, false);
#else
            if (_scene != null)
            {
                _session = _scene.Connect($"{ip}:{port}", NetworkProtocolType.KCP,
                    OnConnectComplete,
                    OnConnectFail,
                    OnConnectDisconnect,
                    false, timeout);
            }
#endif
        }

        public void Disconnect()
        {
            if (IsSessionValid())
            {
                _session.Dispose();
                _session = null;
            }
        }

        public bool IsConnected()
        {
            return isConnected;
        }

        public ConnectionState GetConnectionState()
        {
            if (_session == null)
            {
                return ConnectionState.NOT_INITED;
            }

            if (_session.IsDisposed == false)
            {
                // session已经建立没释放, 表示可能已经连接成功或正在连接中
                return isConnected ? ConnectionState.CONNECTED : ConnectionState.CONNECTING;
            }
            else
            {
                // 重连中也算在连接
                return isReconnecting ? ConnectionState.CONNECTING : ConnectionState.NOT_CONNECTED;
            }
        }

        #endregion
        
        
        #region Network Callback
        
        private void OnConnectComplete()
        {
            Log.Warning("OnConnectComplete");
            
            isConnected = true;
            isReconnecting = false;
         
#if USING_FANTASY_RUNTIME            
            _scene = Runtime.Scene;
            _session = Runtime.Session;
#else            
            // 心跳检测, 上面的 Runtime 在Connect时已经注册了 心跳，就不用重复注册了
            _session.AddComponent<SessionHeartbeatComponent>().Start(2000);
#endif
        }

        private void OnDisconnected()
        {
            isConnected = false;
            isReconnecting = false;
        }

        private void OnConnectFail()
        {
            Log.Error("OnConnectFail");
            
            OnDisconnected();
        }

        private void OnConnectDisconnect()
        {
            Log.Error("OnConnectDisconnect");
            
            OnDisconnected();
        }
        
        #endregion
        
        
        
        #region Message Request

        // public void RegisterMessage(MessageDelegate<IMessage> callback)
        // {
        //     if (!IsSessionValid())
        //     {
        //         Log.Error("RegisterMessage Session is not valid");
        //         return;
        //     }
        //     _session.GetComponent<MessageDispatcherComponent>()?.RegisterHandler(callback);
        // }
        //
        // public void UnregisterMessage(MessageDelegate<IMessage> callback)
        // {
        //     if (!IsSessionValid())
        //     {
        //         Log.Error("UnregisterMessage Session is not valid");
        //         return;
        //     }
        //     _session.GetComponent<MessageDispatcherComponent>()?.UnRegisterHandler(callback);
        // }

        public void Send<T>(T message) where T : IMessage 
        {
            if (!isConnected)
            {
                Log.Error("Network not connected");
                return;
            }
        
            _session.Send(message);
        }
        
        public async UniTask<V> Call<T,V>(T request) where T : IRequest where V : class, IResponse
        {
            if (!isConnected)
            {
                Log.Error("Network not connected");
                return null;
            }
            
            var result = await _session.Call<T>(request) as V;
            return result;
        }

        #endregion
    }
}