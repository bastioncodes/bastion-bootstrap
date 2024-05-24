using System;
using System.Collections.Generic;
using Bastion.Logging;
using Newtonsoft.Json;
using UnityEngine;

namespace Bastion.Serialization.Newtonsoft
{
    /// <summary>
    /// Central registry for custom JsonConverters, facilitating the serialization of complex types.
    /// Add converters to this collection to ensure desired types are serialized correctly.
    /// </summary>
    [Serializable]
    public class JsonConverterRegistry : MonoBehaviour, IJsonConverterRegistry
    {
        public virtual List<JsonConverter> GetConverters()
        {
            return new List<JsonConverter>
            {
                new Vector2Converter(),
                new Vector3Converter(),
                new ColorConverter(),
                // Default converters can be added here
            };
        }
    }
}