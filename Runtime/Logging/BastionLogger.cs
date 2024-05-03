using UnityEngine;

namespace Bastion.Logging
{
    public static class BastionLogger
    {
        private static readonly string DefaultPrefixColor = LoggableColor.Default;
        
        public static void Log(string message, string channel = LogChannel.Default, string prefixColor = null, string messageColor = null, Object context = null)
        {
            message = FormatLogMessage(message, prefixColor, messageColor);
            Debug.Log(message, context);
        }
        
        public static void LogInfo(string message, string channel = LogChannel.Default, string prefixColor = null, string messageColor = null, Object context = null)
        {
            var color = messageColor ?? LoggableColor.Blue;
            message = FormatLogMessage(message, prefixColor, color);
            Debug.Log(message, context);
        }
        
        public static void LogSuccess(string message, string channel = LogChannel.Default, string prefixColor = null, string messageColor = null, Object context = null)
        {
            var color = messageColor ?? LoggableColor.Green;
            message = FormatLogMessage(message, prefixColor, color);
            Debug.Log(message, context);
        }
        
        public static void LogWarning(string message, string channel = LogChannel.Default, string prefixColor = null, string messageColor = null, Object context = null)
        {
            var color = messageColor ?? LoggableColor.Yellow;
            message = FormatLogMessage(message, prefixColor, color);
            Debug.LogWarning(message, context);
        }
        
        public static void LogError(string message, string channel = LogChannel.Default, string prefixColor = null, string messageColor = null, Object context = null)
        {
            var color = messageColor ?? LoggableColor.Red;
            message = FormatLogMessage(message, prefixColor, color);
            Debug.LogError(message, context);
        }
        
        private static string FormatLogMessage(string message, string prefixColor, string messageColor)
        {
            if (messageColor != null)
            {
                message = LogUtility.ColorizeMultipleLines(message, messageColor);
            }

            // Set to default if null
            prefixColor ??= DefaultPrefixColor;
            
            return LogUtility.AddClassPrefix(message, prefixColor);
        }
    }
}