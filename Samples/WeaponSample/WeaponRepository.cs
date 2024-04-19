using System.Collections.Generic;
using System.Linq;
using Bastion.Core;

namespace Bastion.Samples
{
    public class WeaponRepository : Repository<string, WeaponData>
    {
        public virtual List<WeaponData> SortByDamage(bool highToLow = false)
        {
            return Models.Values.OrderBy(weapon => weapon.Damage).ToList();
        }
    }
}