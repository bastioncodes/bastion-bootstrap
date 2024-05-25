using Reflex.Core;
using Reflex.Injectors;
using Bastion.Core;

namespace Bastion.Samples.Weapon
{
    public class WeaponFactory : Factory<WeaponData>
    {
        public WeaponFactory(Container container) : base(container)
        {
            //
        }

        public WeaponData Create(string name, int damage, float cooldown)
        {
            // Create new object with specific constructor
            return CreateWithInjection(() => new WeaponData(name, damage, cooldown));
            
            // Alternative: Create new object with additional initialization code after object creation
            /*
            return CreateWithInjection(() => new WeaponData(), weapon =>
            {
                weapon.Name = name;
                weapon.Damage = damage;
                weapon.Cooldown = cooldown;
            });
            */
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