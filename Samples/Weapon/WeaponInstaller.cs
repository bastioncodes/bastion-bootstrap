using Reflex.Core;
using UnityEngine;

namespace Bastion.Samples.Weapon
{
    public class WeaponInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            builder.AddSingleton(typeof(WeaponFactory));
            builder.AddSingleton(typeof(WeaponRepository));
        }
    }
}