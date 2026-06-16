using TEngine;

namespace GameLogic
{
    public enum GameEventLogicId
    {
        EVENT_LOGIC_ID_MIN = GameEventCoreId.EVENT_CORE_ID_MAX + 1,
    }

    public static class GameEventLogic
    {
        public static readonly int Event_UIEvent = RuntimeId.ToRuntimeId("UIEvent");
        public static readonly int Event_LoadingDone = RuntimeId.ToRuntimeId("Loading_Done");
    }
    
    [EventInterface(EEventGroup.GroupLogic)]
    public interface ILoginUI
    {
        void ShowLoginUI();

        void CloseLoginUI();
    }


}