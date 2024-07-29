//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;


namespace GameConfig.Battle
{
   
public partial class TbSkill
{
    private readonly Dictionary<int, Battle.SkillBaseConfig> _dataMap;
    private readonly List<Battle.SkillBaseConfig> _dataList;
    
    public TbSkill(ByteBuf _buf)
    {
        _dataMap = new Dictionary<int, Battle.SkillBaseConfig>();
        _dataList = new List<Battle.SkillBaseConfig>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            Battle.SkillBaseConfig _v;
            _v = Battle.SkillBaseConfig.DeserializeSkillBaseConfig(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }

    public Dictionary<int, Battle.SkillBaseConfig> DataMap => _dataMap;
    public List<Battle.SkillBaseConfig> DataList => _dataList;

    public Battle.SkillBaseConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Battle.SkillBaseConfig Get(int key) => _dataMap[key];
    public Battle.SkillBaseConfig this[int key] => _dataMap[key];

    public void Resolve(Dictionary<string, object> _tables)
    {
        foreach(var v in _dataList)
        {
            v.Resolve(_tables);
        }
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        foreach(var v in _dataList)
        {
            v.TranslateText(translator);
        }
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}