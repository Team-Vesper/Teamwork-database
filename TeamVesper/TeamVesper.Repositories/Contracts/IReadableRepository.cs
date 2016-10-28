using System.Collections.Generic;

namespace TeamVesper.Repositories.Contracts
{
    public interface IReadableRepository<TEntity>
    {
        IEnumerable<TEntity> All();

        TEntity FindById(object id);
    }
}
