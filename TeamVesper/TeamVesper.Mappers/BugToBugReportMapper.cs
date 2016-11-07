using System;
using System.Collections.Generic;
using System.Linq;
using TeamVesper.Models;
using TeamVesper.Repositories.Contracts;

namespace TeamVesper.Mappers
{
    public class BugToBugReportMapper
    {
        private ICurrentSqlServerDbContext dbContext;

        public BugToBugReportMapper(ICurrentSqlServerDbContext dbContext)
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

        public IEnumerable<BugReport> ExtractBugInfo()
        {
            var result = this.dbContext.Bugs
                .Select(x => new BugReport
                {
                    Id = x.Id,
                    Name = x.Description,
                    AcceptedOn = x.AcceptedOn,
                    SolvedOn = x.solvedOn
                }).ToList();


            return result;
        }
    }
}
