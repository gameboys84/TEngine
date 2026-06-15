using TEngine;

namespace GameLogic
{
    [EventInterface(EEventGroup.GroupLogic)]

    public interface ILoginUI
    {
        void ShowLoginUI();

        void CloseLoginUI();
    }

    [EventInterface(EEventGroup.GroupUI)]
    public interface IUIRefresh
    {
        void RefreshUI();
    }
}