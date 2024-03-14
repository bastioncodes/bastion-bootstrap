using System.Runtime.Serialization;
using SebastianFeistl.Winky.Core;

namespace SebastianFeistl.Winky.WeaponSample
{
    public class WeaponData : Data
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
    
        [DataMember(Name = "damage")]
        public int Damage { get; set; }
    
        [DataMember(Name = "spell_power")]
        public int SpellPower { get; set; }
    
        [DataMember(Name = "cooldown")]
        public float Cooldown { get; set; }
    
        public WeaponData(string name = null, int damage = 0, int spellPower = 0, float cooldown = 0)
        {
            Name = name;
            Damage = damage;
            SpellPower = spellPower;
            Cooldown = cooldown;
        }
    }   
}