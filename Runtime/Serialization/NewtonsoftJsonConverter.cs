using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Bastion.Core.Extensions;

namespace Bastion.Serialization
{
    public class NewtonsoftJsonConverter : IJsonConverter
    {
        private const string JsonDataPropertyName = "data";

        public string Serialize(object value, bool prettyPrint = false)
        {
            var formatting = prettyPrint ? Formatting.Indented : Formatting.None;
            return JsonConvert.SerializeObject(value, formatting);
        }

        public T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
        
        public T ParseAndDeserialize<T>(string json)
        {
            JObject jo = JObject.Parse(json);
            JToken data = jo[JsonDataPropertyName];

            // Convert array to object since there will always be only one element
            if (data is JArray)
                data = data[0];

            return Deserialize<T>(data?.ToString());
        }

        public Dictionary<string, string> DeserializeNestedObject(string json)
        {
            JObject jsonObject = JObject.Parse(json);
            
            return FlattenNestedObject(jsonObject);
        }

        private Dictionary<string, string> FlattenNestedObject(JToken token, string prefix = "")
        {
            var result = new Dictionary<string, string>();
        
            foreach (var property in token.Children<JProperty>())
            {
                string key = string.IsNullOrEmpty(prefix) ? property.Name : prefix + "." + property.Name;
            
                if (property.Value.Type == JTokenType.Object)
                {
                    result.AddRange(FlattenNestedObject(property.Value, key));
                }
                else if (property.Value.Type == JTokenType.String)
                {
                    result[key] = (string)property.Value;
                }
            }
        
            return result;
        }
    }
}