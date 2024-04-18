using System;

namespace Bastion.Logging
{
    public static class LogEventBroadcaster
    {
        public static event Action<LogData> Transmit = _ => { };

        public static void Dispatch(ILoggable sender, string message, string channel, LogLevel level)
        {
            var data = new LogData
            {
                Sender = sender.GetType().Name,
                Message = message,
                Channel = channel,
                Level = level,
            };
            
            Transmit(data);
        }
    }
}