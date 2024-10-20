using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;

namespace Hotfix.Outer.NormalMessage.Gate;

public class C2G_HelloFantasyRequestHandler : MessageRPC<C2G_HelloFantasyRequest,G2C_HelloFantasyResponse>
{
    protected override async FTask Run(Session session, C2G_HelloFantasyRequest request, G2C_HelloFantasyResponse response, Action reply)
    {
        Log.Debug($"客户端发来的RPC消息：{request.Tag}");
        response.Tag = "你好客户端，我是服务器，这是RPC消息的返回";
        await FTask.CompletedTask;
    }
}