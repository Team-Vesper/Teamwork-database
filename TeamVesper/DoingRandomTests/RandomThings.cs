using System.Collections.Generic;
using TeamVesper.Models;
using TeamVesper.Mappers;

namespace DoingRandomTests
{
    class RandomThings
    {
        static void Main()
        {
           

        }

        private IEnumerable<MongoDeveloper> GetMongoDevelopers()
        {
            ICollection<MongoDeveloper> MongoDevs = new List<MongoDeveloper>();

            // Team Razors
            MongoDevs.Add(new MongoDeveloper("pesho", "Petar Petrov", 20, 1500, "UX Designer", "Razors", false));
            MongoDevs.Add(new MongoDeveloper("gosho", "Georgi Georgiev", 34, 2500, ".Net Developer", "Razors", true));
            MongoDevs.Add(new MongoDeveloper("tisho", "Tihomir Ivanov", 28, 2000, "QA Developer", "Razors", false));
            MongoDevs.Add(new MongoDeveloper("mani", "Mihail Trenchev", 25, 1800, ".Net Developer", "Razors", false));
            MongoDevs.Add(new MongoDeveloper("ghost", "Silviq Stoqnova", 24, 2000, ".Net Developer", "Razors", false));
            MongoDevs.Add(new MongoDeveloper("mina", "Milena Naydenova", 28, 1800, "Javascript Developer", "Razors", false));

            // Team Overpowered
            MongoDevs.Add(new MongoDeveloper("hope", "Vqra Dimitrova", 26, 2000, "System Administrator", "Overpowered", false));
            MongoDevs.Add(new MongoDeveloper("gri6o", "Georgi Jevel", 30, 2500, "System Administrator", "Overpowered", true));
            MongoDevs.Add(new MongoDeveloper("storm", "Simeon Vlajkov", 27, 1700, "C++ Developer", "Overpowered", false));
            MongoDevs.Add(new MongoDeveloper("TheHub", "Emil Minchev", 25, 1600, "Database Developer", "Overpowered", false));
            MongoDevs.Add(new MongoDeveloper("hardy", "Dimitar Kolev", 33, 2000, "Embedded Programer", "Overpowered", false));

            // Team Fire
            MongoDevs.Add(new MongoDeveloper("pixel", "Valeriq Angelova", 27, 1800, "UX Designer", "Fire", false));
            MongoDevs.Add(new MongoDeveloper("zyra", "Zornica Nikolova", 32, 1600, "Javascript Developer", "Fire", false));
            MongoDevs.Add(new MongoDeveloper("diana", "Diana Stefanova", 31, 2500, "UX Designer", "Fire", true));
            MongoDevs.Add(new MongoDeveloper("lori", "Lora Ivanova", 23, 1400, "Javascript Developer", "Fire", false));
            MongoDevs.Add(new MongoDeveloper("king", "Georgi Todorov", 28, 2000, "Javascript Developer", "Fire", false));
            MongoDevs.Add(new MongoDeveloper("cyclone", "Todor Georgiev", 30, 2100, "Javascript Developer", "Fire", false));

            // Team Extreme
            MongoDevs.Add(new MongoDeveloper("key", "Krasimir Velchev", 28, 2200, "C++ Developer", "Extreme", false));
            MongoDevs.Add(new MongoDeveloper("eagle", "Evgeni Mihaylov", 25, 1700, "C++ Developer", "Extreme", false));
            MongoDevs.Add(new MongoDeveloper("ermac", "Stefan Angelov", 30, 2500, "C++ Developer", "Extreme", true));
            MongoDevs.Add(new MongoDeveloper("stoneface", "Sinmeon Stoqnov", 28, 1900, "QA Developer", "Extreme", false));
            MongoDevs.Add(new MongoDeveloper("rocket", "Radostina Koleva", 23, 2000, "QA Developer", "Extreme", false));
            MongoDevs.Add(new MongoDeveloper("cable", "Boris Danailov", 25, 1500, "Embedded Programer", "Extreme", false));
            MongoDevs.Add(new MongoDeveloper("TLO", "Fani Hristova", 23, 1900, "Embedded Programer", "Extreme", false));

            // Team Core
            MongoDevs.Add(new MongoDeveloper("royal", "Daniel Qnkov", 35, 3000, "Software Architect", "Core", false));
            MongoDevs.Add(new MongoDeveloper("Gandalf", "Petar Veselinov", 37, 4000, "Software Architect", "Core", true));
            MongoDevs.Add(new MongoDeveloper("impact", "Gergana Jivkova", 32, 3500, "Software Architect", "Core", false));


            return MongoDevs;
        }

        private IEnumerable<Developer> GetDevelopers()
        {
            return GetMongoDevelopers().Developers();
        }

        private IEnumerable<Speciality> GetSpecialities()
        {
            return GetMongoDevelopers().Specialities();
        }

        private IEnumerable<Team> GetTeams()
        {
            return GetMongoDevelopers().Teams();
        }
    }
}
