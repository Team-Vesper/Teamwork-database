using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TeamVesper.Models;
using TeamVesper.Repositories.Contracts;

namespace TeamVesper.Repositories.Contracts
{
    public interface ICurrentSqlServerDbContext : IDbContext
    {
        IDbSet<Bug> Bugs { get; }

        IDbSet<Developer> Developers { get; }

        IDbSet<Team> Teams { get; }

        IDbSet<Speciality> Specialities { get; }

        IDbSet<Priority> Priorities { get; }

        IDbSet<Education> Educations { get; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}