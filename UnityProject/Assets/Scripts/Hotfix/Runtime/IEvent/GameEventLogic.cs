using GameCore;
using TEngine;

namespace GameLogic
{
    // 使用负值是为了和RuntimeId区分开
    public enum GameEventLogicId
    {
        EVENT_LOGIC_ID_MIN = -10000000,
        
        
        EVENT_LOGIC_ID_MAX = GameEventCoreId.EVENT_CORE_ID_MIN - 1,
    }

    public static class GameEventLogic
    {
        public static readonly int Event_UIEvent = RuntimeId.ToRuntimeId("UIEvent");
        public static readonly int Event_LoadingDone = RuntimeId.ToRuntimeId("Loading_Done");
    }
    
    // [EventInterface(EEventGroup.GroupLogic)]
    // public interface ILoginUI
    // {
    //     void ShowLoginUI();
    //
    //     void CloseLoginUI();
    // }


}