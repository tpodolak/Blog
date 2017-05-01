using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace AspNetCoreApiVersioningByConvention.Extensions
{
    public static class CollectionExtensions
    {
        public static void Remove<T>(this IList<IApplicationModelConvention> conventionsCollection)
            where T : IApplicationModelConvention
        {
            var conventions = conventionsCollection.OfType<T>().ToList();

            foreach (var convention in conventions)
            {
                conventionsCollection.Remove(convention);
            }
        }
    }
}