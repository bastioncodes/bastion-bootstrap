using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Bastion.Serialization.Newtonsoft
{
    public class ColorConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Color color = (Color)value;
            JObject obj = new JObject
            {
                { "r", color.r },
                { "g", color.g },
                { "b", color.b },
                { "a", color.a }
            };
            obj.WriteTo(writer);
        }


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            float r = (float)obj["r"];
            float g = (float)obj["g"];
            float b = (float)obj["b"];
            float a = (float)obj["a"];
            
            return new Color(r, g, b, a);
        }


        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Color);
        }
    }

}