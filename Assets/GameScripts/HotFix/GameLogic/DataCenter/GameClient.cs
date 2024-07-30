using System;
using System.IO;
using GameBase;
using TEngine;
using TEngine.Core.Network;
using TEngine.Logic;

namespace GameLogic
{
    /// <summary>
    /// 网络客户端状态。
    /// </summary>
    public enum GameClientStatus
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        StatusInit, 
        /// <summary>
        /// 连接成功服务器。
        /// </summary>
        StatusConnected,
        /// <summary>
        /// 重新连接。
        /// </summary>
        StatusReconnect,
        /// <summary>
        /// 断开连接。
        /// </summary>
        StatusClose,
        /// <summary>
        /// 登录中。
        /// </summary>
        StatusLogin,
        /// <summary>
        /// AccountLogin成功，进入服务器了。
        /// </summary>
        StatusEnter,
    }
    
    /// <summary>
    /// 网络客户端。
    /// </summary>
    public class GameClient:Singleton<GameClient>
    {
        public readonly NetworkProtocolType ProtocolType = NetworkProtocolType.KCP;
        public GameClientStatus Status { get; set; } = GameClientStatus.StatusInit;
        public bool IsConnect => Status == GameClientStatus.StatusConnected || Status == GameClientStatus.StatusLogin || Status == GameClientStatus.StatusEnter;
        public Scene Scene { private set; get; }
        
        private string _lastAddress = String.Empty;
        
        public GameClient()
        {
            Scene = GameApp.Instance.Scene;
        }
        
        public void Connect(string address, bool reconnect = false)
        {
            if (IsConnect)
            {
                return;
            }
            if (!reconnect)
            {
                // SetWatchReconnect(false);
            }

            if (reconnect)
            {
                // GameEvent.Get<ICommUI>().ShowWaitUITip(WaitUISeq.LOGINWORLD_SEQID, G.R(TextDefine.ID_TIPS_RECONNECTING));
            }
            else
            {
                // GameEvent.Get<ICommUI>().ShowWaitUI(WaitUISeq.LOGINWORLD_SEQID);
            }

            _lastAddress = address;

            Status = reconnect ? GameClientStatus.StatusReconnect : GameClientStatus.StatusInit;
            // if (Scene.Session != null)
            // {
            //     Scene.Session.Dispose();
            // }

            if (Scene.Session == null || Scene.Session.IsDisposed)
            {
                Scene.CreateSession(address, ProtocolType, OnConnectComplete, OnConnectFail, OnConnectDisconnect);
            }
        }

        public void Reconnect()
        {
            if (string.IsNullOrEmpty(_lastAddress))
                return;

            if (Scene.Session == null || Scene.Session.IsDisposed)
            {
                Connect(_lastAddress, true);
            }
            else
            {
                Scene.CreateSession(_lastAddress, ProtocolType, OnConnectComplete, OnConnectFail, OnConnectDisconnect);
            }
        }
        
        public void Disconnect()
        {
            var sessionHeartbeatComponent = Scene.Session.GetComponent<SessionHeartbeatComponent>();
            if (sessionHeartbeatComponent != null)
            {
                sessionHeartbeatComponent.Dispose();
            }
            Scene.Session.Dispose();
            // if (Scene.Session != null)
            // {
            //     Scene.Session.Dispose();
            // }
            // Status = GameClientStatus.StatusClose;
        }

        private void OnConnectComplete()
        {
            Status = GameClientStatus.StatusConnected;
            // Scene.Session.AddComponent<SessionHeartbeatComponent>().Start(15000);
            Log.Info("Connect to server success");
        }

        private void OnConnectFail()
        {
            Status = GameClientStatus.StatusClose;
            Log.Warning("Could not connect to server");
        }
        
        private void OnConnectDisconnect()
        {
            Status = GameClientStatus.StatusClose;
            Disconnect();
            Log.Warning("OnConnectDisconnect server");
        }
        
        /// <summary>
        /// 无回应请求
        /// </summary>
        /// <param name="message"></param>
        /// <param name="rpcId"></param>
        /// <param name="routeId"></param>
        public virtual void Send(object message, uint rpcId = 0, long routeId = 0)
        {
            if (Scene.Session == null)
            {
                Log.Error("Send Message Failed Because Session Is Null");
                return;
            }
            Scene.Session.Send(message,rpcId,routeId);
        }

        /// <summary>
        /// 无回应请求
        /// </summary>
        /// <param name="routeMessage"></param>
        /// <param name="rpcId"></param>
        /// <param name="routeId"></param>
        public virtual void Send(IRouteMessage routeMessage, uint rpcId = 0, long routeId = 0)
        {
            if (Scene.Session == null)
            {
                Log.Error("Send Message Failed Because Session Is Null");
                return;
            }
            Scene.Session.Send(routeMessage,rpcId,routeId);
        }

        /// <summary>
        /// 无回应请求
        /// </summary>
        /// <param name="memoryStream"></param>
        /// <param name="rpcId"></param>
        /// <param name="routeTypeOpCode"></param>
        /// <param name="routeId"></param>
        public virtual void Send(MemoryStream memoryStream, uint rpcId = 0, long routeTypeOpCode = 0, long routeId = 0)
        {
            if (Scene.Session == null)
            {
                Log.Error("Send Message Failed Because Session Is Null");
                return;
            }
            Scene.Session.Send(memoryStream,rpcId,routeTypeOpCode,routeId);
        }
        
        /// <summary>
        /// 有回应请求
        /// </summary>
        /// <param name="request"></param>
        /// <param name="routeId"></param>
        /// <returns></returns>
        public virtual async FTask<IResponse> Call(IRequest request, long routeId = 0)
        {
            if (Scene == null || Scene.Session == null || Scene.Session.IsDisposed)
            {
                return null;
            }
            
            var requestCallback = await Scene.Session.Call(request,routeId);
            
            return requestCallback;
        }
        
        // 处理ntf消息, 不用注册，直接处理即可
        // public class H_G2C_ReceiveMessageToServerHandler : Message<H_G2C_ReceiveMessageToServer>
        // {
        //     protected override async FTask Run(Session session, H_G2C_ReceiveMessageToServer message)
        //     {
        //         // DO SOMETHING
        //         var networkEntryComponent = session.Scene.GetComponent<NetworkEntryComponent>();
        //         networkEntryComponent.Action($"收到服务器推送的消息 message:{message.Message}");
        //         await FTask.CompletedTask;
        //     }
        // }
        
        // public void RegisterMsgHandler(uint protocolCode,Action<IResponse> ctx)
        // {
        //     MessageDispatcherSystem.Instance.RegisterMsgHandler(protocolCode,ctx);
        // }
        //
        // public void UnRegisterMsgHandler(uint protocolCode,Action<IResponse> ctx)
        // {
        //     MessageDispatcherSystem.Instance.UnRegisterMsgHandler(protocolCode,ctx);
        // }
    }
}