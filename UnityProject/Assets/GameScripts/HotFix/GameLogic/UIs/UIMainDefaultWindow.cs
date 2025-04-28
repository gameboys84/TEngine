using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TEngine;

namespace GameLogic
{
    [Window(UILayer.UI)]
    class UIMainDefaultWindow : UIWindow
    {
        #region 脚本工具生成的代码
        private TextMeshProUGUI m_tmpTxtVersion;
        private Button m_btnVersion;
        private Button m_btnQuit;
        private TextMeshProUGUI m_tmpTxtTitle;
        private Button m_btnTest;
        private Button m_btnTestImage;
        private RawImage m_rawRawImage;
        private Image m_imgImage;
        private GameObject m_goScrollView;
        private GameObject m_itemScrollItem;
        // private TMP_InputField m_tmpInputTitle;
        protected override void ScriptGenerator()
        {
            m_tmpTxtVersion = FindChildComponent<TextMeshProUGUI>("UITopRight/m_tmpTxtVersion");
            m_btnVersion = FindChildComponent<Button>("UITopRight/m_btnVersion");
            m_btnQuit = FindChildComponent<Button>("UIPanel/m_btnQuit");
            m_tmpTxtTitle = FindChildComponent<TextMeshProUGUI>("UIPanel/m_tmpTxtTitle");
            m_btnTest = FindChildComponent<Button>("UIPanel/m_btnTest");
            m_btnTestImage = FindChildComponent<Button>("UIPanel/m_btnTestImage");
            m_rawRawImage = FindChildComponent<RawImage>("UIPanel/m_rawRawImage");
            m_imgImage = FindChildComponent<Image>("UIPanel/m_imgImage");
            m_goScrollView = FindChild("UIPanel/m_goScrollView").gameObject;
            m_itemScrollItem = FindChild("UIPanel/m_goScrollView/Viewport/Content/m_itemScrollItem").gameObject;
            // m_tmpInputTitle = FindChildComponent<TMP_InputField>("UIPanel/m_tmpInputTitle");
            m_btnVersion.onClick.AddListener(OnClickVersionBtn);
            m_btnQuit.onClick.AddListener(OnClickQuitBtn);
            m_btnTest.onClick.AddListener(OnClickTestBtn);
            m_btnTestImage.onClick.AddListener(OnClickTestImageBtn);
        }
        #endregion

        #region 事件
        private void OnClickVersionBtn()
        {
            string version1 = $"{GameModule.Resource.DefaultPackageName}_{GameModule.Resource.PackageVersion}";
            string version2 = $"{GameModule.Resource.ApplicableGameVersion}_{GameModule.Resource.InternalResourceVersion}";
            m_tmpTxtVersion.text = $"Version: {Application.version}, {version1}, {version2}";
        }
        private void OnClickQuitBtn()
        {
            GameModule.UI.CloseUI<UIMainDefaultWindow>();
        }
        private void OnClickTestBtn()
        {
            // LoopGridView scrollView = m_goScrollView.GetComponent<ScrollRect>().content.GetComponent<LoopGridView>();
            
            Transform content = m_goScrollView.GetComponent<ScrollRect>().content;
            int count = content.childCount;
            for (int i = 0; i < 10; i++)
            {
                GameObject item = GameObject.Instantiate(m_itemScrollItem, content);
                item.SetActive(true);
                ScrollItem scrollItem = item.GetComponent<ScrollItem>();
                scrollItem.itemName = $"Item {count + i}";
                item.name = scrollItem.getName();
                scrollItem.img.sprite = GameModule.Resource.LoadAsset<Sprite>($"Assets/AssetRaw/Texture/SpriteImage/Atlas/Icon/Skill_{i%4+1}.png");
                Log.Info($"itemName: {scrollItem.getName()}");
            }
        }
        private void OnClickTestImageBtn()
        {
            // 从1-4随机
            int rndIdx = Random.Range(1, 5);
            m_rawRawImage.texture = GameModule.Resource.LoadAsset<Texture>($"Assets/AssetRaw/Texture/RawImage/Head_{rndIdx}.png");
            m_imgImage.sprite = GameModule.Resource.LoadAsset<Sprite>($"Assets/AssetRaw/Texture/SpriteImage/Raw/RAW_{rndIdx}.png");
        }
        #endregion

        protected override void OnCreate()
        {
            base.OnCreate();
            // m_tmpInputTitle.onEndEdit.AddListener(OnInputTitleEndEdit);
            
            m_tmpTxtTitle.text = "MainDefaultWindow";
        }

        private void OnInputTitleEndEdit(string txt)
        {
            m_tmpTxtTitle.text = txt;
        }
    }
}