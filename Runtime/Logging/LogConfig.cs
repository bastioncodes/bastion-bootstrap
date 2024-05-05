using System;
using System.Collections.Generic;
using System.Reflection;
namespace Bastion.Logging
{
    public static class LogConfig
    {
        private static Dictionary<Type, LoggableInfo> LoggableTypes { get; } = new ();

        public static void Initialize()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in assembly.GetTypes())
                {
                    // Find all types that have the LoggableAttribute
                    var loggableAttribute = type.GetCustomAttribute<LoggableAttribute>();
                    if (loggableAttribute == null) continue;
                    
                    BastionLogger.LogInfo($"Loggable Attribute found ({type.FullName}), caching now.");
                        
                    LoggableTypes[type] = new LoggableInfo
                    {
                        EnableLogging = loggableAttribute.Enable,
                        LogName = loggableAttribute.Name,
                        LogColor = loggableAttribute.Color,
                        LogChannel = loggableAttribute.Channel
                    };
                }
            }
            
            BastionLogger.LogSuccess("DONE: " + LoggableTypes.Count + " items cached.");
        }
        
        public static LoggableInfo GetLoggableInfo(Type type)
        {
            LoggableTypes.TryGetValue(type, out var info);
            
            return info;
        }

        public class LoggableInfo
        {
            public bool EnableLogging { get; set; }
            public string LogName { get; set; }
            public string LogColor { get; set; }
            public string LogChannel { get; set; }
        }
    }
}