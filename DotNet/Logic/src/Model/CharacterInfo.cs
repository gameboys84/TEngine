namespace TEngine.Logic;

public class CharacterInfoAwakeSystem : AwakeSystem<CharacterInfo>
{
    protected override void Awake(CharacterInfo self)
    {
        self.Awake();
    }
}

/// <summary>
/// 角色信息。
/// </summary>
public class CharacterInfo : Entity
{
    //昵称
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
    public string UserName { get; set; }
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。

    //等级
    public int Level { get; set; }

    //余额
    public long Money { get; set; }


    //上次游戏角色序列 1/2/3
    public int LastPlay { get; set; }

    //public List<Ca>
    public void Awake()
    {
        UserName = string.Empty;
        Level = 1;
        Money = 10000;
        LastPlay = 0;
    }

}