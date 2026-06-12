using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasy;

public sealed class C2G_TestMessageHandler : Message<C2G_TestMessage>
{
    protected override async FTask Run(Session session, C2G_TestMessage message)
    {
        session.GetComponent<SessionIdleCheckerComponent>().Restart(1000 * 60, 5000 * 60);

        Log.Debug($"收到测试消息: {message.Tag}");

        await FTask.CompletedTask;
    }
}

public sealed class C2G_TestRequestHandler : MessageRPC<C2G_TestRequest, G2C_TestResponse>
{
    protected override async FTask Run(Session session, C2G_TestRequest request, G2C_TestResponse response, Action reply)
    {
        Log.Debug($"收到测试请求: {request.Tag}");
        response.Tag = $"这是服务器的回复: {request.Tag}";

        await FTask.CompletedTask;

    }
}
