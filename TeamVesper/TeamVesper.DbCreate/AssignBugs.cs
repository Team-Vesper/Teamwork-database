namespace TeamVesper.DbCreate
{
    using Models;
    using MongoDB.Driver;
    using SqlServerData;
    using System.Linq;

    public static class AssignBugs
    {
        public static void Assign()
        {
            var client = new MongoClient(@"mongodb://localhost");
            var dbContext = client.GetDatabase("TeamVesper");
            var devs = dbContext.GetCollection<MongoDeveloper>("Devs");
            var sqlServer = new SqlServerDbContext();

            foreach (var bug in sqlServer.Bugs.ToList())
            {
                if (bug.AttachedTo == null)
                {
                    var developer = devs.Find(d => d.Speciality == bug.Speciality.Name).FirstOrDefault();
                    //TODO: Would be great if they can be ordered by bug count, so the one with less bugs takes the new one
                    //TODO: developer.workson.add(bug) and bug.attachedto(developer)
                }                
            }
            sqlServer.SaveChanges();
        }
    }
}
