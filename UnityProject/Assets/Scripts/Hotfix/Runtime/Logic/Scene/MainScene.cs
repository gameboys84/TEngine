using System;
using TEngine;
using UnityEngine;
using UnityEngine.U2D;
using AudioType = TEngine.AudioType;

namespace GameLogic
{
    public class MainScene : MonoBehaviour
    {
        private void Awake()
        {
            // GameModule.Localization.LoadLanguageTotalAsset("Common_text.csv");
            StringManager.Instance.Active();
        }

        // Start is called before the first frame update
        void Start()
        {
            // SpriteAtlasManager.atlasRequested += OnRequestAtlas;
            GameModule.Audio.Play(AudioType.Music, "music_background", true);
            GameModule.UI.ShowUIAsync<LoginPanel>();
        }
        
        // private async void OnRequestAtlas(string atlasName, Action<SpriteAtlas> callback)
        // {
        //     Log.Debug($"OnRequestAtlas, atlasName:{atlasName}");
        //
        //     var resourceModule = ModuleSystem.GetModule<IResourceModule>();
        //     var atlas = await resourceModule.LoadAssetAsync<SpriteAtlas>(atlasName);
        //     callback(atlas);
        // }



        
        private void OnDestroy()
        {
            // SpriteAtlasManager.atlasRequested -= OnRequestAtlas;
            GameModule.Audio.Stop(AudioType.Music, true);
        }
    }
}
