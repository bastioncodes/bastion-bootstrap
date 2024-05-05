using System;
using System.Collections.Generic;
using System.Reflection;

namespace Bastion.Logging
{
    public static class LogConfig
    {
        public static Dictionary<Type, LoggableInfo> LoggableTypes { get; } = new ();

        public static void Initialize()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in assembly.GetTypes())
                {
                    // Find all types that have the LoggableAttribute
                    var loggableAttribute = type.GetCustomAttribute<LoggableAttribute>();
                    if (loggableAttribute == null) continue;
                    
                    BastionLogger.LogInfo($"Loggable Attribute found ({type.Name}), caching now.");
                        
                    LoggableTypes[type] = new LoggableInfo
                    {
                        EnableLogging = loggableAttribute.Enable,
                        LogName = loggableAttribute.Name,
                        LogColor = loggableAttribute.Color,
                        LogChannel = loggableAttribute.Channel
                    };
                }
                
                /*
                foreach (var type in assembly.GetTypes())
                {
                    // Check if the type implements ILoggable
                    if (!typeof(ILoggable).IsAssignableFrom(type) || type.IsInterface || type.IsAbstract) continue;
                    if (Activator.CreateInstance(type) is not ILoggable instance) continue;
                    
                    // Cache the ILoggable data so it only needs to be reflected once
                    LoggableTypes[type] = new LoggableInfo
                    {
                        EnableLogging = instance.EnableLogging,
                        LogName = instance.LogName,
                        LogColor = instance.LogColor,
                        LogChannel = instance.LogChannel
                    };
                        
                    BastionLogger.LogWarning(instance.LogColor);
                    BastionLogger.LogWarning(instance.LogName);
                }
                */
            }
            
            BastionLogger.LogSuccess("DONE: " + LoggableTypes.Count + " items cached.");
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