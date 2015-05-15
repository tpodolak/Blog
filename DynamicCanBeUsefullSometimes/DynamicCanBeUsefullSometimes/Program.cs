using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicCanBeUsefullSometimes.Converters;
using DynamicCanBeUsefullSometimes.TransferObjects;
using static System.Console;
using Weapon = DynamicCanBeUsefullSometimes.Models.Weapon;

namespace DynamicCanBeUsefullSometimes
{
    class Program
    {
        static void Main(string[] args)
        {
            var weaponService = new WeaponService();
            IList<TransferObjects.Weapon> data = weaponService.GetWeapons();
            List<Models.Weapon> weapons = data.Select(WeaponConverter.Convert).ToList();
            weapons.ForEach(val => WriteLine($"Weapon type {val.GetType().FullName}"));
            ReadKey();
        }
    }
}
