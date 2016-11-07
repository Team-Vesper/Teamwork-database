using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TeamVesper.Repositories.Contracts
{
    public interface IReadableRepository<TEntity>
    {
        IEnumerable<TEntity> All();

        IEnumerable<TEntity> All(Expression<Func<TEntity, bool>> filterExpresion);
    }
}
