namespace TeamVesper.Utilities
{
    using DoingRandomTests;
    using Mappers;
    using Models;
    using MongoDB.Driver;
    using SqlServerData;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class DevelopersActions
    {
        public static void AddFromTest()
        {
            List<Developer> devs = RandomThings.GetDevelopers().ToList();
            var sqlSever = new SqlServerDbContext();
            var rng = new Random();

            foreach (var dev in devs)
            {
                if (sqlSever.Developers.Any(d => d.UserName == dev.UserName))
                {
                }
                else
                {
                    var devToAdd = new Developer();
                    devToAdd.UserName = dev.UserName;
                    devToAdd.FirstName = dev.FirstName;
                    devToAdd.LastName = dev.LastName;
                    devToAdd.Age = dev.Age;
                    devToAdd.Salary = dev.Salary;
                    devToAdd.isTeamLeader = dev.isTeamLeader;
                    devToAdd.SpecialityId = rng.Next(1, 10);
                    devToAdd.TeamId = rng.Next(1, 6);
                    sqlSever.Developers.Add(devToAdd);
                }
            }

            sqlSever.SaveChanges();
        }

        public static void AddFromMongo()
        {
            var client = new MongoClient(@"mongodb://localhost");
            var dbContext = client.GetDatabase("TeamVesper");
            var devs = dbContext.GetCollection<MongoDeveloper>("Devs");
            // List<Developer> sqlDevs = MongoDeveloperCollectionsExtensions.Developers(devs);
        }
    }
}
