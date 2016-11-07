using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TeamVesper.Models;
using TeamVesper.Repositories.Contracts;
using TeamVesper.SqlServerData;

namespace TeamVesper.Mappers
{
    public class StarndartModelsToMongoModelMapper
    {
        private SqlServerDbContext dbContext;

        public StarndartModelsToMongoModelMapper(SqlServerDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        private SqlServerDbContext DbContext
        {
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("ICurrentSqlServerDbContext dbContext");
                }

                this.dbContext = value;
            }
        }

        public IEnumerable<MongoDeveloper> ExtractMongoDevelopers()
        {
            var result = new List<MongoDeveloper>();

            var devs = this.dbContext
                            .Developers
                            .Include("Speciality")
                            .Include("Team")
                            .ToList();

            foreach (var dev in devs)
            {
                var devForAdd = new MongoDeveloper(
                                        dev.UserName,
                                        dev.FirstName + " " + dev.LastName,
                                        dev.Age,
                                        dev.Speciality.Name,
                                        dev.Team.Name,
                                        dev.isTeamLeader);
                devForAdd.Id = dev.Id.ToString();

                result.Add(devForAdd);
            }

            return result;
        }
    }
}
