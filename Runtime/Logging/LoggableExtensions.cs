using System;

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
        public static void Log(this ILoggable loggable, string message, string channel = LogChannel.Default)
        {
            
        }
        
        public static void LogInfo(this ILoggable loggable, string message, string channel = LogChannel.Default)
        {
            
        }
        
        public static void LogSuccess(this ILoggable loggable, string message, string channel = LogChannel.Default)
        {
            
        }

        public static void LogWarning(this ILoggable loggable, string message, string channel = LogChannel.Default)
        {
            
        }
        
        public static void LogError(this ILoggable loggable, string message, string channel = LogChannel.Default)
        {
            
        }
    }
}