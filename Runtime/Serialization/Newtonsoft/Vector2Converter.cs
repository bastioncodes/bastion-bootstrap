using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Bastion.Serialization.Newtonsoft
{
    public class Vector2Converter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Vector2 vector = (Vector2)value;
            JObject obj = new JObject
            {
                { "x", vector.x },
                { "y", vector.y }
            };
            obj.WriteTo(writer);
        }


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            float x = (float)obj["x"];
            float y = (float)obj["y"];
            
            return new Vector2(x, y);
        }


        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Vector2);
        }
    }
}