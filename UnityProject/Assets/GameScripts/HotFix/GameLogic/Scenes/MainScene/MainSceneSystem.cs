using Cysharp.Threading.Tasks;
using GameLogic;
using TEngine;

[Update]
public class MainSceneSystem : BehaviourSingleton<MainSceneSystem>
{
    public async UniTaskVoid LoadScene()
    {
        await UniTask.Yield();

        GameModule.Audio.Play(AudioType.Music, "music_background", true);
        
        GameModule.UI.ShowUIAsync<UIMainWindow>();
        
        // GameEvent.AddEventListener(GameEventType.ExitGame, OnExitGame);
    }

    public void DestroyScene()
    {
        GameModule.Audio.Stop(AudioType.Music, true);
        
        GameModule.UI.CloseUI<UIMainWindow>();
        
        // GameEvent.RemoveEventListener(GameEventType.ExitGame, OnExitGame);
    }

    public override void Update()
    {
        
    }
}
