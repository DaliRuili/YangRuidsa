using Fantasy.Entitas;

namespace Fantasy.Authentication.Model;

public sealed class Account : Entity
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public long CreateTime { get; set; }
    
    public long LoginTime { get; set; }
}