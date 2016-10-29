using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TeamVesper.Models;
using TeamVesper.Repositories.Contracts;

namespace TeamVesper.SqlServerData.Contracts
{
    public interface ICurrentSqlServerDbContext : ISqlServerDbContext
    {
        IDbSet<Bug> Bugs { get; set; }

        IDbSet<Developer> Developers { get; set; }

        IDbSet<Team> Teams { get; set; }

        IDbSet<Speciality> Specialities { get; set; }

        IDbSet<Priority> Priorities { get; set; }
    }
}