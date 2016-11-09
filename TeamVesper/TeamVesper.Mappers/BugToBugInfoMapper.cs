using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TeamVesper.Models;
using TeamVesper.Repositories.Contracts;

namespace TeamVesper.Mappers
{
    public class BugToBugInfoMapper
    {
        private ICurrentSqlServerDbContext dbContext;

        public BugToBugInfoMapper(ICurrentSqlServerDbContext dbContext)
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

        public IEnumerable<BugInfo> ExtractBugInfo()
        {
            var result = new List<BugInfo>();

            var bugs = this.dbContext.Bugs
                            .Include("Priority")
                            .Include("Speciality")
                            .Include("AttachedTo")
                          //  .Include("Team")
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
                    //AttachTo = bug.AttachedTo.UserName
                    //Team = bug.AttachedTo.Team.Name
                };

                result.Add(bugIngo);
            }

            return result;
        }
    }
}
