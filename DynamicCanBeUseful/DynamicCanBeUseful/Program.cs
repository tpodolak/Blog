using System;
using System.Collections.Generic;
using System.Linq;
using DynamicCanBeUseful.Converters;
using DynamicCanBeUseful.TransferObjects;

namespace DynamicCanBeUseful
{
    class Program
    {
        static void Main(string[] args)
        {
            var weaponService = new WeaponService();
            IList<Weapon> data = weaponService.GetWeapons();
            List<Models.Weapon> weapons = data.Select(WeaponConverter.Convert).ToList();
            weapons.ForEach(val => Console.WriteLine($"Weapon type {val.GetType().FullName}"));
            Console.ReadKey();
        }
    }
}
