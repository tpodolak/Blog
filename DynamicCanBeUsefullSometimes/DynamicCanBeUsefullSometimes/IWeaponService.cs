using System.Collections.Generic;
using DynamicCanBeUsefullSometimes.TransferObjects;

namespace DynamicCanBeUsefullSometimes
{
    public interface IWeaponService
    {
        IList<Weapon> GetWeapons();
    }
}