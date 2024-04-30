using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Bastion.Logging
{
    public static class LogUtility
    {
        public static string AddClassPrefix(string message, string color)
        {
            StackTrace stackTrace = new StackTrace();

            // Get the frame representing the calling method
            StackFrame frame = stackTrace.GetFrame(2);

            if (frame != null)
            {
                // Get the method info of the calling method
                MethodBase method = frame.GetMethod();

                if (method != null)
                {
                    // Get the declaring type of the calling method
                    Type declaringType = method.DeclaringType;

                    if (declaringType != null)
                    {
                        // Construct the prefix using the class type
                        string classPrefix = Colorize($"[{declaringType.Name}]", color) + " ";

                        // Add the class prefix to the message
                        message = classPrefix + message;
                    }
                }
            }

            return message;
        }
        
        public static string Colorize(string message, string hexColor)
        {
            return $"<color={hexColor}>{message}</color>";
        }
        
        public static string FormatMessage(string message, ILoggable loggable, string hexColor, string filePath, int lineNumber)
        {
            if (hexColor != string.Empty)
                message = Colorize(message, hexColor);
            
            var name = $"[{loggable.GetName()}]";
            var fileName = Path.GetFileName(filePath);
            message += "\n" + CreateLinkToCodeLine($"[{fileName}:{lineNumber}]", filePath, lineNumber);

            return $"{Colorize(name, loggable.LogColor)} {message}";
        }

        private static string CreateLinkToCodeLine(string name, string filePath, int lineNumber)
        {
            return $"<a href=\"{filePath}\" line=\"{lineNumber}\">{name}</a>";
        }
    }
}