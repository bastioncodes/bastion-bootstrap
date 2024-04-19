using Reflex.Core;
using Reflex.Injectors;
using Bastion.Core;

namespace Bastion.Samples
{
    public class WeaponFactory : Factory<WeaponData>
    {
        public WeaponFactory(Container container) : base(container)
        {
            //
        }

        public WeaponData Create(string name, int damage, float cooldown)
        {
            return CreateWithInjection(weapon =>
            {
                weapon.Name = name;
                weapon.Damage = damage;
                weapon.Cooldown = cooldown;
            });
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