using TEngine;

namespace GameLogic
{
    [EventInterface(EEventGroup.GroupUI)]
    public interface IUIRefresh
    {
        void RefreshUI();
    }
}