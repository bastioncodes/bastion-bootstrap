using System;
using Reflex.Core;

namespace Bastion.Core
{
    public static class ServiceLocator
    {
        public static Container Container { get; private set; }

        public static void SetContainer(Container container)
        {
            Container = container;
            // BastionLogger.LogInfo("App container built successfully.");
        }

        public static T Find<T>()
        {
            if (Container == null)
            {
                throw new InvalidOperationException($"{nameof(ServiceLocator)} container not initialized.");
            }

            return Container.Resolve<T>();
        }
    }
}