using System;
using Reflex.Core;
using Reflex.Injectors;
using Bastion.Core;
using UnityEngine;

namespace Bastion.Logging
{
    public class LogFactory : Factory<LogData>
    {
        public LogFactory(Container container) : base(container)
        {
            //
        }
        
        public LogData Create(string message, LogLevel level, string tag = "Default")
        {
            throw new NotImplementedException();
        }
        
        public LogData Create(string message, string tag = "Default")
        {
            return Container.Resolve<LogData>();
            var data = new LogData
            {
                Message = message
            };
            
            Debug.Log("About to inject");
            AttributeInjector.Inject(data, Container);
            
            return data;
            
            /*
            var data = Create();

            data.Message = message;
            data.Tag = tag;

            return data;
            */
        }
    }
}