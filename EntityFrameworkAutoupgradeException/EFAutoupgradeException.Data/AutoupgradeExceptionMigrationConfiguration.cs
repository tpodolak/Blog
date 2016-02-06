using System.Data.Entity.Migrations;
using EFAutoupgradeExceptions.Data;

namespace EFAutoupgradeExceptions.Data
{
    public class AutoupgradeExceptionMigrationConfiguration : DbMigrationsConfiguration<AutoupgradeExceptionDbContext>
    {
        public AutoupgradeExceptionMigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }
    }
}