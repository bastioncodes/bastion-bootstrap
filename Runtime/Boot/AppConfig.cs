using System;
using Bastion.Serialization;
using Bastion.Serialization.Newtonsoft;
using UnityEngine;

namespace Bastion.Boot
{
    [CreateAssetMenu(fileName = "New AppConfig", menuName = "Bastion/Configs/App Config")]
    public class AppConfig : ScriptableObject
    {
        private const string ResourcePath = "Configs/AppConfig";
        private static AppConfig _appConfig;
        
        [Header("Initial Scene Name (Unused)")]
        [SerializeField] private string sceneName;
        
        [Header("Serialization (Optional)")]
        [SerializeField] private JsonConverterRegistry jsonConverterRegistry;
        
        public string SceneName => sceneName;

        // If not overriden, return default JsonConverterRegistry
        public IJsonConverterRegistry JsonConverterRegistry => jsonConverterRegistry ? jsonConverterRegistry : new GameObject("_jsonConverterRegistry").AddComponent<JsonConverterRegistry>();

        public static AppConfig Load()
        {
            // Check if already cached
            if (_appConfig != null) return _appConfig;
            
            // Try to load from resources
            _appConfig = Resources.Load<AppConfig>(ResourcePath);

            if (_appConfig == null)
                throw new NullReferenceException($"{nameof(AppConfig)} could not be located at path \"{ResourcePath}\".");

            return _appConfig;
        }
    }
}