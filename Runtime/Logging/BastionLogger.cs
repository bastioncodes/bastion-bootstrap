using System.Runtime.CompilerServices;
using Bastion.Theme;
using UnityEngine;

namespace Bastion.Logging
{
    public static class BastionLogger
    {
        public static void Log(string message, string channel = LogChannel.Default, string prefixColor = null, string messageColor = null, Object context = null, LogLevel logLevel = LogLevel.Default, [CallerFilePath] string filePath = "")
        {
            LogMessage(message, channel, prefixColor, messageColor, context, logLevel, filePath);
        }
        
        public static void LogInfo(string message, string channel = LogChannel.Default, string prefixColor = null, string messageColor = null, Object context = null, LogLevel logLevel = LogLevel.Info, [CallerFilePath] string filePath = "")
        {
            var color = messageColor ?? ThemeColor.Blue;
            LogMessage(message, channel, prefixColor, color, context, logLevel, filePath);
        }
        
        public static void LogSuccess(string message, string channel = LogChannel.Default, string prefixColor = null, string messageColor = null, Object context = null, LogLevel logLevel = LogLevel.Success, [CallerFilePath] string filePath = "")
        {
            var color = messageColor ?? ThemeColor.Green;
            LogMessage(message, channel, prefixColor, color, context, logLevel, filePath);
        }
        
        public static void LogWarning(string message, string channel = LogChannel.Default, string prefixColor = null, string messageColor = null, Object context = null, LogLevel logLevel = LogLevel.Warning, [CallerFilePath] string filePath = "")
        {
            var color = messageColor ?? ThemeColor.Yellow;
            LogMessage(message, channel, prefixColor, color, context, logLevel, filePath);
        }
        
        public static void LogError(string message, string channel = LogChannel.Default, string prefixColor = null, string messageColor = null, Object context = null, LogLevel logLevel = LogLevel.Error, [CallerFilePath] string filePath = "")
        {
            var color = messageColor ?? ThemeColor.Red;
            LogMessage(message, channel, prefixColor, color, context, logLevel, filePath);
        }
        
        private static void LogMessage(string message, string channel, string prefixColor, string messageColor, Object context,  LogLevel logLevel, string filePath)
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            string formattedMessage = FormatLogMessage(message, prefixColor, messageColor, filePath);
            switch (logLevel)
            {
                case LogLevel.Info:
                    Debug.Log(formattedMessage, context);
                    break;
                case LogLevel.Success:
                    Debug.Log(formattedMessage, context);
                    break;
                case LogLevel.Warning:
                    Debug.LogWarning(formattedMessage, context);
                    break;
                case LogLevel.Error:
                    Debug.LogError(formattedMessage, context);
                    break;
                default:
                    Debug.Log(formattedMessage, context);
                    break;
            }
#endif
        }
        
        private static string FormatLogMessage(string message, string prefixColor, string messageColor, string filePath)
        {
            if (messageColor != null)
            {
                message = LogUtility.ColorizeMultipleLines(message, messageColor);
            }

            var prefix = LogUtility.GetPrefixFromFilePath(filePath);
            var formattedPrefix = LogUtility.Colorize(prefix, prefixColor);

            return formattedPrefix + message;
        }
    }
}