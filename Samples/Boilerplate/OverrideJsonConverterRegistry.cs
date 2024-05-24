using System.Collections.Generic;
using Bastion.Logging;
using Bastion.Serialization.Newtonsoft;
using Newtonsoft.Json;

namespace Bastion.Samples.Boilerplate
{
    public class OverrideJsonConverterRegistry : JsonConverterRegistry
    {
        public override List<JsonConverter> GetConverters()
        {
            return new List<JsonConverter>
            {
                new Vector2Converter(),
                new Vector3Converter(),
                new ColorConverter(),
            };
        }
    }
}