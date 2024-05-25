using Reflex.Core;
using Reflex.Injectors;
using UnityEngine;

namespace Bastion.Samples.Blob
{
    public class BlobInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            builder.AddSingleton(typeof(BlobRepository));
            builder.AddSingleton(typeof(BlobFactory));
            builder.AddSingleton(typeof(BlobManager));
            builder.AddTransient(container =>
            {
                var data = new BlobData();
                AttributeInjector.Inject(data, container);
                return data;
            });
        }
    }
}

