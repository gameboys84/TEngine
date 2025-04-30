using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TEngine;
using TMPro;
using Ease = DG.Tweening.Ease;

namespace GameLogic
{
    [Window(UILayer.UI)]
    class LoadingPanel : UIWindow
    {
        private readonly int Event_LoadingDone = RuntimeId.ToRuntimeId("Loading_Done");
        
        #region 脚本工具生成的代码
        private Slider _sliderProgress;
        private TextMeshProUGUI _tmpLoadingContent;
        private TextMeshProUGUI _tmpContent1;
        private TextMeshProUGUI _tmpContent2;
        protected override void ScriptGenerator()
        {
            _sliderProgress = FindChildComponent<Slider>("m_sliderProgress");
            _tmpLoadingContent = FindChildComponent<TextMeshProUGUI>("m_tmpLoadingContent");
            _tmpContent1 = FindChildComponent<TextMeshProUGUI>("m_tmpContent1");
            _tmpContent2 = FindChildComponent<TextMeshProUGUI>("m_tmpContent2");
            _sliderProgress.onValueChanged.AddListener(OnSliderProgressChange);
        }
        #endregion

        #region 事件
        private void OnSliderProgressChange(float value)
        {
            // Debug.Log($"progress: {value}");
        }
        #endregion

        protected override void OnCreate()
        {
            base.OnCreate();

            _sliderProgress.value = 0;
            _tmpLoadingContent.text = "初始化中...";
            StartLoading().Forget();
        }

        protected override void RegisterEvent()
        {
            base.RegisterEvent();
            AddUIEvent<string>(Event_LoadingDone, OnLoadingDone);
        }

        private void OnLoadingDone(string StateName)
        {
            Log.Debug($"OnLoadingDone {StateName}");

            var newValue = 0f;
            switch (StateName)
            {
                case "CheckStep1":
                    _tmpLoadingContent.text = "正在检查资源...";
                    newValue = 0.2f;
                    break;
                case "CheckStep2":
                    _tmpLoadingContent.text = "正在加载场景...";
                    newValue = 0.5f;
                    break;
                case "CheckStep3":
                    _tmpLoadingContent.text = "正在初始化游戏...";
                    newValue = 0.64f;
                    break;
                case "CheckStep4":
                    _tmpLoadingContent.text = "正在加载角色...";
                    newValue = 0.9f;
                    break;
                case "CheckStep5":
                    _tmpLoadingContent.text = "正在进入游戏...";
                    newValue = 1f;
                    break;
                case "OnLoadingDone":
                    OnLoadingDone();
                    return;
            }
            
            DOTween.To(() => _sliderProgress.value, x => _sliderProgress.value = x, newValue, 0.5f).SetEase(Ease.InSine);
        }

        private void OnLoadingDone()
        {
            GameModule.UI.ShowUIAsync<LoginPanel>();
            Close();
        }

        private async UniTaskVoid StartLoading()
        {
            await UniTask.Delay(Random.Range(500, 2000));
            GameEvent.Send(Event_LoadingDone, "CheckStep1");
            
            await UniTask.Delay(Random.Range(500, 2000));
            GameEvent.Send(Event_LoadingDone, "CheckStep2");
            
            await UniTask.Delay(Random.Range(500, 2000));
            GameEvent.Send(Event_LoadingDone, "CheckStep3");
            
            await UniTask.Delay(Random.Range(500, 2000));
            GameEvent.Send(Event_LoadingDone, "CheckStep4");
            
            await UniTask.Delay(Random.Range(500, 2000));
            GameEvent.Send(Event_LoadingDone, "CheckStep5");
            
            GameEvent.Send(Event_LoadingDone, "OnLoadingDone");
        }
    }
}