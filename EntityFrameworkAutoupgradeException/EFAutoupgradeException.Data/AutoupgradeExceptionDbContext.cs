using System.Data.Entity;
using EFAutoupgradeExceptions.Data.Entities;

namespace EFAutoupgradeExceptions.Data
{
    public class AutoupgradeExceptionDbContext : DbContext
    {
        public DbSet<ApiUser> ApiUsers { get; set; }

        public AutoupgradeExceptionDbContext() : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        static AutoupgradeExceptionDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AutoupgradeExceptionDbContext, AutoupgradeExceptionMigrationConfiguration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            AutoupgradeExceptionMapping.Configure(modelBuilder);
        }
    }
}
