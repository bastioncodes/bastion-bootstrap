using Bastion.Logging;
using Bastion.Storage;
using Reflex.Core;
using UnityEngine;
using Color = Bastion.Theme.Color;

namespace Bastion
{
    /// <summary>
    /// Create and bind global dependencies.
    /// <remarks>
    /// Singletons are objects with only one of its kind.
    /// Transients are objects that can have multiple instances. They can be created using a <see cref="Bastion.Core.Factory{TModel}"/> in order to resolve dependencies.
    /// </remarks>
    /// </summary>
    [Log(nameof(AppInstallerSample), Color = Color.Sky)]
    public class AppInstallerSample : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            BastionLogger.LogInfo("Installing app bindings ...");
            
            // TODO: Register your dependencies here. Build something great!
            builder.AddSingleton(typeof(FileManager));
            
            // builder.AddSingleton(typeof(ExampleManager));
            // builder.AddSingleton(typeof(ExampleRepository));
            // builder.AddSingleton(typeof(ExampleFactory));
            // ...
            // builder.AddTransient(container =>
            // {
            //     var data = new ExampleData();
            //     AttributeInjector.Inject(data, container);
            //     return data;
            // });
        }
    }
}