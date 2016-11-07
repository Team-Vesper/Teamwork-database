using System;
using System.Linq;
using TeamVesper.DbCreate.Contracts;
using TeamVesper.Models;
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

                string[] priorities = new string[4];
                priorities[0] = "Urgent";
                priorities[1] = "Important";
                priorities[2] = "Not Important";
                priorities[3] = "Don't care";

                foreach (var pr in priorities)
                {
                    if (this.sqlServerDbContext.Priorities.Any(p => p.Name == pr))
                    {
                    }
                    else
                    {
                        Priority priority = new Priority(pr);
                        this.sqlServerDbContext.Priorities.Add(priority);
                    }
                }

                this.sqlServerDbContext.SaveChanges();
            }
        }
    }
}
