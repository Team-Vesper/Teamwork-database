using System.Collections.Generic;
using System.Linq;
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
                if (sqlSever.Bugs.Any(b => b.Id == bug.Id))
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
