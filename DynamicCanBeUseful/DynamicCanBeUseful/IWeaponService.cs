using System.Collections.Generic;
using DynamicCanBeUseful.TransferObjects;

namespace DynamicCanBeUseful
{
    public interface IWeaponService
    {
        IList<Weapon> GetWeapons();
    }
}