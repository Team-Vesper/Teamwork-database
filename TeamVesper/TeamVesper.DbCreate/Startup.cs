using MongoDB.Driver;
using System.Collections.Generic;
using System.Data.Entity;
using TeamVesper.Models;
using TeamVesper.SqlServerData;
using TeamVesper.SqlServerData.Migrations;

namespace TeamVesper.DbCreate
{
    public class Startup
    {
        public static void Main()
        {
            //Database.SetInitializer(
            //    new DropCreateDatabaseAlways<SqlServerDbContext>());

            Database.SetInitializer(
                    new MigrateDatabaseToLatestVersion<SqlServerDbContext, Configuration>());

            SqlServerDbCreate();
            AddPriorities.Add();
            AddSpecialities.Add();
            AddBugsToDB.Add();
            // AssignBugs.Assign();

            // MongoDBCreate();
        }

        private static void SqlServerDbCreate()
        {
            var sqlServerDbContext = new SqlServerDbContext();

            using (sqlServerDbContext)
            {
                sqlServerDbContext.Database.CreateIfNotExists();
            }
        }

        private static void MongoDBCreate()
        {
            var client = new MongoClient(@"mongodb://localhost");

            var dbContext = client.GetDatabase("TeamVesper");

            dbContext.DropCollection("Devs");
            var devs = dbContext.GetCollection<MongoDeveloper>("Devs");

            ICollection<MongoDeveloper> devsForAdd = new List<MongoDeveloper>();

            // Team Razors
            devsForAdd.Add(new MongoDeveloper("pesho", "Petar Petrov", 20, 1500, "UX Designer", "Razors", false));
            devsForAdd.Add(new MongoDeveloper("gosho", "Georgi Georgiev", 34, 2500, ".Net Developer", "Razors", true));
            devsForAdd.Add(new MongoDeveloper("tisho", "Tihomir Ivanov", 28, 2000, "QA Developer", "Razors", false));
            devsForAdd.Add(new MongoDeveloper("mani", "Mihail Trenchev", 25, 1800, ".Net Developer", "Razors", false));
            devsForAdd.Add(new MongoDeveloper("ghost", "Silviq Stoqnova", 24, 2000, ".Net Developer", "Razors", false));
            devsForAdd.Add(new MongoDeveloper("mina", "Milena Naydenova", 28, 1800, "Javascript Developer", "Razors", false));

            // Team Overpowered
            devsForAdd.Add(new MongoDeveloper("hope", "Vqra Dimitrova", 26, 2000, "System Administrator", "Overpowered", false));
            devsForAdd.Add(new MongoDeveloper("gri6o", "Georgi Jevel", 30, 2500, "System Administrator", "Overpowered", true));
            devsForAdd.Add(new MongoDeveloper("storm", "Simeon Vlajkov", 27, 1700, "C++ Developer", "Overpowered", false));
            devsForAdd.Add(new MongoDeveloper("TheHub", "Emil Minchev", 25, 1600, "Database Developer", "Overpowered", false));
            devsForAdd.Add(new MongoDeveloper("hardy", "Dimitar Kolev", 33, 2000, "Embedded Programer", "Overpowered", false));

            // Team Fire
            devsForAdd.Add(new MongoDeveloper("pixel", "Valeriq Angelova", 27, 1800, "UX Designer", "Fire", false));
            devsForAdd.Add(new MongoDeveloper("zyra", "Zornica Nikolova", 32, 1600, "Javascript Developer", "Fire", false));
            devsForAdd.Add(new MongoDeveloper("diana", "Diana Stefanova", 31, 2500, "UX Designer", "Fire", true));
            devsForAdd.Add(new MongoDeveloper("lori", "Lora Ivanova", 23, 1400, "Javascript Developer", "Fire", false));
            devsForAdd.Add(new MongoDeveloper("king", "Georgi Todorov", 28, 2000, "Javascript Developer", "Fire", false));
            devsForAdd.Add(new MongoDeveloper("cyclone", "Todor Georgiev", 30, 2100, "Javascript Developer", "Fire", false));

            // Team Extreme
            devsForAdd.Add(new MongoDeveloper("key", "Krasimir Velchev", 28, 2200, "C++ Developer", "Extreme", false));
            devsForAdd.Add(new MongoDeveloper("eagle", "Evgeni Mihaylov", 25, 1700, "C++ Developer", "Extreme", false));
            devsForAdd.Add(new MongoDeveloper("ermac", "Stefan Angelov", 30, 2500, "C++ Developer", "Extreme", true));
            devsForAdd.Add(new MongoDeveloper("stoneface", "Sinmeon Stoqnov", 28, 1900, "QA Developer", "Extreme", false));
            devsForAdd.Add(new MongoDeveloper("rocket", "Radostina Koleva", 23, 2000, "QA Developer", "Extreme", false));
            devsForAdd.Add(new MongoDeveloper("cable", "Boris Danailov", 25, 1500, "Embedded Programer", "Extreme", false));
            devsForAdd.Add(new MongoDeveloper("TLO", "Fani Hristova", 23, 1900, "Embedded Programer", "Extreme", false));

            // Team Core
            devsForAdd.Add(new MongoDeveloper("royal", "Daniel Qnkov", 35, 3000, "Software Architect", "Core", false));
            devsForAdd.Add(new MongoDeveloper("Gandalf", "Petar Veselinov", 37, 4000, "Software Architect", "Core", true));
            devsForAdd.Add(new MongoDeveloper("impact", "Gergana Jivkova", 32, 3500, "Software Architect", "Core", false));

            devs.InsertMany(devsForAdd);

            // System.Console.WriteLine(devs.Find(_ => true).ToList().Count);
        }
    }
}
