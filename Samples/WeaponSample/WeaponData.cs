using System.Runtime.Serialization;
using Bastion.Core;

namespace Bastion.Samples
{
    public class WeaponData : Data
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
    
        [DataMember(Name = "damage")]
        public int Damage { get; set; }
    
        [DataMember(Name = "cooldown")]
        public float Cooldown { get; set; }
    
        public WeaponData(string name = null, int damage = 0, float cooldown = 0)
        {
            Name = name;
            Damage = damage;
            Cooldown = cooldown;
        }
    }   
}