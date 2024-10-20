using Fantasy.Async;
using Fantasy.Entitas;
using Fantasy.Entitas.Interface;
using Fantasy.Event;
using Fantasy.Model.Authentication;
using MongoDB.Driver;

namespace Fantasy;

public sealed class OnCreateSceneEvent : AsyncEventSystem<OnCreateScene>
{
    private static long _addressableSceneRunTimeId;

    /// <summary>
    /// Handles the OnCreateScene event.
    /// </summary>
    /// <param name="self">The OnCreateScene object.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    protected override async FTask Handler(OnCreateScene self)
    {
        var scene = self.Scene;

        switch (scene.SceneType)
        {
            case SceneType.Authentication:
            {
                //用于鉴权服务器注册登录相关逻辑的组件
                scene.AddComponent<AuthenticationComponent>();
                Log.Debug("鉴权服务器启动成功");
                break;
            }
        }

        await FTask.CompletedTask;
    }
}