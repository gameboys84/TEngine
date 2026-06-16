using TEngine;

namespace GameLogic
{
    // TEngine的GameEventHelper.Init 没自动生成？
    public static partial class GameEventHelper
    {
        public static void InitRuntimeEvents()
        {
            var dispatcher = GameEvent.EventMgr.GetDispatcher();
            var m_ILoginUI_Gen = new ILoginUI_Gen(dispatcher);
        }
    }
}