using System;

namespace DynamicCanBeUsefullSometimes.Converters
{
    public class WeaponConverter
    {
        /// <summary>
        /// Without dynamic, ugly ifs 
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public static Models.Weapon ConvertOld(TransferObjects.Weapon weapon)
        {
            if (weapon is TransferObjects.Gun)
            {
                return ConvertInternal((TransferObjects.Gun)weapon);
            }
            if (weapon is TransferObjects.Sword)
            {
                return ConvertInternal((TransferObjects.Sword)weapon);
            }

            throw new ArgumentException("Unknown weapon", nameof(weapon));
        }

        /// <summary>
        /// With dynamic nice oneliner
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public static Models.Weapon Convert(TransferObjects.Weapon weapon)
        {
            return weapon != null ? ConvertInternal((dynamic)weapon) : null;
        }

        private static Models.Gun ConvertInternal(TransferObjects.Gun gun)
        {
            var baseResult = ConvertInternalBase<TransferObjects.Gun, Models.Gun>(gun);
            baseResult.AmmoCapacity = gun.AmmoCapacity;
            return baseResult;
        }

        private static Models.Sword ConvertInternal(TransferObjects.Sword sword)
        {
            var baseResult = ConvertInternalBase<TransferObjects.Sword, Models.Sword>(sword);
            baseResult.Length = sword.Length;
            return baseResult;
        }

        private static TResult ConvertInternalBase<TSource, TResult>(TSource source)
            where TSource : TransferObjects.Weapon
            where TResult : Models.Weapon, new()
        {
            return new TResult
            {
                Damage = source.Damage,
                Range = source.Range
            };
        }
    }
}