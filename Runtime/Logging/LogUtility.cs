using System.IO;

namespace Bastion.Logging
{
    public static class LogUtility
    {
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