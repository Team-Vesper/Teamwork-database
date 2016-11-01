namespace TeamVesper.SqlServerData
{
    using System.Linq;
    using Models;

    public static class PrioritiesDB
    {
        public static void Add()
        {
            var sqlSever = new SqlServerDbContext();
            string[] priorities = new string[4];
            priorities[0] = "Urgent";
            priorities[1] = "Important";
            priorities[2] = "Not Important";
            priorities[3] = "Don't care";

            foreach (var pr in priorities)
            {
                if (sqlSever.Priorities.Any(p => p.Name == pr))
                {
                }
                else
                {
                    Priority priority = new Priority(pr);
                    sqlSever.Priorities.Add(priority);
                }
            }

            sqlSever.SaveChanges();
        }
    }
}
