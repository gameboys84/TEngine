using UnityEngine.UI;
using System;
using RTLTMPro;
using UnityEngine;

namespace Launcher
{
    public class LoadTipsUI : UIBase
    {
#region 脚本工具生成的代码
        private RTLTextMeshPro m_rtlTitle;
        private RTLTextMeshPro m_rtlContent;
        private Button m_btnConfirm;
        private Button m_btnUpdate;
        private Button m_btnCancel;

        protected override void ScriptGenerator()
        {
            m_rtlTitle = FindChildComponent<RTLTextMeshPro>("BgImage/RectTitle/m_rtlTitle");
            m_rtlContent = FindChildComponent<RTLTextMeshPro>("BgImage/RectContent/ScrollView/Viewport/Content/m_rtlContent");
            m_btnConfirm = FindChildComponent<Button>("BgImage/ButtonGroup/m_btnConfirm");
            m_btnUpdate = FindChildComponent<Button>("BgImage/ButtonGroup/m_btnUpdate");
            m_btnCancel = FindChildComponent<Button>("BgImage/ButtonGroup/m_btnCancel");
            
            m_btnConfirm.onClick.RemoveAllListeners();
            m_btnConfirm.onClick.AddListener(OnClickConfirmBtn);
            m_btnUpdate.onClick.RemoveAllListeners();
            m_btnUpdate.onClick.AddListener(OnClickUpdateBtn);
            m_btnCancel.onClick.RemoveAllListeners();
            m_btnCancel.onClick.AddListener(OnClickCancelBtn);
        }

#endregion
        
        public Action OnConfirmClick { get; set; }
        public Action OnUpdateClick { get; set; }
        public Action OnCancelClick { get; set; }

        public override void OnInit(object data)
        {
            base.OnInit(data);
            
            m_btnUpdate.gameObject.SetActive(false);
            m_btnCancel.gameObject.SetActive(false);
            m_btnConfirm.gameObject.SetActive(false);
            
            // 将data转为 (string, string) Tuple类型
            var param = ((string, string))data;
            m_rtlTitle.text = param.Item1;
            m_rtlContent.text = param.Item2;
        }

        public void SetAllCallback(Action onConfirm, Action onUpdate, Action onCancel)
        {
            m_btnUpdate.gameObject.SetActive(false);
            m_btnCancel.gameObject.SetActive(false);
            m_btnConfirm.gameObject.SetActive(false);
            if (onConfirm != null)
            {
                OnConfirmClick = onConfirm;
                m_btnConfirm.gameObject.SetActive(true);
            }
            if (onUpdate != null)
            {
                OnUpdateClick = onUpdate;
                m_btnUpdate.gameObject.SetActive(true);
            }
            if (onCancel != null)
            {
                OnCancelClick = onCancel;
                m_btnCancel.gameObject.SetActive(true);
            }
        }

        private void OnClickUpdateBtn()
        {
            OnUpdateClick?.Invoke();
            Close();
        }

        private void OnClickCancelBtn()
        {
            OnCancelClick?.Invoke();
            Close();
        }

        private void OnClickConfirmBtn()
        {
            OnConfirmClick?.Invoke();
            Close();
        }
    }
}