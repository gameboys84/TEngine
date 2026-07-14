using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using YooAsset;

namespace TEngine
{
    public class SpriteAtlasLoader : MonoBehaviour
    {
        private Dictionary<string, SpriteAtlas> _loadedAtlas = new Dictionary<string, SpriteAtlas>(1000);
        private List<AssetHandle> _loadHandles = new List<AssetHandle>(1000);
        
        private IResourceModule _resourceModule;

        public void Awake()
        {
            SpriteAtlasManager.atlasRequested += RequestAtlas;
            _resourceModule = ModuleSystem.GetModule<IResourceModule>();
        }
        public void OnDestroy()
        {
            SpriteAtlasManager.atlasRequested -= RequestAtlas;
            foreach (var atlas in _loadedAtlas.Values)
            {
                Destroy(atlas);
            }
            _loadedAtlas.Clear();
            
            foreach (var handle in _loadHandles)
            {
                handle.Release();
            }
            _loadHandles.Clear();
        }

        private void RequestAtlas(string atlasName, Action<SpriteAtlas> callback)
        {
            Log.Debug($"SpriteAtlasLoader, RequestAtlas : {atlasName} !");
            
            if (_loadedAtlas.TryGetValue(atlasName, out var value))
            {
                callback.Invoke(value);
            }
            else
            {
                var loadHandle = _resourceModule.LoadAssetAsyncHandle<SpriteAtlas>(atlasName);
                loadHandle.Completed += handle =>
                {
                    var atlas = handle.AssetObject as SpriteAtlas;
                    _loadedAtlas.Add(atlasName, atlas);
                    _loadHandles.Add(loadHandle);
                    callback.Invoke(atlas);
                };
            }
        }
    }
}
