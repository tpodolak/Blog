using System.Collections.Generic;
using DynamicCanBeUseful.TransferObjects;

namespace DynamicCanBeUseful
{
    public class WeaponService : IWeaponService
    {
        public IList<Weapon> GetWeapons()
        {
            return new List<Weapon>
            {
                new Gun {AmmoCapacity = 2, Damage = 3, Range = 4},
                new Sword {Damage = 1, Length = 2, Range = 1}
            };
        }
    }
}