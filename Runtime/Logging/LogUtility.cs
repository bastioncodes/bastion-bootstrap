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
            
            // TODO: Use declaringType to cache prefix in dictionary 
            
            // Construct the prefix using the class type
            string prefix = $"[{declaringType.Name}] ";
                        
            if (color != null)
            {
                prefix = Colorize(prefix, color);
            }

            // Add the class prefix to the message
            message = prefix + message;

            return message;
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