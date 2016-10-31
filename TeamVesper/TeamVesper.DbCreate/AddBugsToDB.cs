using System.Collections.Generic;
using TeamVesper.Models;
using TeamVesper.SqlServerData;

namespace TeamVesper.DbCreate
{
    public static class AddBugsToDB
    {
        public static void Add()
        {
            var excelArchivePath = "../../../Bugs.zip";
            var sqlSever = new SqlServerDbContext();
            var bugs = new List<Bug>();
            bugs = ExcelReader.Read(excelArchivePath);

            foreach (var bug in bugs)
            {
                var find = sqlSever.Bugs.Find(bug);
                if (find == null)
                {
                    sqlSever.Bugs.Add(bug);
                }
            }

            sqlSever.SaveChanges();
        }
    }
}
