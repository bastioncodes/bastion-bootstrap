using System.Runtime.CompilerServices;
using Bastion.Theme;
using UnityEngine;

namespace Bastion.Logging
{
    public static class BastionLogger
    {
        // Instead of those default variables, it would be nice to be able to configure them in a scriptable object
        private const string DefaultPrefixColor = null;
        private const string DefaultMessageColor = null;
        
        public static void Log(string message, string channel = LogChannel.Default, string prefixColor = null, string messageColor = null, Object context = null, [CallerFilePath] string filePath = "")
        {
            message = FormatLogMessage(message, prefixColor, messageColor, filePath);
            Debug.Log(message, context);
        }
        
        public static void LogInfo(string message, string channel = LogChannel.Default, string prefixColor = null, string messageColor = null, Object context = null, [CallerFilePath] string filePath = "")
        {
            var color = messageColor ?? ThemeColor.Blue;
            message = FormatLogMessage(message, prefixColor, color, filePath);
            Debug.Log(message, context);
        }
        
        public static void LogSuccess(string message, string channel = LogChannel.Default, string prefixColor = null, string messageColor = null, Object context = null, [CallerFilePath] string filePath = "")
        {
            var color = messageColor ?? ThemeColor.Green;
            message = FormatLogMessage(message, prefixColor, color, filePath);
            Debug.Log(message, context);
        }
        
        public static void LogWarning(string message, string channel = LogChannel.Default, string prefixColor = null, string messageColor = null, Object context = null, [CallerFilePath] string filePath = "")
        {
            var color = messageColor ?? ThemeColor.Yellow;
            message = FormatLogMessage(message, prefixColor, color, filePath);
            Debug.LogWarning(message, context);
        }
        
        public static void LogError(string message, string channel = LogChannel.Default, string prefixColor = null, string messageColor = null, Object context = null, [CallerFilePath] string filePath = "")
        {
            var color = messageColor ?? ThemeColor.Red;
            message = FormatLogMessage(message, prefixColor, color, filePath);
            Debug.LogError(message, context);
        }
        
        private static string FormatLogMessage(string message, string prefixColor = DefaultPrefixColor, string messageColor = DefaultMessageColor, string filePath = "")
        {
            if (messageColor != null)
            {
                message = LogUtility.ColorizeMultipleLines(message, messageColor);
            }

            var prefix = LogUtility.Colorize(LogUtility.GetPrefixFromFilePath(filePath), prefixColor);

            return prefix + message;
            // return LogUtility.AddClassPrefix(message, prefixColor);
        }
    }
}