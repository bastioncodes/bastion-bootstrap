using Reflex.Core;
using UnityEngine;

namespace SebastianFeistl.Winky.Logging
{
    public class LogInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            /*
            builder.AddTransient(typeof(LogData));
            builder.AddSingleton(typeof(LogFactory));
            builder.AddSingleton(typeof(LogManager));
            builder.AddSingleton(typeof(LogRepository));
            */
        }
    }
}