using System.Data.Entity;
using EFAutoupgradeExceptions.Data.Entities;

namespace EFAutoupgradeExceptions.Data
{
    public class AutoupgradeExceptionMapping
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            MapApiUser(modelBuilder);
        }

        private static void MapApiUser(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiUser>().ToTable("ApiUser");
        }
    }
}