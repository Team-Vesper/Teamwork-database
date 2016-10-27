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
            //Database.SetInitializer(
            //    new DropCreateDatabaseIfModelChanges<SqlServerDbContext>());

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<SqlServerDbContext, Configuration>());

            var sqlServerDbContext = new SqlServerDbContext();

            using (sqlServerDbContext)
            {
                sqlServerDbContext.Database.CreateIfNotExists();
            }
        }
    }
}
