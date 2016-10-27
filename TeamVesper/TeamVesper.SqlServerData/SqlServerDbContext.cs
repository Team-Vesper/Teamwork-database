using System;
using System.Data.Entity;

using TeamVesper.Models;
using TeamVesper.SqlServerData.Contracts;

namespace TeamVesper.SqlServerData
{
    public class SqlServerDbContext : DbContext, ISqlServerDbContext
    {
        public SqlServerDbContext()
            : base("TeamVesperSqlServer")
        {
        }

        public virtual IDbSet<Developer> Developers { get; set; }

        public virtual IDbSet<Bug> Bugs { get; set; }

        public virtual IDbSet<Team> Teams { get; set; }

        public new IDbSet<TEntity> Set<TEntity>()
            where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
