using System.Collections.Generic;
using System.Linq;
using TeamVesper.Models;

namespace TeamVesper.MongoDB.Models.Extension
{
    public static class MongoDeveloperCollectionsExtensions
    {
        public static IEnumerable<Speciality> Specialities(this IEnumerable<MongoDeveloper> devs)
        {
            var result = new HashSet<Speciality>();

            foreach (var dev in devs)
            {
                var spec = new Speciality()
                {
                    Name = dev.Speciality
                };

                result.Add(spec);
            }

            return result;
        }

        public static IEnumerable<Team> Teams(this IEnumerable<MongoDeveloper> devs)
        {
            var result = new HashSet<Team>();

            foreach (var dev in devs)
            {
                var spec = new Team()
                {
                    Name = dev.Speciality
                };

                result.Add(spec);
            }

            return result;
        }

        public static IEnumerable<Developer> Developers(this IEnumerable<MongoDeveloper> devs)
        {
            var result = new HashSet<Developer>();

            foreach (var dev in devs)
            {
                var splitedNames = dev.FullName.Split(' ');

                var newDev = new Developer()
                {
                    FirstName = splitedNames[0],
                    // just in case there more then 2 names -> all after 1st goin in LastName by design
                    LastName = string.Join(" ", splitedNames.Skip(1).Take(splitedNames.Length - 1)),
                    Age = dev.Age,
                    isTeamLeader = dev.isTeamLeader,
                    Salary = dev.Salary
                };

                result.Add(newDev);
            }

            return result;
        }
    }
}
