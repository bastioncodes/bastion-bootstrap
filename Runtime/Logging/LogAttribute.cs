using System;

namespace Bastion.Logging
{
    /// <summary>
    /// TODO: Document
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class LogAttribute : Attribute
    {
        public string Channel { get; set; } = "Default";
        // public bool Enabled { get; set; } = true;
        public string Id { get; private set; }
        public string Name { get; set; } = "";
        public string Color { get; set; } = null;
        
        public LogAttribute(string id)
        {
            Id = id;
        }
    }
}