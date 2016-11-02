using System;
using System.Collections.Generic;
using System.Data.Entity;
using TeamVesper.Models;
using TeamVesper.SqlServerData.Contracts;

namespace TeamVesper.Mappers
{
    public class StarndartModelsToMongoModelMapper
    {
        private ICurrentSqlServerDbContext dbContext;

        public StarndartModelsToMongoModelMapper(ICurrentSqlServerDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        private ICurrentSqlServerDbContext DbContext
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
                            .Include("Specialities")
                            .Include("Teams");

            foreach (var dev in devs)
            {
                var devForAdd = new MongoDeveloper(
                                        dev.UserName,
                                        dev.FirstName + " " + dev.LastName,
                                        dev.Age,
                                        dev.Speciality.Name,
                                        dev.Team.Name,
                                        dev.isTeamLeader);

                result.Add(devForAdd);
            }

            return result;
        }
    }
}
