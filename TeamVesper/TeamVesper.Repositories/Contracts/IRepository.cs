using System.Collections.Generic;

namespace TeamVesper.Repositories.Contracts
{
    public interface IRepository<TEntity> : IReadableRepository<TEntity>
    {
        void Add(TEntity entity);

        void AddMany(IEnumerable<TEntity> entities);

        //void Update(TEntity entity);

        //void UpdateMany(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveMany(IEnumerable<TEntity> entities);
    }
}
