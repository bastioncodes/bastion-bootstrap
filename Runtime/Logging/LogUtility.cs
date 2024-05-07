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
        /// <summary>
        /// The number of stack frames to skip in order to point to the original method that invoked sending the
        /// log message. This helps to identify the correct class name prefix to be displayed in the log message.
        /// </summary>
        private const int StackFrameIndex = 3;
        
        
        private const string FallbackPrefix = "Unknown";
        
        public static string AddClassPrefix(string message, string hexColor = null)
        {
            StackTrace stackTrace = new StackTrace();

            // Get the frame representing the calling method
            // The index refers to the number of intermediate steps (method invocations) since the log call
            StackFrame frame = stackTrace.GetFrame(StackFrameIndex);
            if (frame == null) return message;
            
            // Get the method info of the calling method
            MethodBase method = frame.GetMethod();
            if (method == null) return message;
            
            // Get the declaring type of the calling method
            Type declaringType = method.DeclaringType;
            if (declaringType == null) return message;

            // If the sender object has the Loggable attribute, use it to get additional configurations for that class
            LogConfig.LogAttributeConfig logConfig = null; // LogConfig.GetLogAttributeConfig(declaringType);
            
            string prefix = $"[{declaringType.Name}] ";
            string prefixColor = hexColor;

            // Apply the log configuration
            if (logConfig != null)
            {
                prefix = $"[{logConfig.Name}] ";
                prefixColor = !string.IsNullOrEmpty(logConfig.Color) ? logConfig.Color : hexColor;
            }

            // Apply color to the prefix if defined
            if (!string.IsNullOrEmpty(prefixColor))
            {
                prefix = Colorize(prefix, prefixColor);
            }

            return prefix + message;
        }

        public static string GetPrefixFromFilePath(string filePath)
        {
            var className = ExtractClassNameFromPath(filePath);
            
            // Override config if an attribute exists for that file name
            var config = LogConfig.GetLogAttributeConfig(className);
            
            return config == null ? $"[{className}] " : Colorize($"[{config.Name}] ", config.Color);
        }
        
        private static string ExtractClassNameFromPath(string filePath)
        {
            return string.IsNullOrEmpty(filePath) ? FallbackPrefix : Path.GetFileNameWithoutExtension(filePath);
        }
        
        /// <summary>
        /// Applies color to the first 10 lines of a message to ensure correct color rendering in the Unity Editor console.
        /// This method addresses a limitation in the Unity console where long color tags across multiple lines do not render properly.
        /// The 10-line limit matches the maximum single log entry display in the Unity Editor, ensuring consistent visual output.
        /// </summary>
        /// <remarks>
        /// In the expanded log view of the Unity Editor, full text coloring works without this line-by-line tagging as tags are properly parsed.
        /// </remarks>
        /// <param name="message">The message to be colorized.</param>
        /// <param name="hexColor">The hexadecimal color code to apply to the message.</param>
        /// <returns>A colorized string where each of the first 10 lines is individually wrapped with a color tag.</returns>
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
            return hexColor == null ? message : $"<color={hexColor}>{message}</color>";
        }
    }
}