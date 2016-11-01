namespace TeamVesper.Utilities
{
    using SqlServerData;
    using System.Linq;

    public static class BugActions
    {
        public static void Assign()
        {
            var sqlServer = new SqlServerDbContext();

            foreach (var bug in sqlServer.Bugs.ToList())
            {
                if (bug.AttachedTo == null)
                {
                    var developer = sqlServer.Developers
                        .Where(d => d.SpecialityId == bug.SpecialityId)
                        .OrderBy(d => d.WorkingOn.Count)
                        .FirstOrDefault();
                    developer.WorkingOn.Add(bug);
                    bug.AttachedTo = developer;
                    sqlServer.SaveChanges();
                }
            }
        }
    }
}
