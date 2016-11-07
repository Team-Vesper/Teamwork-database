using System;
using System.Collections.Generic;
using System.Linq;
using TeamVesper.Models;
using TeamVesper.Repositories.Contracts;

namespace TeamVesper.Mappers
{
    public class BugToBugMapper
    {
        private ICurrentSqlServerDbContext dbContext;

        public BugToBugMapper(ICurrentSqlServerDbContext dbContext)
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

        public IEnumerable<Bug> BugToBugConnection(IEnumerable<Bug> bugs)
        {
            var result = new List<Bug>();

            var specialities = this.dbContext.Specialities.ToList();
            var priorities = this.dbContext.Priorities.ToList();

            foreach (var bug in bugs)
            {
                bug.Speciality = specialities.FirstOrDefault(x => x.Id == bug.SpecialityId);

                bug.Priority = priorities.FirstOrDefault(x => x.Id == bug.PriorityId);

                result.Add(bug);
            }

            return result;
        }
    }
}
