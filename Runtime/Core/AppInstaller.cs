using Reflex.Core;
using Bastion.Compliance;
using Bastion.Serialization;
using Bastion.Storage;
using UnityEngine;

namespace Bastion.Core
{
    /// <summary>
    /// The entry point of the application.
    /// Bind essential dependencies making them globally available.
    /// </summary>
    public class AppInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            builder.AddSingleton(typeof(NewtonsoftJsonConverter), typeof(IJsonConverter));
            builder.AddTransient(typeof(LegalData));
            builder.AddSingleton(typeof(LegalController));
            builder.AddSingleton(typeof(LegalManager));
            builder.AddSingleton(typeof(FileManager));
        }
    }
}