using System.Runtime.Serialization;
using Reflex.Attributes;
using Bastion.Serialization;
using Bastion.Storage;
using Reflex.Injectors;

namespace Bastion.Core
{
    /// <summary>
    /// Provides a base class for stateful data objects that support JSON serialization and file storage operations
    /// out of the box.
    /// </summary>
    /// <remarks>
    /// Essential dependencies, such as <see cref="IJsonConverter"/> and <see cref="FileManager"/>, are injected
    /// and readily available to derived classes, facilitating seamless serialization and file management.
    /// </remarks>
    [DataContract]
    public abstract class Data
    {
        [Inject] protected IJsonConverter JsonConverter;
        [Inject] protected FileManager FileManager;
        
        /// <summary>
        /// Serializes the current object to a JSON string.
        /// </summary>
        /// <param name="prettyPrint">Specifies whether to beautify the resulting JSON string.</param>
        /// <returns>A JSON string representation of the current object.</returns>
        public string ToJson(bool prettyPrint = false)
        {
            return JsonConverter.Serialize(this, prettyPrint);
        }

        /// <summary>
        /// Saves the current object to a file as a JSON string.
        /// </summary>
        /// <param name="fileName">The file name to save the JSON data to.</param>
        /// <param name="prettyPrint">Specifies whether to beautify the resulting JSON string.</param>
        public void SaveToFile(string fileName, bool prettyPrint = false)
        {
            var data = ToJson(prettyPrint);
            FileManager.SaveFile(fileName, data);
        }

        /// <summary>
        /// Loads data from a file and updates the current object's state.
        /// </summary>
        /// <typeparam name="T">The type of data object to be loaded.</typeparam>
        /// <param name="fileName">The file name from which to load the JSON data.</param>
        public static T LoadFromFile<T>(string fileName) where T : Data
        {
            var fileManager = ServiceLocator.Find<FileManager>();
            var data = fileManager.ReadFile(fileName);
            
            return FromJson<T>(data);
        }

        /// <summary>
        /// Deserializes a JSON string into an object of model type, ensuring that any necessary dependencies
        /// are injected into the newly created object.
        /// </summary>
        /// <param name="data">The JSON string to deserialize.</param>
        /// <typeparam name="T">The type of data object to deserialize into.</typeparam>
        /// <returns>An instance of model type populated with data from the JSON string and with dependencies injected.</returns>
        public static T FromJson<T>(string data) where T : Data
        {
            var jsonConverter = ServiceLocator.Find<IJsonConverter>();
            var instance = jsonConverter.Deserialize<T>(data);
            
            AttributeInjector.Inject(instance, ServiceLocator.Container);
            
            return instance;
        }
    }
}