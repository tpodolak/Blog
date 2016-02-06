using System;
using System.Linq;
using EFAutoupgradeExceptions.Data;

namespace EFAutoupgradeException
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AutoupgradeExceptionDbContext())
            {
                // launching this for the fist time works fine
                // launching this after changing name/namespace of AutoupgradeExceptionMigrationConfiguration will throw SqlException
                var users = context.ApiUsers.ToList();

                Console.ReadKey();
            }
        }
    }
}
