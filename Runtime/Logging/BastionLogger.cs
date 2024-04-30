using UnityEngine;

namespace Bastion.Logging
{
    public static class BastionLogger
    {
        public static void Log(string message, ILoggable loggable, string channel = LogChannel.Default, Object context = null)
        {
            message = LogUtility.AddClassPrefix(message, loggable?.LogColor);
            Debug.Log(message, context);
        }
        
        public static void Log(string message, string channel = LogChannel.Default, Object context = null)
        {
            message = LogUtility.AddClassPrefix(message, LoggableColor.Yellow);
            Debug.Log(message, context);
        }
        
        public static void LogInfo(string message, string channel = LogChannel.Default, Object context = null)
        {
            message = LogUtility.Colorize(message, LoggableColor.Blue);
            message = LogUtility.AddClassPrefix(message, LoggableColor.Yellow);
            Debug.Log(message, context);
        }
        
        public static void LogSuccess(string message, string channel = LogChannel.Default, Object context = null)
        {
            message = LogUtility.Colorize(message, LoggableColor.Green);
            message = LogUtility.AddClassPrefix(message, LoggableColor.Yellow);
            Debug.Log(message, context);
        }
        
        public static void LogWarning(string message, string channel = LogChannel.Default, Object context = null)
        {
            message = LogUtility.Colorize(message, LoggableColor.Yellow);
            message = LogUtility.AddClassPrefix(message, LoggableColor.Yellow);
            Debug.LogWarning(message, context);
        }
        
        public static void LogError(string message, string channel = LogChannel.Default, Object context = null)
        {
            message = LogUtility.Colorize(message, LoggableColor.Red);
            message = LogUtility.AddClassPrefix(message, LoggableColor.Yellow);
            Debug.LogError(message, context);
        }
    }
}