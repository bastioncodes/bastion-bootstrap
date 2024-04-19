using Newtonsoft.Json;
using Reflex.Attributes;
using Bastion.Serialization;

namespace Bastion.Core
{
    public abstract class Controller<TData> where TData : Data
    {
        public TData Data { get; protected set; }
        
        [Inject]
        protected IJsonConverter JsonConverter { get; private set; }

        public Controller(TData data)
        {
            Data = data;
        }

        public string Serialize()
        {
            if (Data == null)
            {
                throw new JsonException($"Cannot serialize {nameof(TData)} because the data is null.");
            }
            
            return JsonConverter.Serialize(Data);
        }

        public TData Deserialize(string data)
        {
            return JsonConverter.Deserialize<TData>(data);
        }

        public void SaveData()
        {
            // Write to file?
        }
    }
}