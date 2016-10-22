using System.Data.Entity;
using TeamVesper.Models;
using TeamVesper.SqlServerData;
using TeamVesper.SqlServerData.Migrations;

namespace TeamVesper.DbCreate
{
    public class Startup
    {
        public static void Main()
        {
            SqlServerDbCreate();
        }

        private static void SqlServerDbCreate()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<SqlServerDbContext, Configuration>());

            var sqlServerDbContext = new SqlServerDbContext();

            var dateTimeProvider = new DateTimeProvider();
            var init = new SqlInitializer(dateTimeProvider);

            sqlServerDbContext.Initializer.Add(init);

            sqlServerDbContext.SaveChanges();
        }
    }
}
