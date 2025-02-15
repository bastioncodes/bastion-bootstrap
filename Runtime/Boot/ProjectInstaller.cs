using Reflex.Core;
using Bastion.Core;
using Bastion.Logging;
using Bastion.Serialization;
using UnityEngine;
using Color = Bastion.Theme.Color;

namespace Bastion.Boot
{
    [Log(nameof(ProjectInstaller), Color = Color.Sky)]
    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            BastionLogger.LogInfo("Installing project bindings ...");

            // Install global bindings
            new JsonInstaller().InstallBindings(builder);
            
            builder.OnContainerBuilt += ServiceLocator.SetContainer;
        }
    }
}