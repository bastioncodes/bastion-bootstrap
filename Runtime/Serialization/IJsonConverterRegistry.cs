using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bastion.Serialization
{
    public interface IJsonConverterRegistry
    {
        List<JsonConverter> GetConverters();
    }
}