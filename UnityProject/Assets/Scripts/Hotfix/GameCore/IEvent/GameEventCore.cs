using TEngine;

namespace GameCore
{
    // 使用负值是为了和RuntimeId区分开
    public enum GameEventCoreId
    {
        EVENT_CORE_ID_MIN = -10000,
        
        NETWORK_CONNECTED,
        NETWORK_DISCONNECTED,
        
        // UI_LOCALIZATION_CHANGED = 101,
        
        EVENT_CORE_ID_MAX = -1,
        
    }
    

    public static class GameEventCore
    {
        
    }

}