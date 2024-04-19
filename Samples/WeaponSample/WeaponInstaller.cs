using Reflex.Core;
using UnityEngine;

namespace Bastion.Samples
{
    public class WeaponInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            builder.AddTransient(typeof(WeaponData));
            builder.AddSingleton(typeof(WeaponFactory));
            builder.AddSingleton(typeof(WeaponRepository));
        }
    }
}