using Bastion.Logging;
using Bastion.Serialization.Newtonsoft;
using Reflex.Core;

namespace Bastion.Serialization
{
    public class JsonInstaller : IInstaller, ILoggable
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            // Currently tightly coupled with Newtonsoft
            // Using the built-in Unity serialization would not require this dependency
            builder.AddSingleton(typeof(JsonConverterRegistry));
        }
    }
}