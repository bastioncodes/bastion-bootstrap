using System;

namespace Bastion.Logging
{
    /// <summary>
    /// TODO: Document
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class LogAttribute : Attribute
    {
        // public string Channel { get; set; } = "Default";
        // Currently only disables the settings override, but does not prevent the output of the log message itself
        // public bool Enabled { get; set; } = true;
        public Type Type { get; }
        public string Name { get; set; } = "";
        public string Color { get; set; } = null;
        
        public LogAttribute(Type type)
        {
            Type = type;
        }
    }
}