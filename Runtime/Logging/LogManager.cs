using System;
using Reflex.Attributes;
using SebastianFeistl.Winky.Core;
using SebastianFeistl.Winky.Serialization;
using SebastianFeistl.Winky.Storage;

namespace SebastianFeistl.Winky.Logging
{
    public class LogManager : Manager
    {
        [Inject] private readonly LogRepository _logs;
        [Inject] private readonly LogFactory _factory;
        [Inject] private readonly IJsonConverter _jsonConverter;
        [Inject] private readonly FileManager _fileManager;
        
        public override void Initialize(Action onComplete = null, Action<Exception> onError = null)
        {
            LogEventBroadcaster.Transmit += OnLogEventReceived;
            
            onComplete?.Invoke();
        }
        
        public override void Dispose()
        {
            LogEventBroadcaster.Transmit -= OnLogEventReceived;
        }

        private void OnLogEventReceived(LogData data)
        {
            _logs.Add(data);
            _fileManager.SaveFile("log.json", _logs.ToJson());
        }

        private void Log(LogData data)
        {
            switch (data.Level)
            {
                case LogLevel.Default:
                    break;
                case LogLevel.Info:
                    break;
                case LogLevel.Success:
                    break;
                case LogLevel.Warning:
                    break;
                case LogLevel.Error:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}