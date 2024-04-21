using System.Runtime.CompilerServices;

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
        public static void Log(this ILoggable loggable, string message, string channel = LogChannel.Default, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            var formatted = LogUtility.FormatMessage(message, loggable, LoggableColor.Default, filePath, lineNumber);
            LogDispatcher.Log(formatted, channel);
        }
        
        public static void LogInfo(this ILoggable loggable, string message, string channel = LogChannel.Default, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            var formatted = LogUtility.FormatMessage(message, loggable, LoggableColor.Blue, filePath, lineNumber);
            LogDispatcher.LogInfo(formatted, channel);
        }
        
        public static void LogSuccess(this ILoggable loggable, string message, string channel = LogChannel.Default, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            var formatted = LogUtility.FormatMessage(message, loggable, LoggableColor.Green, filePath, lineNumber);
            LogDispatcher.LogSuccess(formatted, channel);
        }

        public static void LogWarning(this ILoggable loggable, string message, string channel = LogChannel.Default, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            var formatted = LogUtility.FormatMessage(message, loggable, LoggableColor.Yellow, filePath, lineNumber);
            LogDispatcher.LogWarning(formatted, channel);
        }
        
        public static void LogError(this ILoggable loggable, string message, string channel = LogChannel.Default, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            var formatted = LogUtility.FormatMessage(message, loggable, LoggableColor.Red, filePath, lineNumber);
            LogDispatcher.LogError(formatted, channel);
        }

        public static string GetName(this ILoggable loggable)
        {
            return loggable.LogName == string.Empty ? loggable.GetType().Name : loggable.LogName;
        }
    }
}