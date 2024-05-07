using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Bastion.Logging
{
    /// <summary>
    /// Manages the logging configurations for the application by caching the logging settings of classes marked with the <see cref="LogAttribute"/>.
    /// This class is initialized at the start of the application to collect and store configuration details from all loaded assemblies,
    /// allowing for quick retrieval during runtime without the overhead of reflection.
    /// </summary>
    public static class LogConfig
    {
        private static Dictionary<string, LogAttributeConfig> LoggableTypes { get; } = new ();

        public static void Initialize()
        {
            // Find all types that have the LogAttribute
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in assembly.GetTypes())
                {
                    var loggableAttribute = type.GetCustomAttribute<LogAttribute>();
                    if (loggableAttribute == null) continue;

                    string typeName = type.Name;  // Assuming type.Name matches the filename without its extension

                    if (LoggableTypes.ContainsKey(typeName))
                    {
                        BastionLogger.LogError($"Cannot cache log configuration because key \"{typeName}\" already exists.");
                        continue;
                    }
                    
                    LoggableTypes[typeName] = new LogAttributeConfig
                    {
                        Name = loggableAttribute.Name,
                        Color = loggableAttribute.Color
                    };
                }
            }
            
            LogAllConfigurations();
        }
        
        private static void LogAllConfigurations()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Cached log configurations:");

            foreach (var kvp in LoggableTypes)
            {
                sb.AppendLine($"Discovered: {kvp.Key}");
            }

            BastionLogger.LogInfo(sb.ToString());
        }
        
        public static LogAttributeConfig GetLogAttributeConfig(string key)
        {
            LoggableTypes.TryGetValue(key, out var info);
            
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