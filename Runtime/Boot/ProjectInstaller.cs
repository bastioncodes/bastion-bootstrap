using Reflex.Core;
using Bastion.Compliance;
using Bastion.Core;
using Bastion.Logging;
using Bastion.Serialization;
using Bastion.Storage;
using UnityEngine;
using Color = Bastion.Theme.Color;

namespace Bastion.Boot
{
    [Log(nameof(ProjectInstaller), Color = Color.Blue)]
    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            BastionLogger.LogInfo("Installing project bindings ...");

            // Install global bindings
            builder.AddSingleton(typeof(FileManager));
            
            // Call other module installers
            new LegalInstaller().InstallBindings(builder);
            new JsonInstaller().InstallBindings(builder);
            
            builder.OnContainerBuilt += ServiceLocator.SetContainer;
        }
    }
}