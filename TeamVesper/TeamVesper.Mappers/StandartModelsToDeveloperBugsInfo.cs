using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TeamVesper.Models;
using TeamVesper.SqlServerData.Contracts;

namespace TeamVesper.Mappers
{
    public class StandartModelsToDeveloperBugsInfo
    {
        private ICurrentSqlServerDbContext dbContext;

        public StandartModelsToDeveloperBugsInfo(ICurrentSqlServerDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        private ICurrentSqlServerDbContext DbContext
        {
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("ICurrentSqlServerDbContext");
                }

                this.dbContext = value;
            }
        }

        public IEnumerable<DeveloperBugsInfo> GetDeveloperBugsInfo()
        {
            var devs = this.dbContext.Developers;
            var bugs = this.dbContext.Bugs.Include("Developers");

            var devsInfo = new HashSet<DeveloperBugsInfo>();

            foreach (var dev in devs)
            {
                var info = new DeveloperBugsInfo(dev.Id,
                                                    dev.UserName,
                                                    dev.FirstName,
                                                    dev.LastName,
                                                    bugs.Where(x => x.solvedOn != null)
                                                        .Where(x => x.AttachedTo.Id == dev.Id)
                                                        .Count()
                                                   );

                devsInfo.Add(info);
            }

            return devsInfo;
        }
    }
}
