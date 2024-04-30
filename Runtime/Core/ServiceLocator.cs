using System;
using Reflex.Core;

namespace Bastion.Core
{
    public static class ServiceLocator
    {
        private static Container _container;

        public static void SetContainer(Container container)
        {
            _container = container;
        }

        public static T Find<T>()
        {
            if (_container == null)
            {
                throw new InvalidOperationException($"{nameof(ServiceLocator)} container not initialized.");
            }

            return _container.Resolve<T>();
        }
    }

}