using UnityEngine;

namespace TEngine
{
    public class LocalSaveDataBase : ILocalSaveData
    {
        public string Version = "1.0";
        
        public void Deserialize(string objString)
        {
            JsonUtility.FromJsonOverwrite(objString, this);
        }

        public string Serialize()
        {
            return JsonUtility.ToJson(this);
        }
    }
}