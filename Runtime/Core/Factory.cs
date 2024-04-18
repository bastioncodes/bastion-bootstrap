using Reflex.Core;

namespace Bastion.Core
{
    public abstract class Factory<TModel> where TModel : class
    {
        protected readonly Container Container;

        public Factory(Container container)
        {
            Container = container;
        }
        
        public TModel Create()
        {
            return Container.Resolve<TModel>();
        }
    }
}