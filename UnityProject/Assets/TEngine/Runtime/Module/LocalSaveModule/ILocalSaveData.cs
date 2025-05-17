namespace TEngine
{
    public interface ILocalSaveData
    {
        /// <summary>
        /// 将字串反序列化成对象
        /// </summary>
        /// <param name="objString"></param>
        void Deserialize(string objString);
        
        /// <summary>
        /// 将对象序列化成字串
        /// </summary>
        /// <returns></returns>
        string Serialize();
    }
}