using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Bastion.Serialization.Newtonsoft
{
    public class Vector3Converter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Vector3 vector = (Vector3)value;
            JObject obj = new JObject
            {
                { "x", vector.x },
                { "y", vector.y },
                { "z", vector.z }
            };
            obj.WriteTo(writer);
        }


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            float x = (float)obj["x"];
            float y = (float)obj["y"];
            float z = (float)obj["z"];
            
            return new Vector3(x, y, z);
        }


        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Vector3);
        }
    }
}