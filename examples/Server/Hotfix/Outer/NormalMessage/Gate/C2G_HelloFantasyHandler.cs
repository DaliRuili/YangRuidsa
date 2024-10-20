using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;
using Fantasy.Platform.Net;

namespace Hotfix.Outer.NormalMessage.Gate;

public class C2G_HelloFantasyHandler : Message<C2G_HelloFantasy>
{
    protected override async FTask Run(Session session, C2G_HelloFantasy message)
    {
        Log.Debug($"我收到客户端的消息：{message.Tag}");
        //session.Send(new G2C_HelloFantasy(){tag = "我是服务器，这是我主动发送过来的消息"});

        var sceneConfig = SceneConfigData.Instance.GetSceneBySceneType(SceneType.Chat);
        
        await FTask.CompletedTask;
    }
}