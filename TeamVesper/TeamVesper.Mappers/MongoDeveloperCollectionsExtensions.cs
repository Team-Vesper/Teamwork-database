using System.Collections.Generic;
using System.Linq;
using TeamVesper.Models;

namespace TeamVesper.Mappers
{
    public static class MongoDeveloperCollectionsExtensions
    {
        public static IEnumerable<Speciality> Specialities(this IEnumerable<MongoDeveloper> devs)
        {
            var names = new HashSet<string>();

            foreach (var dev in devs)
            {
                names.Add(dev.Speciality);
            }

            var result = new List<Speciality>();

            foreach (var name in names)
            {
                var spec = new Speciality(name);

                result.Add(spec);
            }

            return result;
        }

        public static IEnumerable<Team> Teams(this IEnumerable<MongoDeveloper> devs)
        {
            var names = new HashSet<string>();

            foreach (var dev in devs)
            {
                names.Add(dev.Team);
            }

            var result = new List<Team>();

            foreach (var name in names)
            {
                var team = new Team(name);

                result.Add(team);
            }

            return result;
        }

        public static IEnumerable<Developer> Developers(this IEnumerable<MongoDeveloper> devs)
        {
            var teams = devs.Teams();
            var specs = devs.Specialities();

            var result = new HashSet<Developer>();

            foreach (var dev in devs)
            {
                var splitedNames = dev.FullName.Split(' ');
                var team = teams.FirstOrDefault(x => x.Name == dev.Team);
                var spec = specs.FirstOrDefault(x => x.Name == dev.Speciality);

                var newDev = new Developer()
                {
                    UserName = dev.Username,
                    FirstName = splitedNames[0],
                    // just in case there more then 2 names -> all after 1st goin in LastName by design
                    LastName = string.Join(" ", splitedNames.Skip(1).Take(splitedNames.Length - 1)),
                    Age = dev.Age,
                    Team = team,
                    Speciality = spec,
                    isTeamLeader = dev.isTeamLeader
                };

                result.Add(newDev);
            }

            return result;
        }
    }
}
