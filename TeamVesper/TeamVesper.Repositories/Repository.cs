using System;
using System.Collections.Generic;
using TeamVesper.Repositories.Contracts;

namespace TeamVesper.Repositories
{
    /// <summary>
    /// ! Important. Will be deleted do not inherit it !
    /// </summary>
    /// <typeparam name="TEntity">Model</typeparam>
    public abstract class Repository<TEntity> : IRepository<TEntity>, IReadableRepository<TEntity>
        where TEntity : class
    {
        // TODO Delete
        public abstract void Add(TEntity entity);

        public abstract void AddMany(IEnumerable<TEntity> entities);

        public abstract IEnumerable<TEntity> All();

        public abstract TEntity FindById(object id);

        public abstract void Remove(TEntity entity);

        public abstract void RemoveMany(IEnumerable<TEntity> entities);

        public abstract void Update(TEntity entity);

        public abstract void UpdateMany(IEnumerable<TEntity> entities);
    }
}
