namespace TeamVesper.SqlServerData
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public static class BugsDB
    {
        public static void Add(List<Bug> bugs)
        {
            var sqlSever = new SqlServerDbContext();

            foreach (var bug in bugs)
            {
                if (sqlSever.Bugs.Any(b => b.Description == bug.Description))
                {
                }
                else
                {
                    sqlSever.Bugs.Add(bug);
                }
            }

            sqlSever.SaveChanges();
        }
    }
}
