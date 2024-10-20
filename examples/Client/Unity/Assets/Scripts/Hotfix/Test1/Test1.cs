using System;
using System.Collections;
using System.Collections.Generic;
using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using UnityEngine;
using UnityEngine.UI;

public class Test1 : MonoBehaviour
{
    public Text Text;
    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;
    
    private Scene _scene;
    private Session _session;
    private void Start()
    {
        StartAsync().Coroutine();
    }

    private async FTask StartAsync()
    {
        // 初始化框架
        Fantasy.Platform.Unity.Entry.Initialize(GetType().Assembly);
        // 创建一个Scene，这个Scene代表一个客户端的场景，客户端的所有逻辑都可以写这里
        // 如果有自己的框架，也可以就单纯拿这个Scene做网络通讯也没问题。
        _scene = await Scene.Create(SceneRuntimeType.MainThread);
        OnConnectAddressableClick().Coroutine();
        
        // Button2.AddOnClick(() =>
        // {
        //     _session.Send(new C2G_HelloFantasy()
        //     {
        //         Tag = "你好服务器"
        //     });
        // });
        //
        // Button3.AddOnClick(() =>
        // {
        //     OnClickRPCMessageBtn().Coroutine();
        // });
    }


    private async FTask OnClickRPCMessageBtn()
    {
        var response = (G2C_HelloFantasyResponse)await _session.Call(new C2G_HelloFantasyRequest()
        {
            Tag = "你好服务器，我是客户端，这是发送的RPC消息"
        });
        Text.text = response.Tag;
        await FTask.CompletedTask;
    }

    #region Connect

    private async FTask OnConnectAddressableClick()
    {
        // 连接到Gate服务器
        _session = _scene.Connect(
            "127.0.0.1:20000",
            NetworkProtocolType.KCP,
            OnConnectComplete,
            OnConnectFail,
            OnConnectDisconnect,
            false, 5000);
    }
    
    private void OnConnectComplete()
    {
        Text.text = "连接成功";
        _session.AddComponent<SessionHeartbeatComponent>().Start(2000);
    }

    private void OnConnectFail()
    {
        Text.text = "连接失败";
    }

    private void OnConnectDisconnect()
    {
        Text.text = "连接断开";
    }

    #endregion
    
    
   
 
}
