using Reflex.Core;
using Bastion.Compliance;
using Bastion.Core;
using Bastion.Logging;
using Bastion.Serialization;
using Bastion.Serialization.Newtonsoft;
using Bastion.Storage;
using UnityEngine;

namespace Bastion.Boot
{
    /// <summary>
    /// Create and bind global dependencies.
    /// <remarks>
    /// Singletons are objects with only one of its kind.
    /// Transients are objects that can have multiple instances. They will need to be created using a <see cref="Factory{TModel}"/> in order to resolve dependencies.
    /// </remarks>
    /// </summary>
    public class AppInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            BastionLogger.LogInfo("Installing global bindings ...");

            // Install global bindings
            builder.AddSingleton(typeof(NewtonsoftJsonConverter), typeof(IJsonConverter));
            builder.AddSingleton(typeof(FileManager));
            
            // Call other module installers
            new LegalInstaller().InstallBindings(builder);
            new JsonInstaller().InstallBindings(builder);
            
            builder.OnContainerBuilt += ServiceLocator.SetContainer;
        }
    }
}