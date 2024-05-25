using System.Collections.Generic;
using Bastion.Serialization.Newtonsoft;
using Newtonsoft.Json;

namespace Bastion.Samples.Entrypoint
{
    public class JsonConverterRegistry : Serialization.Newtonsoft.JsonConverterRegistry
    {
        public override List<JsonConverter> GetConverters()
        {
            return new List<JsonConverter>
            {
                new Vector2Converter(),
                new Vector3Converter(),
                new ColorConverter(),
                // Add custom converters
            };
        }
    }
}