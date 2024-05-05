using System;

namespace Bastion.Logging
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class LoggableAttribute : Attribute
    {
        public bool Enable { get; set; } = true;
        public string Name { get; set; } = "";
        public string Color { get; set; } = Theme.Color.Sky;
        public string Channel { get; set; } = "Default";
    }
}