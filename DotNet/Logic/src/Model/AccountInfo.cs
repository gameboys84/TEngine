namespace TEngine.Logic;

/// <summary>
/// 账号信息
/// </summary>
public class AccountInfo : Entity
{
    /// <summary>
    /// 用户唯一ID。
    /// </summary>
    public uint UID { get; set; }

    /// <summary>
    /// 用户名。
    /// </summary>
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
    public string UserName { get; set; }

    /// <summary>
    /// 密码。
    /// </summary>
    public string Password { get; set; }
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
    
    /// <summary>
    /// 渠道唯一ID。
    /// </summary>
    public uint SDKUID { get; set; }
    
    /// <summary>
    /// 是否禁用账号。
    /// </summary>
    public bool Forbid { get; set; }

    public override void Dispose()
    {
        Log.Debug($"UID:{this.UID}");
        this.Parent?.Scene?.GetComponent<AccountComponent>()?.Remove(this);
        base.Dispose();
    }
}