using LightProto;
using System;
using MemoryPack;
using System.Collections.Generic;
using Fantasy;
using Fantasy.Pool;
using Fantasy.Network.Interface;
using Fantasy.Serialize;

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8618
// ReSharper disable InconsistentNaming
// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable RedundantTypeArgumentsOfMethod
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PreferConcreteValueOverDefault
// ReSharper disable RedundantNameQualifier
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable CheckNamespace
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable RedundantUsingDirective
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
namespace Fantasy
{
    [Serializable]
    [ProtoContract]
    public partial class C2G_TestMessage : AMessage, IMessage
    {
        public static C2G_TestMessage Create(bool autoReturn = true)
        {
            var c2G_TestMessage = MessageObjectPool<C2G_TestMessage>.Rent();
            c2G_TestMessage.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2G_TestMessage.SetIsPool(false);
            }
            
            return c2G_TestMessage;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Tag = default;
            MessageObjectPool<C2G_TestMessage>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2G_TestMessage; } 
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class C2G_TestRequest : AMessage, IRequest
    {
        public static C2G_TestRequest Create(bool autoReturn = true)
        {
            var c2G_TestRequest = MessageObjectPool<C2G_TestRequest>.Rent();
            c2G_TestRequest.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2G_TestRequest.SetIsPool(false);
            }
            
            return c2G_TestRequest;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Tag = default;
            MessageObjectPool<C2G_TestRequest>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2G_TestRequest; } 
        [ProtoIgnore]
        public G2C_TestResponse ResponseType { get; set; }
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class G2C_TestResponse : AMessage, IResponse
    {
        public static G2C_TestResponse Create(bool autoReturn = true)
        {
            var g2C_TestResponse = MessageObjectPool<G2C_TestResponse>.Rent();
            g2C_TestResponse.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                g2C_TestResponse.SetIsPool(false);
            }
            
            return g2C_TestResponse;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            ErrorCode = 0;
            Tag = default;
            MessageObjectPool<G2C_TestResponse>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.G2C_TestResponse; } 
        [ProtoMember(2)]
        public uint ErrorCode { get; set; }
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class C2G_TestNotifyMessage : AMessage, IMessage
    {
        public static C2G_TestNotifyMessage Create(bool autoReturn = true)
        {
            var c2G_TestNotifyMessage = MessageObjectPool<C2G_TestNotifyMessage>.Rent();
            c2G_TestNotifyMessage.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2G_TestNotifyMessage.SetIsPool(false);
            }
            
            return c2G_TestNotifyMessage;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Msg = default;
            MessageObjectPool<C2G_TestNotifyMessage>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2G_TestNotifyMessage; } 
        [ProtoMember(1)]
        public string Msg { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class G2C_TestNotifyMessage : AMessage, IMessage
    {
        public static G2C_TestNotifyMessage Create(bool autoReturn = true)
        {
            var g2C_TestNotifyMessage = MessageObjectPool<G2C_TestNotifyMessage>.Rent();
            g2C_TestNotifyMessage.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                g2C_TestNotifyMessage.SetIsPool(false);
            }
            
            return g2C_TestNotifyMessage;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Msg = default;
            MessageObjectPool<G2C_TestNotifyMessage>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.G2C_TestNotifyMessage; } 
        [ProtoMember(1)]
        public string Msg { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class C2G_TestRequestPushMessage : AMessage, IMessage
    {
        public static C2G_TestRequestPushMessage Create(bool autoReturn = true)
        {
            var c2G_TestRequestPushMessage = MessageObjectPool<C2G_TestRequestPushMessage>.Rent();
            c2G_TestRequestPushMessage.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2G_TestRequestPushMessage.SetIsPool(false);
            }
            
            return c2G_TestRequestPushMessage;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            MessageObjectPool<C2G_TestRequestPushMessage>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2G_TestRequestPushMessage; } 
    }
    /// <summary>
    /// Gate服务器推送一个消息给客户端
    /// </summary>
    [Serializable]
    [ProtoContract]
    public partial class G2C_PushMessage : AMessage, IMessage
    {
        public static G2C_PushMessage Create(bool autoReturn = true)
        {
            var g2C_PushMessage = MessageObjectPool<G2C_PushMessage>.Rent();
            g2C_PushMessage.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                g2C_PushMessage.SetIsPool(false);
            }
            
            return g2C_PushMessage;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Tag = default;
            MessageObjectPool<G2C_PushMessage>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.G2C_PushMessage; } 
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class C2G_CreateAddressableRequest : AMessage, IRequest
    {
        public static C2G_CreateAddressableRequest Create(bool autoReturn = true)
        {
            var c2G_CreateAddressableRequest = MessageObjectPool<C2G_CreateAddressableRequest>.Rent();
            c2G_CreateAddressableRequest.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2G_CreateAddressableRequest.SetIsPool(false);
            }
            
            return c2G_CreateAddressableRequest;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            MessageObjectPool<C2G_CreateAddressableRequest>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2G_CreateAddressableRequest; } 
        [ProtoIgnore]
        public G2C_CreateAddressableResponse ResponseType { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class G2C_CreateAddressableResponse : AMessage, IResponse
    {
        public static G2C_CreateAddressableResponse Create(bool autoReturn = true)
        {
            var g2C_CreateAddressableResponse = MessageObjectPool<G2C_CreateAddressableResponse>.Rent();
            g2C_CreateAddressableResponse.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                g2C_CreateAddressableResponse.SetIsPool(false);
            }
            
            return g2C_CreateAddressableResponse;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            ErrorCode = 0;
            MessageObjectPool<G2C_CreateAddressableResponse>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.G2C_CreateAddressableResponse; } 
        [ProtoMember(1)]
        public uint ErrorCode { get; set; }
    }
    /// <summary>
    /// 通知Gate服务器创建一个Chat的Route连接
    /// </summary>
    [Serializable]
    [ProtoContract]
    public partial class C2G_CreateChatRouteRequest : AMessage, IRequest
    {
        public static C2G_CreateChatRouteRequest Create(bool autoReturn = true)
        {
            var c2G_CreateChatRouteRequest = MessageObjectPool<C2G_CreateChatRouteRequest>.Rent();
            c2G_CreateChatRouteRequest.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2G_CreateChatRouteRequest.SetIsPool(false);
            }
            
            return c2G_CreateChatRouteRequest;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            MessageObjectPool<C2G_CreateChatRouteRequest>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2G_CreateChatRouteRequest; } 
        [ProtoIgnore]
        public G2C_CreateChatRouteResponse ResponseType { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class G2C_CreateChatRouteResponse : AMessage, IResponse
    {
        public static G2C_CreateChatRouteResponse Create(bool autoReturn = true)
        {
            var g2C_CreateChatRouteResponse = MessageObjectPool<G2C_CreateChatRouteResponse>.Rent();
            g2C_CreateChatRouteResponse.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                g2C_CreateChatRouteResponse.SetIsPool(false);
            }
            
            return g2C_CreateChatRouteResponse;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            ErrorCode = 0;
            MessageObjectPool<G2C_CreateChatRouteResponse>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.G2C_CreateChatRouteResponse; } 
        [ProtoMember(1)]
        public uint ErrorCode { get; set; }
    }
    /// <summary>
    /// 发送一个Route消息给Chat
    /// </summary>
    [Serializable]
    [ProtoContract]
    public partial class C2Chat_TestMessage : AMessage, ICustomRouteMessage
    {
        public static C2Chat_TestMessage Create(bool autoReturn = true)
        {
            var c2Chat_TestMessage = MessageObjectPool<C2Chat_TestMessage>.Rent();
            c2Chat_TestMessage.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2Chat_TestMessage.SetIsPool(false);
            }
            
            return c2Chat_TestMessage;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Tag = default;
            MessageObjectPool<C2Chat_TestMessage>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2Chat_TestMessage; } 
        [ProtoIgnore]
        public int RouteType => Fantasy.RouteType.ChatRoute;
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    /// <summary>
    /// 发送一个RPCRoute消息给Chat
    /// </summary>
    [Serializable]
    [ProtoContract]
    public partial class C2Chat_TestMessageRequest : AMessage, ICustomRouteRequest
    {
        public static C2Chat_TestMessageRequest Create(bool autoReturn = true)
        {
            var c2Chat_TestMessageRequest = MessageObjectPool<C2Chat_TestMessageRequest>.Rent();
            c2Chat_TestMessageRequest.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2Chat_TestMessageRequest.SetIsPool(false);
            }
            
            return c2Chat_TestMessageRequest;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Tag = default;
            MessageObjectPool<C2Chat_TestMessageRequest>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2Chat_TestMessageRequest; } 
        [ProtoIgnore]
        public Chat2C_TestMessageResponse ResponseType { get; set; }
        [ProtoIgnore]
        public int RouteType => Fantasy.RouteType.ChatRoute;
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class Chat2C_TestMessageResponse : AMessage, ICustomRouteResponse
    {
        public static Chat2C_TestMessageResponse Create(bool autoReturn = true)
        {
            var chat2C_TestMessageResponse = MessageObjectPool<Chat2C_TestMessageResponse>.Rent();
            chat2C_TestMessageResponse.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                chat2C_TestMessageResponse.SetIsPool(false);
            }
            
            return chat2C_TestMessageResponse;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            ErrorCode = 0;
            Tag = default;
            MessageObjectPool<Chat2C_TestMessageResponse>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.Chat2C_TestMessageResponse; } 
        [ProtoMember(2)]
        public uint ErrorCode { get; set; }
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    /// <summary>
    /// 发送一个消息给Gate，让Gate发送一个Addressable消息给MAP
    /// </summary>
    [Serializable]
    [ProtoContract]
    public partial class C2G_SendAddressableToMap : AMessage, IMessage
    {
        public static C2G_SendAddressableToMap Create(bool autoReturn = true)
        {
            var c2G_SendAddressableToMap = MessageObjectPool<C2G_SendAddressableToMap>.Rent();
            c2G_SendAddressableToMap.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2G_SendAddressableToMap.SetIsPool(false);
            }
            
            return c2G_SendAddressableToMap;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Tag = default;
            MessageObjectPool<C2G_SendAddressableToMap>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2G_SendAddressableToMap; } 
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    /// <summary>
    /// 发送一个消息给Chat，让Chat服务器主动推送一个RouteMessage消息给客户端
    /// </summary>
    [Serializable]
    [ProtoContract]
    public partial class C2Chat_TestRequestPushMessage : AMessage, ICustomRouteMessage
    {
        public static C2Chat_TestRequestPushMessage Create(bool autoReturn = true)
        {
            var c2Chat_TestRequestPushMessage = MessageObjectPool<C2Chat_TestRequestPushMessage>.Rent();
            c2Chat_TestRequestPushMessage.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2Chat_TestRequestPushMessage.SetIsPool(false);
            }
            
            return c2Chat_TestRequestPushMessage;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            MessageObjectPool<C2Chat_TestRequestPushMessage>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2Chat_TestRequestPushMessage; } 
        [ProtoIgnore]
        public int RouteType => Fantasy.RouteType.ChatRoute;
    }
    /// <summary>
    /// Chat服务器主动推送一个消息给客户端
    /// </summary>
    [Serializable]
    [ProtoContract]
    public partial class Chat2C_PushMessage : AMessage, ICustomRouteMessage
    {
        public static Chat2C_PushMessage Create(bool autoReturn = true)
        {
            var chat2C_PushMessage = MessageObjectPool<Chat2C_PushMessage>.Rent();
            chat2C_PushMessage.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                chat2C_PushMessage.SetIsPool(false);
            }
            
            return chat2C_PushMessage;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Tag = default;
            MessageObjectPool<Chat2C_PushMessage>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.Chat2C_PushMessage; } 
        [ProtoIgnore]
        public int RouteType => Fantasy.RouteType.ChatRoute;
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    /// <summary>
    /// 客户端发送给Gate服务器通知map服务器创建一个SubScene
    /// </summary>
    [Serializable]
    [ProtoContract]
    public partial class C2G_CreateSubSceneRequest : AMessage, IRequest
    {
        public static C2G_CreateSubSceneRequest Create(bool autoReturn = true)
        {
            var c2G_CreateSubSceneRequest = MessageObjectPool<C2G_CreateSubSceneRequest>.Rent();
            c2G_CreateSubSceneRequest.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2G_CreateSubSceneRequest.SetIsPool(false);
            }
            
            return c2G_CreateSubSceneRequest;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            MessageObjectPool<C2G_CreateSubSceneRequest>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2G_CreateSubSceneRequest; } 
        [ProtoIgnore]
        public G2C_CreateSubSceneResponse ResponseType { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class G2C_CreateSubSceneResponse : AMessage, IResponse
    {
        public static G2C_CreateSubSceneResponse Create(bool autoReturn = true)
        {
            var g2C_CreateSubSceneResponse = MessageObjectPool<G2C_CreateSubSceneResponse>.Rent();
            g2C_CreateSubSceneResponse.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                g2C_CreateSubSceneResponse.SetIsPool(false);
            }
            
            return g2C_CreateSubSceneResponse;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            ErrorCode = 0;
            MessageObjectPool<G2C_CreateSubSceneResponse>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.G2C_CreateSubSceneResponse; } 
        [ProtoMember(1)]
        public uint ErrorCode { get; set; }
    }
    /// <summary>
    /// 客户端通知Gate服务器给SubScene发送一个消息
    /// </summary>
    [Serializable]
    [ProtoContract]
    public partial class C2G_SendToSubSceneMessage : AMessage, IMessage
    {
        public static C2G_SendToSubSceneMessage Create(bool autoReturn = true)
        {
            var c2G_SendToSubSceneMessage = MessageObjectPool<C2G_SendToSubSceneMessage>.Rent();
            c2G_SendToSubSceneMessage.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2G_SendToSubSceneMessage.SetIsPool(false);
            }
            
            return c2G_SendToSubSceneMessage;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            MessageObjectPool<C2G_SendToSubSceneMessage>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2G_SendToSubSceneMessage; } 
    }
    /// <summary>
    /// 客户端通知Gate服务器创建一个SubScene的Address消息
    /// </summary>
    [Serializable]
    [ProtoContract]
    public partial class C2G_CreateSubSceneAddressableRequest : AMessage, IRequest
    {
        public static C2G_CreateSubSceneAddressableRequest Create(bool autoReturn = true)
        {
            var c2G_CreateSubSceneAddressableRequest = MessageObjectPool<C2G_CreateSubSceneAddressableRequest>.Rent();
            c2G_CreateSubSceneAddressableRequest.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2G_CreateSubSceneAddressableRequest.SetIsPool(false);
            }
            
            return c2G_CreateSubSceneAddressableRequest;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            MessageObjectPool<C2G_CreateSubSceneAddressableRequest>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2G_CreateSubSceneAddressableRequest; } 
        [ProtoIgnore]
        public G2C_CreateSubSceneAddressableResponse ResponseType { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class G2C_CreateSubSceneAddressableResponse : AMessage, IResponse
    {
        public static G2C_CreateSubSceneAddressableResponse Create(bool autoReturn = true)
        {
            var g2C_CreateSubSceneAddressableResponse = MessageObjectPool<G2C_CreateSubSceneAddressableResponse>.Rent();
            g2C_CreateSubSceneAddressableResponse.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                g2C_CreateSubSceneAddressableResponse.SetIsPool(false);
            }
            
            return g2C_CreateSubSceneAddressableResponse;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            ErrorCode = 0;
            MessageObjectPool<G2C_CreateSubSceneAddressableResponse>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.G2C_CreateSubSceneAddressableResponse; } 
        [ProtoMember(1)]
        public uint ErrorCode { get; set; }
    }
    /// <summary>
    /// 客户端向服务器发送连接消息（Roaming）
    /// </summary>
    [Serializable]
    [ProtoContract]
    public partial class C2G_ConnectRoamingRequest : AMessage, IRequest
    {
        public static C2G_ConnectRoamingRequest Create(bool autoReturn = true)
        {
            var c2G_ConnectRoamingRequest = MessageObjectPool<C2G_ConnectRoamingRequest>.Rent();
            c2G_ConnectRoamingRequest.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2G_ConnectRoamingRequest.SetIsPool(false);
            }
            
            return c2G_ConnectRoamingRequest;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            MessageObjectPool<C2G_ConnectRoamingRequest>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2G_ConnectRoamingRequest; } 
        [ProtoIgnore]
        public G2C_ConnectRoamingResponse ResponseType { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class G2C_ConnectRoamingResponse : AMessage, IResponse
    {
        public static G2C_ConnectRoamingResponse Create(bool autoReturn = true)
        {
            var g2C_ConnectRoamingResponse = MessageObjectPool<G2C_ConnectRoamingResponse>.Rent();
            g2C_ConnectRoamingResponse.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                g2C_ConnectRoamingResponse.SetIsPool(false);
            }
            
            return g2C_ConnectRoamingResponse;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            ErrorCode = 0;
            MessageObjectPool<G2C_ConnectRoamingResponse>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.G2C_ConnectRoamingResponse; } 
        [ProtoMember(1)]
        public uint ErrorCode { get; set; }
    }
    /// <summary>
    /// 测试一个Chat漫游普通消息
    /// </summary>
    [Serializable]
    [ProtoContract]
    public partial class C2Chat_TestRoamingMessage : AMessage, IRoamingMessage
    {
        public static C2Chat_TestRoamingMessage Create(bool autoReturn = true)
        {
            var c2Chat_TestRoamingMessage = MessageObjectPool<C2Chat_TestRoamingMessage>.Rent();
            c2Chat_TestRoamingMessage.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2Chat_TestRoamingMessage.SetIsPool(false);
            }
            
            return c2Chat_TestRoamingMessage;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Tag = default;
            MessageObjectPool<C2Chat_TestRoamingMessage>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2Chat_TestRoamingMessage; } 
        [ProtoIgnore]
        public int RouteType => Fantasy.RoamingType.ChatRoamingType;
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    /// <summary>
    /// 测试一个Map漫游普通消息
    /// </summary>
    [Serializable]
    [ProtoContract]
    public partial class C2Map_TestRoamingMessage : AMessage, IRoamingMessage
    {
        public static C2Map_TestRoamingMessage Create(bool autoReturn = true)
        {
            var c2Map_TestRoamingMessage = MessageObjectPool<C2Map_TestRoamingMessage>.Rent();
            c2Map_TestRoamingMessage.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2Map_TestRoamingMessage.SetIsPool(false);
            }
            
            return c2Map_TestRoamingMessage;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Tag = default;
            MessageObjectPool<C2Map_TestRoamingMessage>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2Map_TestRoamingMessage; } 
        [ProtoIgnore]
        public int RouteType => Fantasy.RoamingType.MapRoamingType;
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    /// <summary>
    /// 测试一个Chat漫游RPC消息
    /// </summary>
    [Serializable]
    [ProtoContract]
    public partial class C2Chat_TestRPCRoamingRequest : AMessage, IRoamingRequest
    {
        public static C2Chat_TestRPCRoamingRequest Create(bool autoReturn = true)
        {
            var c2Chat_TestRPCRoamingRequest = MessageObjectPool<C2Chat_TestRPCRoamingRequest>.Rent();
            c2Chat_TestRPCRoamingRequest.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2Chat_TestRPCRoamingRequest.SetIsPool(false);
            }
            
            return c2Chat_TestRPCRoamingRequest;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Tag = default;
            MessageObjectPool<C2Chat_TestRPCRoamingRequest>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2Chat_TestRPCRoamingRequest; } 
        [ProtoIgnore]
        public Chat2C_TestRPCRoamingResponse ResponseType { get; set; }
        [ProtoIgnore]
        public int RouteType => Fantasy.RoamingType.ChatRoamingType;
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class Chat2C_TestRPCRoamingResponse : AMessage, IRoamingResponse
    {
        public static Chat2C_TestRPCRoamingResponse Create(bool autoReturn = true)
        {
            var chat2C_TestRPCRoamingResponse = MessageObjectPool<Chat2C_TestRPCRoamingResponse>.Rent();
            chat2C_TestRPCRoamingResponse.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                chat2C_TestRPCRoamingResponse.SetIsPool(false);
            }
            
            return chat2C_TestRPCRoamingResponse;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            ErrorCode = 0;
            MessageObjectPool<Chat2C_TestRPCRoamingResponse>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.Chat2C_TestRPCRoamingResponse; } 
        [ProtoMember(1)]
        public uint ErrorCode { get; set; }
    }
    /// <summary>
    /// 客户端发送一个漫游消息给Map通知Map主动推送一个消息给客户端
    /// </summary>
    [Serializable]
    [ProtoContract]
    public partial class C2Map_PushMessageToClient : AMessage, IRoamingMessage
    {
        public static C2Map_PushMessageToClient Create(bool autoReturn = true)
        {
            var c2Map_PushMessageToClient = MessageObjectPool<C2Map_PushMessageToClient>.Rent();
            c2Map_PushMessageToClient.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2Map_PushMessageToClient.SetIsPool(false);
            }
            
            return c2Map_PushMessageToClient;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Tag = default;
            MessageObjectPool<C2Map_PushMessageToClient>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2Map_PushMessageToClient; } 
        [ProtoIgnore]
        public int RouteType => Fantasy.RoamingType.MapRoamingType;
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    /// <summary>
    /// 漫游端发送一个消息给客户端
    /// </summary>
    [Serializable]
    [ProtoContract]
    public partial class Map2C_PushMessageToClient : AMessage, IRoamingMessage
    {
        public static Map2C_PushMessageToClient Create(bool autoReturn = true)
        {
            var map2C_PushMessageToClient = MessageObjectPool<Map2C_PushMessageToClient>.Rent();
            map2C_PushMessageToClient.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                map2C_PushMessageToClient.SetIsPool(false);
            }
            
            return map2C_PushMessageToClient;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Tag = default;
            MessageObjectPool<Map2C_PushMessageToClient>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.Map2C_PushMessageToClient; } 
        [ProtoIgnore]
        public int RouteType => Fantasy.RoamingType.MapRoamingType;
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    /// <summary>
    /// 测试传送漫游的触发协议
    /// </summary>
    [Serializable]
    [ProtoContract]
    public partial class C2Map_TestTransferRequest : AMessage, IRoamingRequest
    {
        public static C2Map_TestTransferRequest Create(bool autoReturn = true)
        {
            var c2Map_TestTransferRequest = MessageObjectPool<C2Map_TestTransferRequest>.Rent();
            c2Map_TestTransferRequest.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2Map_TestTransferRequest.SetIsPool(false);
            }
            
            return c2Map_TestTransferRequest;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            MessageObjectPool<C2Map_TestTransferRequest>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2Map_TestTransferRequest; } 
        [ProtoIgnore]
        public Map2C_TestTransferResponse ResponseType { get; set; }
        [ProtoIgnore]
        public int RouteType => Fantasy.RoamingType.MapRoamingType;
    }
    [Serializable]
    [ProtoContract]
    public partial class Map2C_TestTransferResponse : AMessage, IRoamingResponse
    {
        public static Map2C_TestTransferResponse Create(bool autoReturn = true)
        {
            var map2C_TestTransferResponse = MessageObjectPool<Map2C_TestTransferResponse>.Rent();
            map2C_TestTransferResponse.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                map2C_TestTransferResponse.SetIsPool(false);
            }
            
            return map2C_TestTransferResponse;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            ErrorCode = 0;
            MessageObjectPool<Map2C_TestTransferResponse>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.Map2C_TestTransferResponse; } 
        [ProtoMember(1)]
        public uint ErrorCode { get; set; }
    }
    /// <summary>
    /// 测试一个Chat发送到Map之间漫游协议
    /// </summary>
    [Serializable]
    [ProtoContract]
    public partial class C2Chat_TestSendMapMessage : AMessage, IRoamingMessage
    {
        public static C2Chat_TestSendMapMessage Create(bool autoReturn = true)
        {
            var c2Chat_TestSendMapMessage = MessageObjectPool<C2Chat_TestSendMapMessage>.Rent();
            c2Chat_TestSendMapMessage.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2Chat_TestSendMapMessage.SetIsPool(false);
            }
            
            return c2Chat_TestSendMapMessage;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Tag = default;
            MessageObjectPool<C2Chat_TestSendMapMessage>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2Chat_TestSendMapMessage; } 
        [ProtoIgnore]
        public int RouteType => Fantasy.RoamingType.ChatRoamingType;
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    /// <summary>
    /// 通知Gate服务器发送一个Route消息给Map的漫游终端
    /// </summary>
    [Serializable]
    [ProtoContract]
    public partial class C2G_TestRouteToRoaming : AMessage, IMessage
    {
        public static C2G_TestRouteToRoaming Create(bool autoReturn = true)
        {
            var c2G_TestRouteToRoaming = MessageObjectPool<C2G_TestRouteToRoaming>.Rent();
            c2G_TestRouteToRoaming.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2G_TestRouteToRoaming.SetIsPool(false);
            }
            
            return c2G_TestRouteToRoaming;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Tag = default;
            MessageObjectPool<C2G_TestRouteToRoaming>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2G_TestRouteToRoaming; } 
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    /// <summary>
    /// 通知Gate服务器发送一个漫游消息给Map的漫游终端
    /// </summary>
    [Serializable]
    [ProtoContract]
    public partial class C2G_TestRoamingToRoaming : AMessage, IMessage
    {
        public static C2G_TestRoamingToRoaming Create(bool autoReturn = true)
        {
            var c2G_TestRoamingToRoaming = MessageObjectPool<C2G_TestRoamingToRoaming>.Rent();
            c2G_TestRoamingToRoaming.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2G_TestRoamingToRoaming.SetIsPool(false);
            }
            
            return c2G_TestRoamingToRoaming;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Tag = default;
            MessageObjectPool<C2G_TestRoamingToRoaming>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2G_TestRoamingToRoaming; } 
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
}