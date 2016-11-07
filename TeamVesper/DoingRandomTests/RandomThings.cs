using System.Collections.Generic;
using TeamVesper.Models;
using TeamVesper.Mappers;
using TeamVesper.SqlServerData;
using System.Data.Entity;
using System.Linq;

namespace DoingRandomTests
{
    public static class RandomThings
    {
        public static void Main()
        {
            var db = new SqlServerDbContext();

            var result = new List<BugInfo>();

            var bugs = db.Bugs
                            .Include("Priority")
                            .Include("Speciality")
                            .Include("AttachedTo")
                            //.Include("Team")
                            .ToList();

            foreach (var bug in bugs)
            {
                var bugIngo = new BugInfo
                {
                    Id = bug.Id,
                    Description = bug.Description,
                    Priority = bug.Priority.Name,
                    Speciality = bug.Speciality.Name,
                    SolvedOn = bug.solvedOn.ToString(),
                    AttachTo = bug.AttachedTo.UserName,
                    Team = bug.AttachedTo.Team.Name
                };

                result.Add(bugIngo);

                System.Console.WriteLine(bugIngo.Id);
            }

        }

        private static IEnumerable<MongoDeveloper> GetMongoDevelopers()
        {
            ICollection<MongoDeveloper> MongoDevs = new List<MongoDeveloper>();

            // Team Razors
            MongoDevs.Add(new MongoDeveloper("pesho", "Petar Petrov", 20, "UX Designer", "Razors", false));
            MongoDevs.Add(new MongoDeveloper("gosho", "Georgi Georgiev", 34, ".Net Developer", "Razors", true));
            MongoDevs.Add(new MongoDeveloper("tisho", "Tihomir Ivanov", 28, "QA Developer", "Razors", false));
            MongoDevs.Add(new MongoDeveloper("mani", "Mihail Trenchev", 25, ".Net Developer", "Razors", false));
            MongoDevs.Add(new MongoDeveloper("ghost", "Silviq Stoqnova", 24, ".Net Developer", "Razors", false));
            MongoDevs.Add(new MongoDeveloper("mina", "Milena Naydenova", 28, "Javascript Developer", "Razors", false));

            // Team Overpowered
            MongoDevs.Add(new MongoDeveloper("hope", "Vqra Dimitrova", 26, "System Administrator", "Overpowered", false));
            MongoDevs.Add(new MongoDeveloper("gri6o", "Georgi Jevel", 30, "System Administrator", "Overpowered", true));
            MongoDevs.Add(new MongoDeveloper("storm", "Simeon Vlajkov", 27, "C++ Developer", "Overpowered", false));
            MongoDevs.Add(new MongoDeveloper("TheHub", "Emil Minchev", 25, "Database Developer", "Overpowered", false));
            MongoDevs.Add(new MongoDeveloper("hardy", "Dimitar Kolev", 33, "Embedded Programer", "Overpowered", false));

            // Team Fire
            MongoDevs.Add(new MongoDeveloper("pixel", "Valeriq Angelova", 27, "UX Designer", "Fire", false));
            MongoDevs.Add(new MongoDeveloper("zyra", "Zornica Nikolova", 32, "Javascript Developer", "Fire", false));
            MongoDevs.Add(new MongoDeveloper("diana", "Diana Stefanova", 31, "UX Designer", "Fire", true));
            MongoDevs.Add(new MongoDeveloper("lori", "Lora Ivanova", 23, "Javascript Developer", "Fire", false));
            MongoDevs.Add(new MongoDeveloper("king", "Georgi Todorov", 28, "Javascript Developer", "Fire", false));
            MongoDevs.Add(new MongoDeveloper("cyclone", "Todor Georgiev", 30, "Javascript Developer", "Fire", false));

            // Team Extreme
            MongoDevs.Add(new MongoDeveloper("key", "Krasimir Velchev", 28, "C++ Developer", "Extreme", false));
            MongoDevs.Add(new MongoDeveloper("eagle", "Evgeni Mihaylov", 25, "C++ Developer", "Extreme", false));
            MongoDevs.Add(new MongoDeveloper("ermac", "Stefan Angelov", 30, "C++ Developer", "Extreme", true));
            MongoDevs.Add(new MongoDeveloper("stoneface", "Sinmeon Stoqnov", 28, "QA Developer", "Extreme", false));
            MongoDevs.Add(new MongoDeveloper("rocket", "Radostina Koleva", 23, "QA Developer", "Extreme", false));
            MongoDevs.Add(new MongoDeveloper("cable", "Boris Danailov", 25, "Embedded Programer", "Extreme", false));
            MongoDevs.Add(new MongoDeveloper("TLO", "Fani Hristova", 23, "Embedded Programer", "Extreme", false));

            // Team Core
            MongoDevs.Add(new MongoDeveloper("royal", "Daniel Qnkov", 35, "Software Architect", "Core", false));
            MongoDevs.Add(new MongoDeveloper("Gandalf", "Petar Veselinov", 37, "Software Architect", "Core", true));
            MongoDevs.Add(new MongoDeveloper("impact", "Gergana Jivkova", 32, "Software Architect", "Core", false));


            return MongoDevs;
        }

        public static IEnumerable<Developer> GetDevelopers()
        {
            return GetMongoDevelopers().Developers();
        }

        public static IEnumerable<Speciality> GetSpecialities()
        {
            return GetMongoDevelopers().Specialities();
        }

        public static IEnumerable<Team> GetTeams()
        {
            return GetMongoDevelopers().Teams();
        }
    }
}
