using Bastion.Boot;
using Bastion.Logging;
using Reflex.Core;

namespace Bastion.Serialization
{
    public class JsonInstaller : IInstaller, ILoggable
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            var config = AppConfig.Load();
            
            // Currently tightly coupled with Newtonsoft
            builder.AddSingleton(typeof(NewtonsoftJsonConverter), typeof(IJsonConverter));
            builder.AddSingleton(config.JsonConverterRegistry, typeof(IJsonConverterRegistry));
        }
    }
}