using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TEngine;
using Ease = TEngine.Ease;

namespace GameLogic
{
	[Window(UILayer.UI, location : "LoadingPanel")]
	public partial class LoadingPanel
	{
		#region 事件

		private partial void OnSliderProgressChange(float value)
		{
		}

		#endregion
		
		
        protected override void OnCreate()
        {
            base.OnCreate();

            m_sliderProgress.value = 0;
            m_tmpLoadingContent.text = "初始化中...";
            StartLoading().Forget();
        }

        protected override void RegisterEvent()
        {
            base.RegisterEvent();
            AddUIEvent<string>(GameEventLogic.Event_LoadingDone, OnLoadingDone);
        }

        private void OnLoadingDone(string StateName)
        {
            Log.Debug($"OnLoadingDone {StateName}");

            var newValue = 0f;
            switch (StateName)
            {
                case "CheckStep1":
                    m_tmpLoadingContent.text = "正在检查资源...";
                    newValue = 0.2f;
                    break;
                case "CheckStep2":
                    m_tmpLoadingContent.text = "正在加载场景...";
                    newValue = 0.5f;
                    break;
                case "CheckStep3":
                    m_tmpLoadingContent.text = "正在初始化游戏...";
                    newValue = 0.64f;
                    break;
                case "CheckStep4":
                    m_tmpLoadingContent.text = "正在加载角色...";
                    newValue = 0.9f;
                    break;
                case "CheckStep5":
                    m_tmpLoadingContent.text = "正在进入游戏...";
                    newValue = 1f;
                    break;
                case "OnLoadingDone":
                    OnLoadingDone();
                    return;
            }
            
            DOTween.To(() => m_sliderProgress.value, x => m_sliderProgress.value = x, newValue, 0.5f).SetEase(DG.Tweening.Ease.InSine);
        }

        private void OnLoadingDone()
        {
            GameModule.UI.ShowUIAsync<GameMainPanel>();
            Close();
        }

        private async UniTaskVoid StartLoading()
        {
            await UniTask.Delay(Random.Range(200, 1000));
            GameEvent.Send(GameEventLogic.Event_LoadingDone, "CheckStep1");
            
            await UniTask.Delay(Random.Range(200, 1000));
            GameEvent.Send(GameEventLogic.Event_LoadingDone, "CheckStep2");
            
            await UniTask.Delay(Random.Range(200, 1000));
            GameEvent.Send(GameEventLogic.Event_LoadingDone, "CheckStep3");
            
            await UniTask.Delay(Random.Range(200, 1000));
            GameEvent.Send(GameEventLogic.Event_LoadingDone, "CheckStep4");
            
            await UniTask.Delay(Random.Range(1000, 2000));
            GameEvent.Send(GameEventLogic.Event_LoadingDone, "CheckStep5");

            await UniTask.Delay(Random.Range(500, 1000));
            GameEvent.Send(GameEventLogic.Event_LoadingDone, "OnLoadingDone");
        }
	}
}
