using System.Collections.Generic;

namespace SebastianFeistl.Winky.Serialization
{
    public interface IJsonConverter
    {
        /// <summary>
        /// Serialize an object to a JSON string.
        /// </summary>
        /// <param name="value">The object to serialize.</param>
        /// <param name="prettyPrint">If true, indent the formatting of the string.</param>
        /// <returns>The serialized object.</returns>
        string Serialize(object value, bool prettyPrint = false);

        /// <summary>
        /// Deserialize an object from a JSON string.
        /// </summary>
        /// <param name="value">The serialized object.</param>
        /// <typeparam name="T">The object type.</typeparam>
        /// <returns>The deserialized object.</returns>
        T Deserialize<T>(string value);

        /// <summary>
        /// TODO: Docs
        /// </summary>
        /// <param name="json"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T ParseAndDeserialize<T>(string json);

        /// <summary>
        /// TODO: Docs
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        Dictionary<string, string> DeserializeNestedObject(string json);
    }
}