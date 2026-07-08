using TEngine;
using UnityEngine;
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
            GameModule.Audio.Play(AudioType.Music, "music_background", true);
            GameModule.UI.ShowUIAsync<LoginPanel>();
        }
        
        private void OnDestroy()
        {
            GameModule.Audio.Stop(AudioType.Music, true);
        }
    }
}
