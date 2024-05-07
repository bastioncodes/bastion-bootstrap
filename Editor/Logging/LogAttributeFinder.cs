using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bastion.Logging;
using Bastion.Theme;
using UnityEditor;

namespace Bastion.Editor.Logging
{
    [Log(nameof(LogAttributeFinder), Color = Color.Sky, Channel = LogChannel.Editor)]
    public class LogAttributeFinder : EditorWindow
    {
        [MenuItem("Bastion/Debug/Discover Log Attributes")]
        public static void FindClassesWithAttribute()
        {
            BastionLogger.Log("Finding classes that are using the LogAttribute ...");
            var typesWithAttribute = new List<TypeInfo>();

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in assembly.GetTypes())
                {
                    var attribute = type.GetCustomAttribute<LogAttribute>();
                    if (attribute != null)
                    {
                        typesWithAttribute.Add(new TypeInfo
                        {
                            Type = type,
                            Attribute = attribute
                        });
                    }
                }
            }

            // Group by Channel and sort
            var groupedByChannel = typesWithAttribute
                .GroupBy(t => t.Attribute.Channel)
                .OrderBy(g => g.Key);

            foreach (var group in groupedByChannel)
            {
                // Log the channel name and the number of types in this channel
                BastionLogger.LogInfo($"Channel: {group.Key} ({group.Count()} members)");

                // Log each type in the channel
                foreach (var typeInfo in group)
                {
                    BastionLogger.Log(typeInfo.Type.FullName);
                }
            }
            
            BastionLogger.LogSuccess($"Total usages discovered: ({typesWithAttribute.Count})");
        }

        private class TypeInfo
        {
            public Type Type { get; set; }
            public LogAttribute Attribute { get; set; }
        }
    }
}
