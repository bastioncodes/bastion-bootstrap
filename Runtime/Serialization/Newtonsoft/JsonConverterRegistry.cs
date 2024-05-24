using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Bastion.Serialization.Newtonsoft
{
    /// <summary>
    /// Central registry for custom JsonConverters, facilitating the serialization of complex types.
    /// Add converters to this collection to ensure desired types are serialized correctly.
    /// </summary>
    public class JsonConverterRegistry
    {
        public List<JsonConverter> Converters { get; } = new ()
        {
            new Vector2Converter(),
            new Vector3Converter(),
            new ColorConverter(),
            // Add additional converters here
        };
    }
}