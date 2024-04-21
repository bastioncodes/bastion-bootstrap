using UnityEngine;

namespace Bastion.Logging
{
    // TODO: Implement channel logic
    public static class LogDispatcher
    {
        public static void Log(string message, string channel = LogChannel.Default)
        {
            Debug.Log(message);
        }
        
        public static void LogInfo(string message, string channel = LogChannel.Default)
        {
            Debug.Log(message);
        }
        
        public static void LogSuccess(string message, string channel = LogChannel.Default)
        {
            Debug.Log(message);
        }
        
        public static void LogWarning(string message, string channel = LogChannel.Default)
        {
            Debug.LogWarning(message);
        }
        
        public static void LogError(string message, string channel = LogChannel.Default)
        {
            Debug.LogError(message);
        }
    }
}