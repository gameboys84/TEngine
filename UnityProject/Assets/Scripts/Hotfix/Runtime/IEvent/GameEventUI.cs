using TEngine;

namespace GameLogic
{
    [EventInterface(EEventGroup.GroupUI)]
    public interface IUIRefresh
    {
        void RefreshUI();
    }
    
    [EventInterface(EEventGroup.GroupUI)]
    public interface ILocalizationChanged
    {
        void OnLocalizationChanged();
    }
}