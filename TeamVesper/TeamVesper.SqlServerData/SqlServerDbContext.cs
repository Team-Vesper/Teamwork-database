using System.Data.Entity;

using TeamVesper.Models;

namespace TeamVesper.SqlServerData
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext()
            : base("TeamVesperSqlServer")
        {

        }

        public virtual IDbSet<Developer> Developers { get; set; }

        public virtual IDbSet<Bug> Bugs { get; set; }

        public virtual IDbSet<Team> Teams { get; set; }

        public virtual IDbSet<SqlInitializer> Initializer { get; set; }
    }
}
