using UnityEditor;

namespace Bastion.Logging
{
    public static class LoggableColor
    {
        public static readonly string Red = IsDarkMode ? "#ef4444" : "#991b1b";
        public static readonly string Yellow = IsDarkMode ? "#f59e0b" : "#92400e";
        public static readonly string Blue = IsDarkMode ? "#0ea5e9" : "#1e40af";
        public static readonly string Sky = IsDarkMode ? "#7dd3fc" : "#0369a1";
        public static readonly string Green = IsDarkMode ? "#22c55e" : "#166534";
        public static readonly string Gray = IsDarkMode ? "#71717a" : "#4b5563";
        public static readonly string Default = IsDarkMode ? "#a6a6a6" : "#0e0e0e";

        private static bool IsDarkMode
        {
            get
            {
#if UNITY_EDITOR
                return EditorGUIUtility.isProSkin;
#else
                return true;
#endif
            }
        }
    }
}