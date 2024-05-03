using Reflex.Core;
using Reflex.Injectors;

namespace Bastion.Compliance
{
    public class LegalInstaller : IInstaller
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            builder.AddSingleton(typeof(LegalController));
            builder.AddSingleton(typeof(LegalManager));

            // Example of factory pattern, to ensure newly created objects resolve dependencies
            // Probably this is not even required because one instance of LegalData will be enough
            builder.AddTransient(container =>
            {
                var data = new LegalData();
                AttributeInjector.Inject(data, container);
                return data;
            });
        }
    }
}