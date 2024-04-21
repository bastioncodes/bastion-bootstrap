﻿using Reflex.Core;
using Bastion.Compliance;
using Bastion.Serialization;
using Bastion.Storage;
using Reflex.Injectors;
using UnityEngine;

namespace Bastion.Core
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
            builder.AddSingleton(typeof(UnityJsonConverter), typeof(IJsonConverter));
            builder.AddSingleton(typeof(LegalController));
            builder.AddSingleton(typeof(LegalManager));
            builder.AddSingleton(typeof(FileManager));

            // Example of factory pattern, to ensure newly created objects resolve dependencies
            builder.AddTransient(container =>
            {
                var data = new LegalData();
                AttributeInjector.Inject(data, container);
                return data;
            });
        }
    }
}