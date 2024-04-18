using System;
using System.Runtime.Serialization;
using Bastion.Core;

namespace Bastion.Logging
{
    public class LogData : Data
    {
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt = DateTime.Now;
        
        [DataMember(Name = "sender")]
        public string Sender;
        
        [DataMember(Name = "message")]
        public string Message;
        
        [DataMember(Name = "channel")]
        public string Channel;
        
        [DataMember(Name = "level")]
        public LogLevel Level;
    }
}