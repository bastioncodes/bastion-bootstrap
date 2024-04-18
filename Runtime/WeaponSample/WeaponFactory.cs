using Reflex.Core;
using Reflex.Injectors;
using Bastion.Core;

namespace Bastion.WeaponSample
{
    public class WeaponFactory : Factory<WeaponData>
    {
        public WeaponFactory(Container container) : base(container)
        {
            //
        }
        
        public WeaponData Create(string name)
        {
            var data = new WeaponData
            {
                Name = name
            };

            AttributeInjector.Inject(data, Container);
            
            return data;
        }
    }
}