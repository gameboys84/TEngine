using Cysharp.Threading.Tasks;
using GameLogic;
using TEngine;

public class MainSceneSystem : Singleton<MainSceneSystem>
{
    protected override void OnInit()
    {
        base.OnInit();
        
        Log.Info("MainSceneSystem Init");
    }

    public override void Active()
    {
        base.Active();
        
        GameModule.Audio.Play(AudioType.Music, "music_background", true);
        
        Log.Info("MainSceneSystem Active");
    }

    public override void Release()
    {
        base.Release();
        
        GameModule.Audio.Stop(AudioType.Music, true);
        
        Log.Info("MainSceneSystem Release");
    }

    // public async UniTaskVoid LoadScene()
    // {
    //     await UniTask.Yield();
    //
    //     GameModule.Audio.Play(AudioType.Music, "music_background", true);
    //     
    //     GameModule.UI.ShowUIAsync<UIMainWindow>();
    //     
    //     // GameEvent.AddEventListener(GameEventType.ExitGame, OnExitGame);
    // }

    // public void DestroyScene()
    // {
    //     GameModule.Audio.Stop(AudioType.Music, true);
    //     
    //     GameModule.UI.CloseUI<UIMainWindow>();
    //     
    //     // GameEvent.RemoveEventListener(GameEventType.ExitGame, OnExitGame);
    // }
}
