using Bastion.Core;
using Bastion.Serialization;
using Bastion.Serialization.Newtonsoft;
using UnityEngine;

namespace Bastion.Boot
{
    [CreateAssetMenu(fileName = nameof(AppConfig), menuName = "Bastion/Configs/AppConfig")]
    public class AppConfig : Config
    {
        [Header("Serialization (Optional)")]
        [SerializeField] private JsonConverterRegistry jsonConverterRegistry;

        // If not overriden, return default JsonConverterRegistry
        public IJsonConverterRegistry JsonConverterRegistry => jsonConverterRegistry ? jsonConverterRegistry : new GameObject("_jsonConverterRegistry").AddComponent<JsonConverterRegistry>();

        private static AppConfig _appConfig;
        
        public static AppConfig Load()
        {
            if (_appConfig != null) return _appConfig;
            _appConfig = Config.Load<AppConfig>();
            
            return _appConfig;
        }
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            // if (jsonConverterRegistry == null) LogMissingInspectorAssignment(nameof(jsonConverterRegistry));
        }
#endif
    }
}