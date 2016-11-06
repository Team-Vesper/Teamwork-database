using System;
using TeamVesper.DbCreate.Contracts;
using TeamVesper.SqlServerData;

namespace TeamVesper.DbCreate
{
    public class SqlServerInitializer : IDbInitializer
    {
        private SqlServerDbContext sqlServerDbContext;

        public SqlServerInitializer(SqlServerDbContext sqlServerDbContext)
        {
            this.sqlServerDbContext = sqlServerDbContext;
        }

        public void CreateDB()
        {
            using (this.sqlServerDbContext)
            {
                this.sqlServerDbContext.Database.CreateIfNotExists();
            }
        }
    }
}
