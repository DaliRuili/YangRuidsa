using Fantasy.Async;
using Fantasy.Authentication;
using Fantasy.Authentication.Model;
using Fantasy.Entitas;
using Fantasy.Helper;

namespace Fantasy.Outer.Authentication;

public static class AuthenticationComponentSystem
{
    /// <summary>
    /// 鉴权注册接口
    /// </summary>
    /// <param name="self"></param>
    /// <param name="username"></param>
    /// <param name="password"></param>
    public static async FTask<uint> Register(this AuthenticationComponent self ,string username,string password)
    {
        Log.Debug("");
        if (string.IsNullOrEmpty(username)&& string.IsNullOrEmpty(password))
        {
            //验证账号秘书是否合理
            return 1;
        }
        
        //查询数据库
        var wordDataBase = self.Scene.World.DateBase;
        var isExist = await wordDataBase.Exist<Account>(d=>d.UserName==username);
        if (isExist)
        {
            //这个账号在数据库中已存在
            return 2;
        }


        var account = Entity.Create<Account>(self.Scene, true, true);
        account.UserName = username;
        account.Password = password;
        account.CreateTime = TimeHelper.Now;
        await wordDataBase.Save(account);
        return 0;
    }
}