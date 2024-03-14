using System.Runtime.Serialization;
using Reflex.Attributes;
using SebastianFeistl.Winky.Logging;
using SebastianFeistl.Winky.Serialization;
using SebastianFeistl.Winky.Storage;

namespace SebastianFeistl.Winky.Core
{
    [DataContract]
    public abstract class Data : ILoggable
    {
        [Inject] protected IJsonConverter JsonConverter;
        [Inject] protected FileManager FileManager;
        
        public string ToJson(bool prettyPrint = false)
        {
            return JsonConverter.Serialize(this, prettyPrint);
        }
        
        public void SaveToFile(string fileName, bool prettyPrint = false)
        {
            var data = ToJson(prettyPrint);
            FileManager.SaveFile(fileName, data);
        }

        public void LoadFromFile<T>(string fileName) where T : Data
        {
            var data = FileManager.ReadFile(fileName);
            FromJson<T>(data);
        }

        public T FromJson<T>(string data) where T : Data
        {
            return JsonConverter.Deserialize<T>(data);
        }
    }
}