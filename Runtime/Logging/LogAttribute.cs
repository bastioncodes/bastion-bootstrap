using System;

namespace Bastion.Logging
{
    /// <summary>
    /// Defines logging metadata for classes to customize log output appearance and categorization.
    /// Only compatible with the <see cref="BastionLogger"/>.
    /// </summary>
    /// <remarks>
    /// This attribute allows the configuration of logging preferences per class,
    /// including color, channel, and enabled status.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class LogAttribute : Attribute
    {
        public string Id { get; private set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Channel { get; set; } = LogChannel.Default;
        
        public bool Enabled { get; set; } = true;
        
        public LogAttribute(string id)
        {
            Id = id;
        }
    }
}