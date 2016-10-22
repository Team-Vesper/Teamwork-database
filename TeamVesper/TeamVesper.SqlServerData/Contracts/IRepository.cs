using System.Linq;

namespace TeamVesper.SqlServerData.Contracts
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> All();

        void Add(TEntity entity);

        void Update(TEntity entity);

        TEntity FindById(object id);

        void Remove(TEntity entity);

        void SaveChanges();
    }
}
