namespace TEngine
{
    /// <summary>
    /// 本地化语言。
    /// </summary>
    public enum Language : byte
    {
        /// <summary>
        /// 未指定。
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// 南非荷兰语。
        /// </summary>
        Afrikaans,

        /// <summary>
        /// 阿尔巴尼亚语。
        /// </summary>
        Albanian,

        /// <summary>
        /// 阿拉伯语。
        /// </summary>
        Arabic,

        /// <summary>
        /// 巴斯克语。
        /// </summary>
        Basque,

        /// <summary>
        /// 白俄罗斯语。
        /// </summary>
        Belarusian,

        /// <summary>
        /// 保加利亚语。
        /// </summary>
        Bulgarian,

        /// <summary>
        /// 加泰罗尼亚语。
        /// </summary>
        Catalan,

        /// <summary>
        /// 简体中文。
        /// </summary>
        ChineseSimplified,

        /// <summary>
        /// 繁体中文。
        /// </summary>
        ChineseTraditional,

        /// <summary>
        /// 克罗地亚语。
        /// </summary>
        Croatian,

        /// <summary>
        /// 捷克语。
        /// </summary>
        Czech,

        /// <summary>
        /// 丹麦语。
        /// </summary>
        Danish,

        /// <summary>
        /// 荷兰语。
        /// </summary>
        Dutch,

        /// <summary>
        /// 英语。
        /// </summary>
        English,

        /// <summary>
        /// 爱沙尼亚语。
        /// </summary>
        Estonian,

        /// <summary>
        /// 法罗语。
        /// </summary>
        Faroese,

        /// <summary>
        /// 芬兰语。
        /// </summary>
        Finnish,

        /// <summary>
        /// 法语。
        /// </summary>
        French,

        /// <summary>
        /// 格鲁吉亚语。
        /// </summary>
        Georgian,

        /// <summary>
        /// 德语。
        /// </summary>
        German,

        /// <summary>
        /// 希腊语。
        /// </summary>
        Greek,

        /// <summary>
        /// 希伯来语。
        /// </summary>
        Hebrew,

        /// <summary>
        /// 匈牙利语。
        /// </summary>
        Hungarian,

        /// <summary>
        /// 冰岛语。
        /// </summary>
        Icelandic,

        /// <summary>
        /// 印尼语。
        /// </summary>
        Indonesian,

        /// <summary>
        /// 意大利语。
        /// </summary>
        Italian,

        /// <summary>
        /// 日语。
        /// </summary>
        Japanese,

        /// <summary>
        /// 韩语。
        /// </summary>
        Korean,

        /// <summary>
        /// 拉脱维亚语。
        /// </summary>
        Latvian,

        /// <summary>
        /// 立陶宛语。
        /// </summary>
        Lithuanian,

        /// <summary>
        /// 马其顿语。
        /// </summary>
        Macedonian,

        /// <summary>
        /// 马拉雅拉姆语。
        /// </summary>
        Malayalam,

        /// <summary>
        /// 挪威语。
        /// </summary>
        Norwegian,

        /// <summary>
        /// 波斯语。
        /// </summary>
        Persian,

        /// <summary>
        /// 波兰语。
        /// </summary>
        Polish,

        /// <summary>
        /// 巴西葡萄牙语。
        /// </summary>
        PortugueseBrazil,

        /// <summary>
        /// 葡萄牙语。
        /// </summary>
        PortuguesePortugal,

        /// <summary>
        /// 罗马尼亚语。
        /// </summary>
        Romanian,

        /// <summary>
        /// 俄语。
        /// </summary>
        Russian,

        /// <summary>
        /// 塞尔维亚克罗地亚语。
        /// </summary>
        SerboCroatian,

        /// <summary>
        /// 塞尔维亚西里尔语。
        /// </summary>
        SerbianCyrillic,

        /// <summary>
        /// 塞尔维亚拉丁语。
        /// </summary>
        SerbianLatin,

        /// <summary>
        /// 斯洛伐克语。
        /// </summary>
        Slovak,

        /// <summary>
        /// 斯洛文尼亚语。
        /// </summary>
        Slovenian,

        /// <summary>
        /// 西班牙语。
        /// </summary>
        Spanish,

        /// <summary>
        /// 瑞典语。
        /// </summary>
        Swedish,

        /// <summary>
        /// 泰语。
        /// </summary>
        Thai,

        /// <summary>
        /// 土耳其语。
        /// </summary>
        Turkish,

        /// <summary>
        /// 乌克兰语。
        /// </summary>
        Ukrainian,

        /// <summary>
        /// 越南语。
        /// </summary>
        Vietnamese
    }
    
    /// <summary>
    /// LocConfig配置中的语言, 顺序与LocConfig中的语言顺序一致， 不需要的语言注释掉
    /// </summary>
    public enum LocLanguage : byte
    {
        en = 0, //英语
        cn, //简体中文
        zh, //繁体中文
        kr, //韩国
        jp, //日语
        fr, //法语
        de, //德语
        ru, //俄语
        sp, //西班牙
        po, //葡萄牙语
        it, //意大利
        nl, //荷兰语
        tr, //土耳其语
        id, //印度尼西亚
        pls, //波兰语
        thai, //泰国语
        ro, //罗马尼亚
        ar, //阿拉伯语
        vi, //越南语
        uk, //乌克兰语
        Count,
        // fa, //波斯语
        lang_none = 255
    }
}
