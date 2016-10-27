using System.Data.Entity.Migrations;

namespace TeamVesper.SqlServerData.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<SqlServerDbContext>
    {
        public Configuration()
        {
            // TODO set both false before production stage !Important
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        //protected override void Seed(SqlServerDbContext context)
        //{
            
        //}
    }
}
