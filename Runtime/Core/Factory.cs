using System;
using Reflex.Core;
using Reflex.Injectors;

namespace Bastion.Core
{
    /// <summary>
    /// Provides a generic factory for creating instances of the specified type with support for dependency injection.
    /// </summary>
    /// <typeparam name="TModel">The type of object this factory produces, must be a class.</typeparam>
    public abstract class Factory<TModel> where TModel : class
    {
        protected readonly Container Container;

        protected Factory(Container container)
        {
            Container = container;
        }
        
        /// <summary>
        /// Creates an instance of the factory model and automatically injects its dependencies using the <see cref="AttributeInjector"/>,
        /// and optionally executing a callback upon completion.
        /// </summary>
        /// <remarks>
        /// Use this factory method to create instances instead of the 'new' keyword to ensure that all dependencies are properly injected.
        /// </remarks>
        /// <param name="createInstance">A factory method to create an instance of the model.</param>
        /// <param name="onComplete">An action to perform on the newly created instance upon completion of its creation and injection.</param>
        /// <returns>The newly created and dependency-injected instance of the model.</returns>
        protected TModel CreateWithInjection(Func<TModel> createInstance, Action<TModel> onComplete = null)
        {
            var instance = createInstance();
            AttributeInjector.Inject(instance, Container);
            onComplete?.Invoke(instance);
             
            return instance;
        }
    }
}