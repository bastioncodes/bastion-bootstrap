using System;
using Reflex.Core;
using Reflex.Injectors;

namespace Bastion.Core
{
    public abstract class Factory<TModel> where TModel : class
    {
        protected readonly Container Container;

        protected Factory(Container container)
        {
            Container = container;
        }
        
        protected TModel Create()
        {
            return Container.Resolve<TModel>();
        }
        
        protected TModel CreateWithInjection(Action<TModel> onComplete = null)
        {
            var instance = Container.Resolve<TModel>();
            AttributeInjector.Inject(instance, Container);
            onComplete?.Invoke(instance);
            
            return instance;
        }
    }
}