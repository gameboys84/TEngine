using RTLTMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Launcher
{
    /// <summary>
    /// UI更新界面。
    /// </summary>
    public class LoadUpdateUI : UIBase
    {
        #region 脚本工具生成的代码

        private Image m_imgHandle;
        private GameObject m_scrollBarProgress;
        private RTLTextMeshPro m_rtlProgress;
        private RTLTextMeshPro m_rtlUpdateDesc;
        private RTLTextMeshPro m_rtlVersion;
        private RTLTextMeshPro m_rtlLabelAppid;

        protected override void ScriptGenerator()
        {
            m_scrollBarProgress = FindChild("ScrollBarProgress").gameObject;
            m_imgHandle = FindChildComponent<Image>("ScrollBarProgress/SlidingArea/m_imgHandle");
            m_rtlProgress = FindChildComponent<RTLTextMeshPro>("ScrollBarProgress/m_rtlProgress");
            m_rtlUpdateDesc = FindChildComponent<RTLTextMeshPro>("m_rtlUpdateDesc");
            m_rtlVersion = FindChildComponent<RTLTextMeshPro>("m_rtlVersion");
            m_rtlLabelAppid = FindChildComponent<RTLTextMeshPro>("m_rtlLabelAppid");
        }

        #endregion

        protected override bool FullScreen => true;

        public override void OnInit(object param)
        {
            base.OnInit(param);
            m_rtlUpdateDesc.text = param?.ToString();
            RefreshProgress(0f);
        }

        internal void RefreshProgress(float progress)
        {
            m_scrollBarProgress.gameObject.SetActive(true);
            m_imgHandle.fillAmount = progress;
            m_rtlProgress.text = progress.ToString("0%");
            // m_scrollBarProgress.size = progress;
        }

        internal void RefreshVersion(string version)
        {
            m_rtlVersion.text = version;
        }

        internal void RefreshAppid(string appid)
        {
            m_rtlLabelAppid.text = appid;
        }
    }
}