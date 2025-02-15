using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Bastion.Theme;

namespace Bastion.Logging
{
    /// <summary>
    /// Manages the logging configurations for the application by caching the logging settings of classes marked with the <see cref="LogAttribute"/>.
    /// This class is initialized at the start of the application to collect and store configuration details from all loaded assemblies,
    /// allowing for quick retrieval during runtime without the overhead of reflection.
    /// </summary>
    [Log(nameof(LogConfig), Color = Color.Sky)]
    public static class LogConfig
    {
        /// <summary>
        /// LogAttribute ID mapping to cache their configuration data.
        /// </summary>
        /// <example>
        /// <code>
        /// // This maps the attribute data to the string "ExampleObject".
        /// [Log(nameof(ExampleObject))]
        /// public class ExampleObject : MonoBehaviour
        /// ...
        /// </code>
        /// </example>
        private static Dictionary<string, LogAttributeConfig> LogConfigs { get; } = new ();

        public static void Initialize()
        {
            // Find all types that have the LogAttribute
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in assembly.GetTypes())
                {
                    var loggableAttribute = type.GetCustomAttribute<LogAttribute>();
                    if (loggableAttribute == null) continue;
                    
                    var id = loggableAttribute.Id;
                    
                    // Skip because it's already cached
                    if (LogConfigs.ContainsKey(id))
                        continue;
                    
                    // Cache the log configuration
                    LogConfigs[id] = new LogAttributeConfig
                    {
                        Name = loggableAttribute.Name,
                        Color = loggableAttribute.Color
                    };
                }
            }

            LogAllConfigs();
        }
        
        private static void LogAllConfigs()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Discovered ({LogConfigs.Count}) log configurations.");

            foreach (var kvp in LogConfigs)
            {
                sb.AppendLine(kvp.Key);
            }

            BastionLogger.LogInfo(sb.ToString());
        }
        
        public static LogAttributeConfig GetLogAttributeConfig(string key)
        {
            LogConfigs.TryGetValue(key, out var info);
            
            return info;
        }

        public class LogAttributeConfig
        {
            public string Name { get; set; }
            public string Color { get; set; }
            // public bool Enabled { get; set; } // TODO: Implement
            // public string Channel { get; set; } // TODO: Implement
        }
    }
}