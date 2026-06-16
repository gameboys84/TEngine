using Cysharp.Threading.Tasks;
using Fantasy.Network.Interface;

namespace GameLogic
{
    public class BaseMessage : IMessage
    {
        protected uint opCode;
        public void Dispose()
        {

        }

        public uint OpCode()
        {
            return opCode;
        }
    }

    public class BaseRequest : IRequest
    {
        protected uint opCode;
        public void Dispose()
        {

        }

        public uint OpCode()
        {
            return opCode;
        }
    }
    
    public enum ConnectionState
    {
        NOT_INITED = -1,
        NOT_CONNECTED = 0,
        CONNECTING = 1,
        CONNECTED = 2,
    }
    
    public interface INetworkModule
    {
        void Connect(string _ip, int _port, int _timeout);
        void Disconnect();
        bool IsConnected();
        ConnectionState GetConnectionState();
    }

    public interface INetworkFantasyModule : INetworkModule
    {
        void Send<T>(T message) where T : IMessage;
        UniTask<V> Call<T, V>(T request) where T : IRequest where V : class, IResponse;
    }
}