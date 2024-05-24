using System.IO;
using System.Text;

namespace Bastion.Logging
{
    public static class LogUtility
    {
        private const string FallbackPrefix = "Unknown";

        public static string GetPrefixFromFilePath(string filePath)
        {
            var className = ExtractClassNameFromPath(filePath);
            var config = LogConfig.GetLogAttributeConfig(className);
            
            if (config == null)
                return $"[{className}] ";

            // Apply log configuration
            return Colorize(string.IsNullOrEmpty(config.Name) ? $"[{className}] " : $"[{config.Name}] ",
                config.Color);
        }
        
        private static string ExtractClassNameFromPath(string filePath)
        {
            return string.IsNullOrEmpty(filePath) ? FallbackPrefix : Path.GetFileNameWithoutExtension(filePath);
        }
        
        /// <summary>
        /// Applies color to the first 10 lines of a message to ensure correct color rendering in the Unity Editor console.
        /// This method addresses a limitation in the Unity console where long color tags across multiple lines do not render properly.
        /// The 10-line limit matches the maximum single log entry display in the Unity Editor, ensuring consistent visual output.
        /// </summary>
        /// <remarks>
        /// In the expanded log view of the Unity Editor, full text coloring works without this line-by-line tagging as tags are properly parsed.
        /// </remarks>
        /// <param name="message">The message to be colorized.</param>
        /// <param name="hexColor">The hexadecimal color code to apply to the message.</param>
        /// <returns>A colorized string where each of the first 10 lines is individually wrapped with a color tag.</returns>
        public static string ColorizeMultipleLines(string message, string hexColor)
        {
            string[] lines = message.Split('\n');
            int maxLines = 10;
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < lines.Length; i++)
            {
                if (i < maxLines)
                {
                    builder.AppendLine(Colorize(lines[i], hexColor));
                }
                else
                {
                    // Start appending the rest to a new StringBuilder to colorize them all at once
                    StringBuilder remainingLines = new StringBuilder();
                    for (; i < lines.Length; i++)
                    {
                        remainingLines.AppendLine(lines[i]);
                    }
                    builder.Append(Colorize(remainingLines.ToString(), hexColor));
                    break;
                }
            }

            return builder.ToString();
        }
        
        /// <summary>
        /// Applies a hexadecimal color to the entire message, wrapping it in a color tag for Unity Editor's console display.
        /// </summary>
        /// <remarks>
        /// This method is used to colorize a single output line. For multi-line messages, use <see cref="ColorizeMultipleLines"/>.
        /// </remarks>
        /// <param name="message">The message to be colorized.</param>
        /// <param name="hexColor">The hexadecimal color code to apply to the message. If null, the message is returned unaltered.</param>
        /// <returns>The message wrapped in a color tag if a hexColor is provided; otherwise, the original message.</returns>
        public static string Colorize(string message, string hexColor)
        {
            return hexColor == null ? message : $"<color={hexColor}>{message}</color>";
        }
    }
}