using System;
using System.Collections.Generic;
using UnityEngine;

namespace Bastion.Serialization
{
    public class UnityJsonConverter : IJsonConverter
    {
        public string Serialize(object value, bool prettyPrint = false)
        {
            return JsonUtility.ToJson(value);
        }

        public T Deserialize<T>(string value)
        {
            return JsonUtility.FromJson<T>(value);
        }
        
        public T ParseAndDeserialize<T>(string json)
        {
            throw new NotSupportedException();
        }

        public Dictionary<string, string> DeserializeNestedObject(string json)
        {
            throw new NotSupportedException();
        }
    }
}