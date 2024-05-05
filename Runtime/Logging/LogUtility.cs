using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using Debug = UnityEngine.Debug;

namespace Bastion.Logging
{
    public static class LogUtility
    {
        public static string AddClassPrefix(string message, string color = null)
        {
            StackTrace stackTrace = new StackTrace();

            // Get the frame representing the calling method
            // The index refers to the number of intermediate steps (method invocations) since the log call
            StackFrame frame = stackTrace.GetFrame(3);
            if (frame == null) return message;
            
            // Get the method info of the calling method
            MethodBase method = frame.GetMethod();
            if (method == null) return message;
            
            // Get the declaring type of the calling method
            Type declaringType = method.DeclaringType;
            if (declaringType == null) return message;

            // If the sender object has the Loggable attribute, use it to get additional configurations for that class
            var loggableInfo = LogConfig.GetLoggableInfo(declaringType);
            
            string prefix = $"[{declaringType.Name}] ";
            string prefixColor = color;

            if (loggableInfo is { EnableLogging: true })
            {
                prefix = $"[{loggableInfo.LogName}] ";
                prefixColor = !string.IsNullOrEmpty(loggableInfo.LogColor) ? loggableInfo.LogColor : color;
            }

            // Apply color to the prefix if defined
            if (!string.IsNullOrEmpty(prefixColor))
            {
                prefix = Colorize(prefix, prefixColor);
            }

            return prefix + message;
        }
        
        public static string ColorizeMultipleLines(string message, string hexColor)
        {
            string[] lines = message.Split('\n');
            int maxLines = 10;
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < lines.Length; i++)
            {
                if (i < maxLines)
                {
                    builder.AppendLine(Colorize(lines[i], hexColor));
                }
                else
                {
                    // Start appending the rest to a new StringBuilder to colorize them all at once
                    StringBuilder remainingLines = new StringBuilder();
                    for (; i < lines.Length; i++)
                    {
                        remainingLines.AppendLine(lines[i]);
                    }
                    builder.Append(Colorize(remainingLines.ToString(), hexColor));
                    break;
                }
            }

            return builder.ToString();
        }
        
        public static string Colorize(string message, string hexColor)
        {
            return $"<color={hexColor}>{message}</color>";
        }
    }
}