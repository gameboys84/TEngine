namespace TEngine
{
    public interface ILocalSaveModule
    {
        void Save(string fileName, ILocalSaveData data, bool encrypt = false);
        T Load<T>(string fileName, bool encrypt = false) where T : ILocalSaveData, new();
    }
}