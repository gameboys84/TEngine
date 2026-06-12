using System;
using System.IO;
using System.Text;

namespace TEngine
{
    public class LocalSaveModule : Module, ILocalSaveModule
    {
        private Utility.OptimizedAES defaultAES;
        private readonly string defaultKey = "gameboys84";
        private readonly string defaultIv = "LocalSaveModule";
        
        public override void OnInit()
        {
            defaultAES = new Utility.OptimizedAES(defaultKey, defaultIv);
        }
        
        public override void Shutdown()
        {
            defaultAES = null;
        }

        /// <summary>
        /// 将数据保存到本地，支持加密保存
        /// </summary>
        /// <param name="fileName">保存文件名</param>
        /// <param name="data">保存数据 </param>
        /// <param name="encrypt">是否加密</param>
        public void Save(string fileName, ILocalSaveData data, bool encrypt = false)
        {
            string filePath = Utility.FileUtils.GetDocDataPath("LocalSave");
            filePath = Path.Combine(filePath, fileName);
            
            string strData = data.Serialize();

            if (encrypt)
            {
                string encryptedStr = Utility.Encryption.AES_Encrypt(strData, defaultAES);
                Utility.FileTools.SafeWriteAllText(filePath, encryptedStr);
            }
            else
            {
                Utility.FileTools.SafeWriteAllText(filePath, strData);
            }
        }

        /// <summary>
        /// 加载文本数据，如果加载失败，会删除文件并返回默认值
        /// </summary>
        /// <param name="fileName">加载文件名</param>
        /// <param name="encrypt">是否加密</param>
        /// <typeparam name="T">数据格式类型</typeparam>
        /// <returns></returns>
        public T Load<T>(string fileName, bool encrypt = false) where T : ILocalSaveData, new()
        {
            string filePath = Utility.FileUtils.GetDocDataPath("LocalSave");
            filePath = Path.Combine(filePath, fileName);
            
            try
            {
                string strData;
                if (encrypt)
                {
                    strData = Utility.FileTools.SafeReadAllText(filePath);
                    strData = Utility.Encryption.AES_Decrypt(strData, defaultAES);
                }
                else
                {
                    strData = Utility.FileTools.SafeReadAllText(filePath);
                }

                if (string.IsNullOrEmpty(strData))
                {
                    return default(T);
                }

                T data = new T();
                data.Deserialize(strData);
                
                return data;
            }
            catch (Exception e)
            {
                Log.Error($"LocalSaveModule Load and serialize: {filePath} error: {e.Message}");
                
                // 加载失败，是否删除源文件
                // Utility.FileTools.SafeDeleteFile(filePath);
            }
            
            return default(T);
        }
    }
}