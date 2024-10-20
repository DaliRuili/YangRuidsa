using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;
using UnityEngine;

namespace Hotfix.Handler
{
    public class G2C_HelloFantasyHandler : Message<G2C_HelloFantasy>
    {
        protected override async FTask Run(Session session, G2C_HelloFantasy message)
        {
            //Debug.Log();

            Log.Debug($"服务主动给我发送了消息: {message.tag}");
            await FTask.CompletedTask;
        }
    }
}