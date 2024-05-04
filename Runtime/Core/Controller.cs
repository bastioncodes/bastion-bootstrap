using Newtonsoft.Json;
using Reflex.Attributes;
using Bastion.Serialization;

namespace Bastion.Core
{
    // TODO: Evaluate if a controller class even makes sense, it might not be necessary at all
    public abstract class Controller<TData> where TData : Data
    {
        protected TData ModelData { get; set; }
        
        [Inject] protected IJsonConverter JsonConverter { get; private set; }

        protected Controller(TData data)
        {
            ModelData = data;
        }

        public string Serialize()
        {
            if (ModelData == null)
            {
                throw new JsonException($"Cannot serialize {nameof(TData)} because the data is null.");
            }
            
            return JsonConverter.Serialize(ModelData);
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