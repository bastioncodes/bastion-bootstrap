using System.Runtime.CompilerServices;
using UnityEngine;

namespace Bastion.Logging
{
    /// <summary>
    /// Allows classes that implement the <see cref="ILoggable"/> interface to easily access logging functions while also
    /// passing information about the sender object instance.
    /// <example>
    /// <code>
    /// public class Example : ILoggable
    /// {
    ///     public void Say()
    ///     {
    ///         this.Log("Hello World");
    ///     }
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public static class LoggableExtensions
    {
        public static void Log(this ILoggable loggable, string message, string channel = LogChannel.Default, Object context = null, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            var formatted = LogUtility.FormatMessage(message, loggable, LoggableColor.Default, filePath, lineNumber);
            BastionLogger.Log(formatted, channel, context);
        }
        
        public static void LogInfo(this ILoggable loggable, string message, string channel = LogChannel.Default, Object context = null, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            var formatted = LogUtility.FormatMessage(message, loggable, LoggableColor.Blue, filePath, lineNumber);
            BastionLogger.LogInfo(formatted, channel, context);
        }
        
        public static void LogSuccess(this ILoggable loggable, string message, string channel = LogChannel.Default, Object context = null, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            var formatted = LogUtility.FormatMessage(message, loggable, LoggableColor.Green, filePath, lineNumber);
            BastionLogger.LogSuccess(formatted, channel, context);
        }

        public static void LogWarning(this ILoggable loggable, string message, string channel = LogChannel.Default, Object context = null, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            var formatted = LogUtility.FormatMessage(message, loggable, LoggableColor.Yellow, filePath, lineNumber);
            BastionLogger.LogWarning(formatted, channel, context);
        }
        
        public static void LogError(this ILoggable loggable, string message, string channel = LogChannel.Default, Object context = null, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            var formatted = LogUtility.FormatMessage(message, loggable, LoggableColor.Red, filePath, lineNumber);
            BastionLogger.LogError(formatted, channel, context);
        }

        public static string GetName(this ILoggable loggable)
        {
            return loggable.LogName == string.Empty ? loggable.GetType().Name : loggable.LogName;
        }
    }
}