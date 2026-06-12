using UnityEngine;
using UnityEngine.UI;
using TEngine;
using TMPro;

namespace GameLogic
{
    [Window(UILayer.UI)]
    class GameMainPanel : UIWindow
    {
        #region 脚本工具生成的代码
        private Slider _sliderHP;
        private TextMeshProUGUI _tmpName;
        private Image _imgHead;
        protected override void ScriptGenerator()
        {
            _sliderHP = FindChildComponent<Slider>("m_sliderHP");
            _tmpName = FindChildComponent<TextMeshProUGUI>("m_tmpName");
            _imgHead = FindChildComponent<Image>("m_imgHead");
            _sliderHP.onValueChanged.AddListener(OnSliderHPChange);
        }
        #endregion

        #region 事件
        private void OnSliderHPChange(float value)
        {
        }
        #endregion

    }
}