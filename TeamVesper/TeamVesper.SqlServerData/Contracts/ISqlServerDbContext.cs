using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TeamVesper.Models;

namespace TeamVesper.SqlServerData.Contracts
{
    public interface ISqlServerDbContext
    {
        IDbSet<Bug> Bugs { get; set; }

        IDbSet<Developer> Developers { get; set; }

        IDbSet<Team> Teams { get; set; }

        IDbSet<Speciality> Specialities { get; set; }

        IDbSet<Priority> Priorities { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}