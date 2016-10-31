using System.Linq;
using TeamVesper.Models;
using TeamVesper.SqlServerData;

namespace TeamVesper.DbCreate
{
    public static class AddPriorities
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
                Priority priority = new Priority(pr);
                var find = sqlSever.Priorities.Find(priority);
                if (find == null)
                {
                    sqlSever.Priorities.Add(priority);
                }
            }

            sqlSever.SaveChanges();
        }
    }
}
