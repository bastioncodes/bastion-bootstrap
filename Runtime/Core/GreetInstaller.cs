using Reflex.Core;
using UnityEngine;

namespace Bastion.Core.Reflex
{
    public class GreetInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            // builder.AddSingleton("World");
        }
    }
}